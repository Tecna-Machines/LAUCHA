using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PorCuenta2
{
    public int CuentaId { get; set; }

    public string? NombreMoneda { get; set; }

    public string? NombreCuenta { get; set; }

    public int? TotalCta { get; set; }

    public decimal? Tc2 { get; set; }

    public int? EnUsdOficial { get; set; }
}
