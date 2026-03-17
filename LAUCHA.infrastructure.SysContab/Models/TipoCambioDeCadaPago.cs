namespace LAUCHA.infrastructure.SysContab.Models;

public partial class TipoCambioDeCadaPago
{
    public int Id { get; set; }

    public int IdMovOrigen { get; set; }

    public string? NombreCuenta { get; set; }

    public float MontoPesos { get; set; }

    public string? Descripcion { get; set; }

    public float? ValorMonedaDestino { get; set; }

    public float? ValorMonedaOrien { get; set; }

    public DateTime FechaGeneracion { get; set; }

    public int? PagoId { get; set; }

    public int PagoNro { get; set; }
}
