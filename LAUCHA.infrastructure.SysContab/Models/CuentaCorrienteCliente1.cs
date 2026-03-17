namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CuentaCorrienteCliente1
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int MontoMonedaContrato { get; set; }

    public int? MovimientoId { get; set; }

    public DateTime Fecha { get; set; }

    public int MontoMonedaCobro { get; set; }

    public int ContratoTrabajoId { get; set; }

    public double ValorMonedaCobro { get; set; }

    public double ValorMonedaContratoTrabajo { get; set; }

    public int PagoNro { get; set; }

    public int? PagoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ContratosTrabajo ContratoTrabajo { get; set; } = null!;

    public virtual Movimiento? Movimiento { get; set; }

    public virtual Pago? Pago { get; set; }
}
