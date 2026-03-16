using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class OrdenesDeCompra
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int? PermisoOrdenId { get; set; }

    public DateTime FechaDeGeneracion { get; set; }

    public string? Observacion { get; set; }

    public int OrdenOriginalId { get; set; }

    public bool? Pagada { get; set; }

    public int? PagoNro { get; set; }

    public int? PagoId { get; set; }

    public string Factura { get; set; } = null!;

    public string Remito { get; set; } = null!;

    public bool? Eliminada { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual ICollection<OrdenDeCompraEstadoCompra> OrdenDeCompraEstadoCompras { get; set; } = new List<OrdenDeCompraEstadoCompra>();

    public virtual Pago? Pago { get; set; }

    public virtual PermisosOrdenDeCompra? PermisoOrden { get; set; }

    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
