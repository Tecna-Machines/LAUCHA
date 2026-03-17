namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public int? TipoPermisoOrdenId { get; set; }

    public virtual ICollection<ArticulosVariable> ArticulosVariables { get; set; } = new List<ArticulosVariable>();

    public virtual ICollection<OrdenesDeCompra> OrdenesDeCompras { get; set; } = new List<OrdenesDeCompra>();

    public virtual ICollection<OtrosArticulo> OtrosArticulos { get; set; } = new List<OtrosArticulo>();

    public virtual TiposPermisoOrden? TipoPermisoOrden { get; set; }

    public virtual ICollection<Rubro> Rubros { get; set; } = new List<Rubro>();
}
