using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PorCuentum
{
    public int CuentaId { get; set; }

    public string? NombreMoneda { get; set; }

    public string? NombreCuenta { get; set; }

    public int? TotalCta { get; set; }
}
