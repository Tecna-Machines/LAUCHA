namespace LAUCHA.infrastructure.SysContab.Models;

public partial class PagoSueldosManual
{
    public int Id { get; set; }

    public int HsComunes { get; set; }

    public int HsExtras { get; set; }

    public int HsDobles { get; set; }

    public int ValorHora { get; set; }

    public int ValorMes { get; set; }

    public int MontoTotalBruto { get; set; }

    public int Ausentes { get; set; }

    public int Tardes { get; set; }

    public int RetencionesTot { get; set; }

    public int Bolisllo { get; set; }

    public int? EmpleadoId { get; set; }

    public virtual Usuario? Empleado { get; set; }
}
