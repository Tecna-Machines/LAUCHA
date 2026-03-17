namespace LAUCHA.infrastructure.SysContab.Models;

public partial class RastreoPiezas2
{
    public int Id { get; set; }

    public string? NombrePieza { get; set; }

    public string? NombreContenedor { get; set; }

    public string? Tipodepieza { get; set; }

    public string? Descripciondecompra { get; set; }

    public string Material { get; set; } = null!;
}
