using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Ubicacione
{
    public int Id { get; set; }

    public int Cantidad { get; set; }

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<PiezaUbicacion> PiezaUbicacions { get; set; } = new List<PiezaUbicacion>();
}
