using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class NewView2
{
    public int Id { get; set; }

    public string Tipopago { get; set; } = null!;

    public float Montopesos { get; set; }

    public string? Descmov { get; set; }

    public string? Descpago { get; set; }

    public int? Pagoid { get; set; }

    public DateTime FechaGeneracion { get; set; }
}
