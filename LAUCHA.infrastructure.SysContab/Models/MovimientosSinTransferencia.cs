using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class MovimientosSinTransferencia
{
    public int Id { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public float MontoPesos { get; set; }

    public int? PagoId { get; set; }

    public string? Codigo { get; set; }

    public string? Subcod { get; set; }
}
