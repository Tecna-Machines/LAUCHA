namespace LAUCHA.infrastructure.SysContab.Models;

public partial class OtrosArticulo
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int Rubroid { get; set; }

    public string DescripcionCompra { get; set; } = null!;

    public string? TipoCompra { get; set; }

    public double PrecioPesos { get; set; }

    public double PrecioDolares { get; set; }

    public double Dto { get; set; }

    public double Iva { get; set; }

    public DateTime FechaGeneracion { get; set; }

    public bool? EnDesuso { get; set; }

    public bool? PrecioEnDolares { get; set; }

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual Rubro Rubro { get; set; } = null!;

    public virtual ICollection<CodigosGastoFinal> CodigoGastoFinals { get; set; } = new List<CodigosGastoFinal>();
}
