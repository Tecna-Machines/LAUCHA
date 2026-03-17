namespace LAUCHA.infrastructure.SysContab.Models;

public partial class NomenclaturaDiscriminante
{
    public int Id { get; set; }

    public string Nomenclatura { get; set; } = null!;

    public int Discriminante { get; set; }
}
