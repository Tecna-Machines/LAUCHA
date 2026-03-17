namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string Descripcioncompra { get; set; } = null!;

    public string Nombreproveedor { get; set; } = null!;

    public string Nombrerubro { get; set; } = null!;
}
