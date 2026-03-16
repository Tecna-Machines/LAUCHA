using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Materiale
{
    public int Id { get; set; }

    public string Material { get; set; } = null!;

    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();
}
