using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Moneda
{
    public int Id { get; set; }

    public string NombreMoneda { get; set; } = null!;

    public double ValorActual { get; set; }

    public string NombreMonedaPlural { get; set; } = null!;

    public virtual ICollection<ContratosTrabajo> ContratosTrabajos { get; set; } = new List<ContratosTrabajo>();

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
