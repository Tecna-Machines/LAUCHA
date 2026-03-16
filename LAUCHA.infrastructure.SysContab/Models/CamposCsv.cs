using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CamposCsv
{
    public int Id { get; set; }

    public string PartNumber { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public string Qty { get; set; } = null!;

    public string StockNumber { get; set; } = null!;

    public string Material { get; set; } = null!;

    public string? Conjunto { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int Discriminante { get; set; }

    public bool PasarAproMec { get; set; }

    public int NumMaquina { get; set; }

    public byte[]? Foto { get; set; }

    public int NumFoto { get; set; }

    public bool YaEnProMec { get; set; }

    public bool NoPasar { get; set; }

    public int NumVersion { get; set; }

    public int? CantidadFinal { get; set; }

    public string? Categoria { get; set; }

    public string Destino { get; set; } = null!;
}
