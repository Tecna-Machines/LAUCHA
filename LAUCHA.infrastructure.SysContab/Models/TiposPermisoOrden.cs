namespace LAUCHA.infrastructure.SysContab.Models;

public partial class TiposPermisoOrden
{
    public int Id { get; set; }

    public string NombreTipoPermiso { get; set; } = null!;

    public virtual ICollection<PermisosOrdenDeCompra> PermisosOrdenDeCompras { get; set; } = new List<PermisosOrdenDeCompra>();

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();
}
