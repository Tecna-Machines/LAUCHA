using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PermisosOrdenDeCompra
{
    public int Id { get; set; }

    public int? TipoPermisoOrdenId { get; set; }

    public int MontoMinimoDolares { get; set; }

    public string RestriccionRevisar { get; set; } = null!;

    public string RestriccionAprobar { get; set; } = null!;

    public virtual ICollection<OrdenesDeCompra> OrdenesDeCompras { get; set; } = new List<OrdenesDeCompra>();

    public virtual ICollection<PermisoOrdenUsuariosAprobar> PermisoOrdenUsuariosAprobarPermisoOrdenDeCompras { get; set; } = new List<PermisoOrdenUsuariosAprobar>();

    public virtual ICollection<PermisoOrdenUsuariosAprobar> PermisoOrdenUsuariosAprobarPermisosOrdens { get; set; } = new List<PermisoOrdenUsuariosAprobar>();

    public virtual ICollection<PermisoOrdenUsuariosRevisar> PermisoOrdenUsuariosRevisarPermisoOrdenDeCompras { get; set; } = new List<PermisoOrdenUsuariosRevisar>();

    public virtual ICollection<PermisoOrdenUsuariosRevisar> PermisoOrdenUsuariosRevisarPermisosOrdens { get; set; } = new List<PermisoOrdenUsuariosRevisar>();

    public virtual TiposPermisoOrden? TipoPermisoOrden { get; set; }
}
