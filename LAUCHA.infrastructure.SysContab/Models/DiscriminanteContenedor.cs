namespace LAUCHA.infrastructure.SysContab.Models;

public partial class DiscriminanteContenedor
{
    public int Id { get; set; }

    public int Discriminante { get; set; }

    public int ContenedorId { get; set; }

    public virtual Contenedore Contenedor { get; set; } = null!;
}
