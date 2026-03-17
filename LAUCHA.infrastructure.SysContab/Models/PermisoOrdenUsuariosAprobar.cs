namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PermisoOrdenUsuariosAprobar
{
    public int PermisosOrdenId { get; set; }

    public int UsuarioId { get; set; }

    public int? PermisoOrdenDeCompraid { get; set; }

    public int Id { get; set; }

    public virtual PermisosOrdenDeCompra? PermisoOrdenDeCompra { get; set; }

    public virtual PermisosOrdenDeCompra PermisosOrden { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
