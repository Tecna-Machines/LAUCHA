using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Subconciliacione
{
    public int Id { get; set; }

    public int NumSubConciliacion { get; set; }

    public int CuentaId { get; set; }

    public int? ConciliacionId { get; set; }

    public virtual Conciliacione? Conciliacion { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;

    public virtual ICollection<DatosBancoAconciliar> DatosBancoAconciliars { get; set; } = new List<DatosBancoAconciliar>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
