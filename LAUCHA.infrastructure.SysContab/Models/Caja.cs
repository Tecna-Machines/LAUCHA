using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Caja
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Trasferencia { get; set; }

    public string? Pago { get; set; }

    public int? Monto { get; set; }
}
