using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Ocitem
{
    public string? NombreProveedor { get; set; }

    public int Orden { get; set; }

    public string? Nombreestado { get; set; }

    public int? Item { get; set; }

    public string? Descrip { get; set; }

    public string? Codigo { get; set; }

    public string? SubcodigoG { get; set; }

    public string? SubcodigoM { get; set; }

    public int? Cant { get; set; }

    public int? Piezaid { get; set; }

    public decimal? Preciousd { get; set; }

    public bool? SiUD { get; set; }

    public double? Tc { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Dto { get; set; }

    public int? PagoId { get; set; }
}
