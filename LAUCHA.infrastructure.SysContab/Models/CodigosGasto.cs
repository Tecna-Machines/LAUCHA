using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CodigosGasto
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string TipoCodigo { get; set; } = null!;

    public bool? Interno { get; set; }

    public bool? EsCodigoMaquina { get; set; }

    public virtual ICollection<CodigosConceptoConciliacion> CodigosConceptoConciliacions { get; set; } = new List<CodigosConceptoConciliacion>();

    public virtual ICollection<ContratosTrabajo> ContratosTrabajoCodigoGastos { get; set; } = new List<ContratosTrabajo>();

    public virtual ICollection<ContratosTrabajo> ContratosTrabajoCodigoPagos { get; set; } = new List<ContratosTrabajo>();

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<SubcodigosGasto> SubcodigosGastos { get; set; } = new List<SubcodigosGasto>();
}
