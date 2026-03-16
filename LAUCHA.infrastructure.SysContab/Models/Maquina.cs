using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Maquina
{
    public int Id { get; set; }

    public int NumMaquina { get; set; }

    public bool Activa { get; set; }

    public string Nombre { get; set; } = null!;

    public int Prioridad { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<ContratosTrabajo> ContratosTrabajos { get; set; } = new List<ContratosTrabajo>();

    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();

    public virtual ICollection<Subconjunto> Subconjuntos { get; set; } = new List<Subconjunto>();
}
