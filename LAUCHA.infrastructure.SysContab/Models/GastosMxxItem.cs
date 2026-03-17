namespace LAUCHA.infrastructure.SysContab.Models;

public partial class GastosMxxItem
{
    public int OrdenNro { get; set; }

    public string? FechPag { get; set; }

    public bool Pago { get; set; }

    public int? NroPago { get; set; }

    public string? Descripciondepago { get; set; }

    public string? NomProv { get; set; }

    public int? ItmNro { get; set; }

    public string? DescripcionCompra { get; set; }

    public string? CodGasto { get; set; }

    public string? Subcod { get; set; }

    public int? Cant { get; set; }

    public bool? CotiUsd { get; set; }

    public decimal? Tc { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Dto { get; set; }

    public decimal? PrUnitUsd { get; set; }

    public decimal? PrUnit { get; set; }

    public decimal? EquivUsd { get; set; }
}
