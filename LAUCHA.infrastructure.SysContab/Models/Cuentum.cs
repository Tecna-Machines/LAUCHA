namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Cuentum
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int? NroDeRefoPago { get; set; }

    public decimal? Montoenpesos { get; set; }

    public int NroCuenta { get; set; }
}
