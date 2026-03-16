using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Subconjunto
{
    public int Id { get; set; }

    public int MaquinaId { get; set; }

    public string NumSubconjunto { get; set; } = null!;

    public string? Nombre { get; set; }

    public int Prioridad { get; set; }

    public virtual Maquina Maquina { get; set; } = null!;

    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();
}
