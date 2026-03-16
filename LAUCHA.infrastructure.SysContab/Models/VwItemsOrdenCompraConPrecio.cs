using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class VwItemsOrdenCompraConPrecio
{
    public int Itm { get; set; }

    public int? Oc { get; set; }

    public string? Proveedor { get; set; }

    public int? NroPago { get; set; }

    public string? DescripcionPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public int? PlanoNro { get; set; }

    public string? DescripcionCompra { get; set; }

    public int Cant { get; set; }

    public double PrecioUsd { get; set; }

    public double Precio { get; set; }

    public bool CotizaEnUsd { get; set; }

    public double? TipoDeCambio { get; set; }

    public double Iva { get; set; }

    public double Dto { get; set; }

    public string? CodigoGasto { get; set; }
}
