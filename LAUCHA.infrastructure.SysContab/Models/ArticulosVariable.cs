namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ArticulosVariable
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int Rubroid { get; set; }

    public string NombreArticulo { get; set; } = null!;

    public string DescripcionGenerica { get; set; } = null!;

    public byte[] DataTable { get; set; } = null!;

    public string FormulaPrecio { get; set; } = null!;

    public int? Dto { get; set; }

    public double? Iva { get; set; }

    public bool? PrecioEnDolares { get; set; }

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual Rubro Rubro { get; set; } = null!;

    public virtual ICollection<CodigosGastoFinal> CodigoGastoFinals { get; set; } = new List<CodigosGastoFinal>();
}
