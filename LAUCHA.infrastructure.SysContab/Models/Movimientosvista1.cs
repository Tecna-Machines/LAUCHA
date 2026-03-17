namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Movimientosvista1
{
    public int Id { get; set; }

    public float Montopesos { get; set; }

    public string? Descripcion { get; set; }

    public string NombreCuenta { get; set; } = null!;
}
