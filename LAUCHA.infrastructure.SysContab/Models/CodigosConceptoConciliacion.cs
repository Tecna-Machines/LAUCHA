namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CodigosConceptoConciliacion
{
    public int Id { get; set; }

    public int? CuentaId { get; set; }

    public string? Concepto15Chars { get; set; }

    public string? CodigoConcepto { get; set; }

    public bool? EsGastoDirecto { get; set; }

    public int? CodigoGastoId { get; set; }

    public int? SubodigoGastoId { get; set; }

    public virtual CodigosGasto? CodigoGasto { get; set; }

    public virtual Cuenta? Cuenta { get; set; }

    public virtual ICollection<DatosBancoAconciliar> DatosBancoAconciliars { get; set; } = new List<DatosBancoAconciliar>();

    public virtual SubcodigosGasto? SubodigoGasto { get; set; }
}
