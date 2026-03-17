namespace LAUCHA.infrastructure.SysContab.Models;

public partial class OrdenDeCompraEstadoCompra
{
    public int Id { get; set; }

    public int OrdenDeCompraId { get; set; }

    public int EstadoCompraId { get; set; }

    public int? ResponsableId { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public bool EsValido { get; set; }

    public virtual EstadosCompra EstadoCompra { get; set; } = null!;

    public virtual OrdenesDeCompra OrdenDeCompra { get; set; } = null!;

    public virtual Usuario? Responsable { get; set; }
}
