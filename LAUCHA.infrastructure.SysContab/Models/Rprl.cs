using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Rprl
{
    public int Mid { get; set; }

    public string? NombreCuenta { get; set; }

    public string? CodRpRl { get; set; }

    public string? Subcodigo { get; set; }

    public string? Descripcion { get; set; }

    public int? GastoPesos { get; set; }

    public DateTime? Fecha { get; set; }

    public int? MonedaId { get; set; }

    public double? ValorMonedaOrien { get; set; }

    public double? ValorMonedaDestino { get; set; }
}
