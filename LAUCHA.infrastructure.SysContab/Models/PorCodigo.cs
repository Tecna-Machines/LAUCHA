namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PorCodigo
{
    public string Codigo { get; set; } = null!;

    public double? TotCod { get; set; }

    public string NombreMoneda { get; set; } = null!;

    public float ValorActual { get; set; }
}
