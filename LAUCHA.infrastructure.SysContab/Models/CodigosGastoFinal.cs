using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CodigosGastoFinal
{
    public int Id { get; set; }

    public int OrigenId { get; set; }

    public string CodigoGastoFinal { get; set; } = null!;

    public virtual ICollection<ArticulosVariable> ArticuloVariables { get; set; } = new List<ArticulosVariable>();

    public virtual ICollection<ItemsOrdenDeCompra> ItemOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual ICollection<OtrosArticulo> OtroArticulos { get; set; } = new List<OtrosArticulo>();
}
