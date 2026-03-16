using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Rubro
{
    public int Id { get; set; }

    public string NombreRubro { get; set; } = null!;

    public virtual ICollection<ArticulosVariable> ArticulosVariables { get; set; } = new List<ArticulosVariable>();

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<OtrosArticulo> OtrosArticulos { get; set; } = new List<OtrosArticulo>();

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();
}
