namespace LAUCHA.infrastructure.SysContab.Models;

public partial class DatosBancoAconciliar
{
    public int Id { get; set; }

    public int? CuentaId { get; set; }

    public int? CodigoConceptoId { get; set; }

    public string Concepto { get; set; } = null!;

    public int? Referencia { get; set; }

    public double? Monto { get; set; }

    public double? Saldo { get; set; }

    public DateTime? Fecha { get; set; }

    public int? SubconciliacionId { get; set; }

    public virtual CodigosConceptoConciliacion? CodigoConcepto { get; set; }

    public virtual Cuenta? Cuenta { get; set; }

    public virtual Subconciliacione? Subconciliacion { get; set; }
}
