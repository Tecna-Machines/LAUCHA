using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class MovimientosCuenta
{
    public string NombreCuenta { get; set; } = null!;

    public float Monto { get; set; }

    public string NombreMoneda { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Subcodigo { get; set; }

    public int? Pagoid { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Nombreproveedor { get; set; }
}
