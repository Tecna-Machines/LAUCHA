namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ItemsOrdenDeCompra
{
    public int Id { get; set; }

    public int? OrdenDeCompraId { get; set; }

    public int? OrdenOriginalId { get; set; }

    public string? Origen { get; set; }

    public int? OrigenId { get; set; }

    public int? PiezaId { get; set; }

    public int? ArticuloId { get; set; }

    public int? ArticuloVariableId { get; set; }

    public string? DescripcionCompra { get; set; }

    public int Cantidad { get; set; }

    public double PrecioDolares { get; set; }

    public double PrecioPesos { get; set; }

    public double? TipoDeCambio { get; set; }

    public double Iva { get; set; }

    public double Dto { get; set; }

    public bool AgrupaPago { get; set; }

    public int CodigoPago { get; set; }

    public string? Remito { get; set; }

    public string? Factura { get; set; }

    public string? Observacion { get; set; }

    public int? ContenedorId { get; set; }

    public int? CodigoGastoId { get; set; }

    public int? SubcodigoGastoId { get; set; }

    public bool? PrecioEnDolares { get; set; }

    public int? SubcodigoGasto2Id { get; set; }

    public virtual OtrosArticulo? Articulo { get; set; }

    public virtual ArticulosVariable? ArticuloVariable { get; set; }

    public virtual CodigosGasto? CodigoGasto { get; set; }

    public virtual ContenedoresOc? Contenedor { get; set; }

    public virtual OrdenesDeCompra? OrdenDeCompra { get; set; }

    public virtual Pieza? Pieza { get; set; }

    public virtual SubcodigosGasto? SubcodigoGasto { get; set; }

    public virtual Rubro? SubcodigoGasto2 { get; set; }

    public virtual ICollection<CodigosGastoFinal> CodigoGastoFinals { get; set; } = new List<CodigosGastoFinal>();
}
