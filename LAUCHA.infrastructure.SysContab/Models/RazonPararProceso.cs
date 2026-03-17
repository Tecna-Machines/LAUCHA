namespace LAUCHA.infrastructure.SysContab.Models;

public partial class RazonPararProceso
{
    public int Id { get; set; }

    public string Razon { get; set; } = null!;

    public virtual ICollection<Operacione> Operaciones { get; set; } = new List<Operacione>();
}
