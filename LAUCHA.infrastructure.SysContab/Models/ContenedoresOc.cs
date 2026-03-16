using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ContenedoresOc
{
    public int Id { get; set; }

    public string NombreContenedor { get; set; } = null!;

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();
}
