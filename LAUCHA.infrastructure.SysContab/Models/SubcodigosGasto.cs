namespace LAUCHA.infrastructure.SysContab.Models;

public partial class SubcodigosGasto
{
    public int Id { get; set; }

    public int CodigoGastoId { get; set; }

    public string Subcodigo { get; set; } = null!;

    public virtual CodigosGasto CodigoGasto { get; set; } = null!;

    public virtual ICollection<CodigosConceptoConciliacion> CodigosConceptoConciliacions { get; set; } = new List<CodigosConceptoConciliacion>();

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
