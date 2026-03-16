using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Cuenta
{
    public int Id { get; set; }

    public string NombreCuenta { get; set; } = null!;

    public string TipoCuenta { get; set; } = null!;

    public int? MonedaId { get; set; }

    public int? ChequeraId { get; set; }

    public bool? EsAptoCompras { get; set; }

    public virtual Cuenta? Chequera { get; set; }

    public virtual ICollection<CodigosConceptoConciliacion> CodigosConceptoConciliacions { get; set; } = new List<CodigosConceptoConciliacion>();

    public virtual ICollection<DatosBancoAconciliar> DatosBancoAconciliars { get; set; } = new List<DatosBancoAconciliar>();

    public virtual ICollection<Cuenta> InverseChequera { get; set; } = new List<Cuenta>();

    public virtual Moneda? Moneda { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<Subconciliacione> Subconciliaciones { get; set; } = new List<Subconciliacione>();
}
