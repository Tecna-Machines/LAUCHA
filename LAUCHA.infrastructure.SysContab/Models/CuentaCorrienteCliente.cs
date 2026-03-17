namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CuentaCorrienteCliente
{
    public int NroContrato { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public string Moneda { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public string Maquina { get; set; } = null!;

    public int? Monto { get; set; }
}
