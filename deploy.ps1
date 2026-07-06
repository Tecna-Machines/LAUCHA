$ErrorActionPreference = "Stop"

# =========================
# CONFIGURACION
# =========================

# Cambiar por la ruta real de tu proyecto .csproj
$ProjectFile = ".\LAUCHA.api\LAUCHA.api.csproj"

$ServerUser = "administrador"
$ServerHost = "api.liquidacion.tecna.local"
$RemoteBase = "/var/www/srv-liquidacion"
$ServiceName = "srv-liquidacion.service"

$LocalPublishDir = Join-Path $PSScriptRoot "publish"

# =========================
# FUNCIONES
# =========================

function Invoke-Native {
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [string]$FilePath,

        [Parameter(ValueFromRemainingArguments = $true, Position = 1)]
        [string[]]$Arguments
    )

    & $FilePath @Arguments

    if ($LASTEXITCODE -ne 0) {
        throw "El comando '$FilePath $($Arguments -join ' ')' fallo con codigo $LASTEXITCODE."
    }
}

function Assert-CommandExists {
    param([string]$Command)

    if (-not (Get-Command $Command -ErrorAction SilentlyContinue)) {
        throw "No se encontro el comando '$Command'. Verifique que este instalado y disponible en PATH."
    }
}

# =========================
# VALIDACIONES
# =========================

Assert-CommandExists "dotnet"
Assert-CommandExists "ssh"
Assert-CommandExists "scp"

if (-not (Test-Path $ProjectFile)) {
    throw "No se encontro el archivo de proyecto: $ProjectFile"
}

# =========================
# PARAMETROS
# =========================

$Version = Read-Host "Ingrese version de la aplicacion. Ejemplo: v2"

if ([string]::IsNullOrWhiteSpace($Version)) {
    throw "La version no puede estar vacia."
}

# Evita caracteres peligrosos en el nombre de carpeta remota
if ($Version -notmatch '^[a-zA-Z0-9._-]+$') {
    throw "La version solo puede contener letras, numeros, punto, guion y guion bajo."
}

$Server = "$ServerUser@$ServerHost"
$RemoteReleaseDir = "$RemoteBase/$Version"

Write-Host ""
Write-Host "=== Deploy srv-liquidacion ==="
Write-Host "Version: $Version"
Write-Host "Servidor: $Server"
Write-Host "Destino: $RemoteReleaseDir"
Write-Host ""

# =========================
# LIMPIAR PUBLISH LOCAL
# =========================

if (Test-Path $LocalPublishDir) {
    Remove-Item $LocalPublishDir -Recurse -Force
}

# =========================
# PUBLICAR
# =========================

Write-Host "Publicando aplicacion..."

Invoke-Native "dotnet" "publish" $ProjectFile "-c" "Release" "-o" $LocalPublishDir

# =========================
# CREAR CARPETA REMOTA
# =========================

Write-Host "Creando carpeta remota..."

Invoke-Native "ssh" $Server "mkdir -p '$RemoteReleaseDir'"

# =========================
# COPIAR ARCHIVOS
# =========================

Write-Host "Copiando archivos al servidor..."

Invoke-Native "scp" "-r" "$LocalPublishDir/*" "${Server}:$RemoteReleaseDir/"

# =========================
# CONFIGURACION Y DEPLOY REMOTO
# =========================

Write-Host "Aplicando configuracion y reiniciando servicio..."

# Comando remoto en una sola linea para evitar problemas CRLF de Windows en bash.
# -tt fuerza terminal interactiva para que sudo pueda pedir password.
$RemoteCommand = "set -e; " +
    "cp '$RemoteBase/appsettings.json' '$RemoteReleaseDir/appsettings.json'; " +
    "sudo systemctl stop '$ServiceName'; " +
    "ln -sfn '$RemoteReleaseDir' '$RemoteBase/current'; " +
    "sudo systemctl start '$ServiceName'; " +
    "sudo systemctl status '$ServiceName' --no-pager --full"

Invoke-Native "ssh" "-tt" $Server "bash -lc `"$RemoteCommand`""

Write-Host ""
Write-Host "Deploy finalizado correctamente."
