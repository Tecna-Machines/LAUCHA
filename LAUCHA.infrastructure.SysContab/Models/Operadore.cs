namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Operadore
{
    public int Id { get; set; }

    public string NombreOperador { get; set; } = null!;

    public virtual ICollection<Operacione> Operaciones { get; set; } = new List<Operacione>();
}
