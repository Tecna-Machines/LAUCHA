using LAUCHA.application;
using LAUCHA.application.interfaces;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarAusencias;
using LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarFeriados;
using LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarHsExtraHabilitadas;
using LAUCHA.application.UseCase.GenerarRecibo;
using LAUCHA.application.UseCase.OperacionesDescuento;
using LAUCHA.application.UseCase.OperarCredito;
using LAUCHA.application.UseCase.V1.CrearCredito;
using LAUCHA.application.UseCase.V1.DiasEspeciales.CrearConsultarVacaciones;
using LAUCHA.application.UseCase.V1.OperarConceptos;
using LAUCHA.domain.entities;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IServices;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.Services.Logs;
using LAUCHA.infrastructure.Services.Marcas;
using LAUCHA.infrastructure.Services.Marcas.Interface;
using LAUCHA.infrastructure.Services.Marcas.Persistence;
using LAUCHA.infrastructure.Services.Menues;
using LAUCHA.infrastructure.unitOfWork;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
string banner = @" $$$$$$\  $$\   $$\ $$$$$$$$\ $$$$$$$\        $$\       $$$$$$\  
$$  __$$\ $$ | $$  |$$  _____|$$  __$$\       $$ |     $$  __$$\ 
$$ /  $$ |$$ |$$  / $$ |      $$ |  $$ |      $$ |     $$ /  $$ |
$$$$$$$$ |$$$$$  /  $$$$$\    $$$$$$$  |      $$ |     $$ |  $$ |
$$  __$$ |$$  $$<   $$  __|   $$  __$$<       $$ |     $$ |  $$ |
$$ |  $$ |$$ |\$$\  $$ |      $$ |  $$ |      $$ |     $$ $$\$$ |
$$ |  $$ |$$ | \$$\ $$$$$$$$\ $$ |  $$ |      $$$$$$$$\\$$$$$$ / 
\__|  \__|\__|  \__|\________|\__|  \__|      \________|\___$$$\ 
                                                            \___|
                                                                 
                                                                 ";

Console.WriteLine(banner + "\n");

//Logs
string logPath = builder.Configuration["Appsettings:logPath"];

if (logPath == null)
{
    Console.WriteLine("error , falta la ruta del archivo de log");
    return;
}

builder.Services.AddSingleton<ILogsApp, LogService>(log =>
{
    return new LogService(logPath);
});

//database
string connectionString = builder.Configuration["ConnectionStrings:Production"];

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration["ConnectionStrings:Test"];
}

builder.Services.AddDbContext<LiquidacionesDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//dependecy injection
//NEW 2025
builder.Services.AddInfrastructureServices();
builder.Services.AddAplicationServices();

builder.Services.AddScoped<IUnitOfWorkEmpleado, UnitOfWorkEmpleado>();
builder.Services.AddScoped<IGenericRepository<Empleado>, Borrame>();
builder.Services.AddScoped<IGenericRepository<Cuenta>, CuentaRepository>();

builder.Services.AddScoped<IGenericRepository<Adicional>, AdicionalRepository>();
builder.Services.AddScoped<IGenericRepository<AcuerdoBlanco>, AcuerdoBlancoRepository>();
builder.Services.AddScoped<IUnitOfWorkContrato, UnitOfWorkContrato>();

builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();



builder.Services.AddScoped<IGenericRepository<Remuneracion>, RemuneracionRepository>();
builder.Services.AddScoped<IRemuneracionRepository, RemuneracionRepository>();


builder.Services.AddScoped<IGenericRepository<Descuento>, DescuentoRepository>();
builder.Services.AddScoped<IGenericRepository<Concepto>, ConceptoRepository>();
builder.Services.AddScoped<IOperarDescuentosService, OperarDescuentosService>();

builder.Services.AddScoped<IGenericRepository<RetencionOLD>, RetencionRepository>();

builder.Services.AddScoped<IRetencionCatalogoRepositoryOLD, RetencionRepository>();
builder.Services.AddScoped<IDescuentoRepository, DescuentoRepository>();

//builder.Services.AddScoped<ILiquidacionService, CrearLiquidacionService>();
builder.Services.AddScoped<IUnitOfWorkLiquidacion, UnitOfWorkLiquidacion>();

builder.Services.AddScoped<IGenericRepository<RemuneracionPorLiquidacionPersonal>, RemuneracionPorLiquidacionRepository>();
builder.Services.AddScoped<IGenericRepository<RetencionPorLiquidacionPersonal>, RetencionPorLiquidacionRepository>();
builder.Services.AddScoped<IGenericRepository<DescuentoPorLiquidacionPersonal>, DescuentosPorLiquidacionesRepository>();
builder.Services.AddScoped<IGenericRepository<Liquidacion>, LiquidacionPersonalRepository>();

