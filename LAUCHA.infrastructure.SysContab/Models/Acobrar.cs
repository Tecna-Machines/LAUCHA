namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Acobrar
{
    public int Id { get; set; }

    public string Cliente { get; set; } = null!;

    public string Maquina { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public float Moneda { get; set; }

    public int? EnUsdOficial { get; set; }
}
