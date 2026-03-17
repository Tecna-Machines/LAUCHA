namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Configuracione
{
    public int Id { get; set; }

    public string TagDatagrid { get; set; } = null!;

    public byte[] MapConfig { get; set; } = null!;
}
