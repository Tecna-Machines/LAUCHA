namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Conciliacione
{
    public int Id { get; set; }

    public DateTime FechaGeneracion { get; set; }

    public int? PagoId { get; set; }

    public virtual Pago? Pago { get; set; }

    public virtual ICollection<Subconciliacione> Subconciliaciones { get; set; } = new List<Subconciliacione>();
}
