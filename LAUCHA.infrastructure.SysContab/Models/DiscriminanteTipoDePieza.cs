namespace LAUCHA.infrastructure.SysContab.Models;

public partial class DiscriminanteTipoDePieza
{
    public int Id { get; set; }

    public int Discriminante { get; set; }

    public string TipoDePieza { get; set; } = null!;
}
