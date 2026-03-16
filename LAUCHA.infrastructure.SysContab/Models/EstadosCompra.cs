using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class EstadosCompra
{
    public int Id { get; set; }

    public int Orden { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<OrdenDeCompraEstadoCompra> OrdenDeCompraEstadoCompras { get; set; } = new List<OrdenDeCompraEstadoCompra>();
}
