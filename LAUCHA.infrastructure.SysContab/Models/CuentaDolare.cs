namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CuentaDolare
{
    public int Id { get; set; }

    public int Monto { get; set; }

    public int TipoDeCambio { get; set; }

    public bool EsCompra { get; set; }
}
