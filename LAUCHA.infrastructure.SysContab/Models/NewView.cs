namespace LAUCHA.infrastructure.SysContab.Models;

public partial class NewView
{
    public int Id { get; set; }

    public int PagoNro { get; set; }

    public string TipoPago { get; set; } = null!;

    public int CuentaId { get; set; }

    public double MontoPesos { get; set; }

    public double? ValorMonedaOrien { get; set; }

    public int? CodigoGastoId { get; set; }

    public string? Descripcion { get; set; }

    public int? NroCt { get; set; }

    public DateTime? FechaCt { get; set; }

    public bool ChequeUsado { get; set; }

    public int? SubcodigoGastoId { get; set; }

    public int? NroInterno { get; set; }

    public int IdMovOrigen { get; set; }

    public int? ClienteId { get; set; }

    public DateTime FechaGeneracion { get; set; }

    public double? MontoDolares { get; set; }

    public bool MontoEnDolares { get; set; }

    public int? SubcodigoGasto2Id { get; set; }

    public double? ValorMonedaDestino { get; set; }

    public int? PagoId { get; set; }

    public int? SubconciliacionId { get; set; }
}
