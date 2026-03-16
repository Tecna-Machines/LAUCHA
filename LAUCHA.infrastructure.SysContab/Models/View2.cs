using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class View2
{
    public int Plano { get; set; }

    public string? Pieza { get; set; }

    public int Cantidad { get; set; }

    public string? Material { get; set; }

    public string? NombreContenedor { get; set; }

    public string? DescripcionDeCompra { get; set; }

    public string? SobreCodigo { get; set; }

    public string? Categoria { get; set; }

    public int? Oc { get; set; }

    public string? NombreEstado { get; set; }

    public string? Pedido { get; set; }

    public string? Entrega { get; set; }
}
