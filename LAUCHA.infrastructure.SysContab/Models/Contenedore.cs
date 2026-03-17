namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Contenedore
{
    public int Id { get; set; }

    public string? NombreContenedor { get; set; }

    public string? TipoContenedor { get; set; }

    public string? GrupoContenedor { get; set; }

    public string? GrupoAsignable { get; set; }

    public bool EsAptoCompras { get; set; }

    public virtual ICollection<DiscriminanteContenedor> DiscriminanteContenedors { get; set; } = new List<DiscriminanteContenedor>();

    public virtual ICollection<Operacione> Operaciones { get; set; } = new List<Operacione>();

    public virtual ICollection<Pieza> Piezas { get; set; } = new List<Pieza>();
}
