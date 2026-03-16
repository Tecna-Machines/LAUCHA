using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Historial
{
    public long Id { get; set; }

    public int PiezaId { get; set; }

    public DateTime? FechaEntradaContainer { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Pieza Pieza { get; set; } = null!;
}
