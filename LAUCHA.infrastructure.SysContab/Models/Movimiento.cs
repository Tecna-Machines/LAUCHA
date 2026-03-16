using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Movimiento
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

    public bool? MontoEnDolares { get; set; }

    public int? SubcodigoGasto2Id { get; set; }

    public double? ValorMonedaDestino { get; set; }

    public int? PagoId { get; set; }

    public int? SubconciliacionId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual CodigosGasto? CodigoGasto { get; set; }

    public virtual Cuenta Cuenta { get; set; } = null!;

    public virtual ICollection<CuentaCorrienteCliente1> CuentaCorrienteCliente1s { get; set; } = new List<CuentaCorrienteCliente1>();

    public virtual Pago? Pago { get; set; }

    public virtual SubcodigosGasto? SubcodigoGasto { get; set; }

    public virtual Rubro? SubcodigoGasto2 { get; set; }

    public virtual Subconciliacione? Subconciliacion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