builder.Services.AddScoped<IItemsLiquidacionRepository, ITemsLiquidacionRepository>();

builder.Services.AddScoped<IGeneradorRecibos, GeneradorRecibosLiquidacion>();

builder.Services.AddScoped<IGenericRepository<NoRemuneracion>, NoRemuneracionRepository>();
builder.Services.AddScoped<INoRemuneracionRepository, NoRemuneracionRepository>();
builder.Services.AddScoped<IGenericRepository<NoRemuneracionPorLiquidacionPersonal>, NoRemuneracionPorLiquidacionRepository>();

builder.Services.AddScoped<IGenericRepository<Concepto>, ConceptoRepository>();
builder.Services.AddScoped<IOperarConceptosService, OperarConceptos>();

builder.Services.AddScoped<IGenericRepository<Credito>, CreditoRepository>();
builder.Services.AddScoped<ICreadorCreditos, CreadorCreditoService>();

builder.Services.AddScoped<ILiquidacionRepositoryOLD, LiquidacionPersonalRepository>();


builder.Services.AddScoped<ICreditoRepository, CreditoRepository>();
builder.Services.AddScoped<ICreditoService, OperarCreditosService>();
builder.Services.AddScoped<IGenericRepository<PagoCredito>, PagoCreditoRepository>();
builder.Services.AddScoped<ICreditoRepositoryTotal, CreditoRepository>();
builder.Services.AddScoped<IDescuentoRepositoryTotal, DescuentoRepository>();


//dias especiales
builder.Services.AddScoped<IDiasFeriadosRepository, DiaFeriadoRepository>();
builder.Services.AddScoped<ICrearConsultarFeriados, CrearConsultarFeriado>();

builder.Services.AddScoped<IAvisoAusenciaRepository, AvisoAuseciaRepository>();
builder.Services.AddScoped<ICrearConsultarAusencias, CrearConsultarAusenciasService>();

builder.Services.AddScoped<IPeriodoVacacionesRepository, PeriodoVacacionRepository>();
builder.Services.AddScoped<ICrearConsultarVacacionesService, CrearConsultarVacacionesService>();

builder.Services.AddScoped<IHabilitacionHorasExtraRepository, HabilitacionHorasExtraRepository>();
builder.Services.AddScoped<ICrearConsultarHsExtraHabilitadas, ConsultarCrearPermisoHsExtra>();


builder.Services.AddScoped<IGenericRepository<PagoLiquidacion>, PagoLiquidacionRepository>();


builder.Services.AddHttpClient();



//servicios externos
builder.Services.AddScoped<IMenuesService>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string? user = configuration["MenuService:user"];
    string? password = configuration["MenuService:password"];
    string? url = configuration["MenuService:url"];

    if (user == null || password == null || url == null)
    {
        throw new ArgumentNullException();
    }

    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
    httpClient.BaseAddress = new Uri(url);

    return new MenuesService(httpClient, user, password);
});


//Marcas
string? databaseMarcas = builder.Configuration["MarcasService:databasePath"];


builder.Services.AddDbContext<MarcasDbContext>(options => options.UseMySQL(databaseMarcas));

builder.Services.AddScoped<IMarcasDb, MarcasDb>();
builder.Services.AddScoped<IMarcasService, MarcasServiceAccess>();

//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.UseCors("AllowAll");

app.MapControllers();

var logger = app.Services.GetRequiredService<ILogsApp>();
logger.LogInformation("preparando inicio de aplicacion");

//test database
var builderConnectionString = new MySqlConnectionStringBuilder(connectionString);
string host = builderConnectionString.Server;


logger.LogInformation("iniciando prueba de conexion con base de datos...");

try
{
    using var scope = builder.Services.BuildServiceProvider().CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<LiquidacionesDbContext>();

    if (!context.Database.CanConnect())
    {
        logger.LogError($"fallo la conexion con el servidor de base de datos: {host}");
    }

    logger.LogInformation("conexion exitosa con el servidor DB: {Host}", host);
    scope.Dispose();
}
catch (Exception ex)
{
    logger.LogError(ex, "se genero una excepcion al conectar con el host: {Host}", host);
}



logger.LogInformation("todo parece ir bien c: ");
logger.LogInformation("app run...");

app.Run();
