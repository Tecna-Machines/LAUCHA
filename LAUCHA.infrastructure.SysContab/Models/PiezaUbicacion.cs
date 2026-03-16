using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PiezaUbicacion
{
    public int Id { get; set; }

    public int PiezaId { get; set; }

    public int UbicacionPiezaId { get; set; }

    public virtual Pieza Pieza { get; set; } = null!;

    public virtual Ubicacione UbicacionPieza { get; set; } = null!;
}
