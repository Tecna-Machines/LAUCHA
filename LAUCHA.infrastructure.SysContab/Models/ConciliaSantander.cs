namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ConciliaSantander
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Descrip { get; set; }

    public int? Referencia { get; set; }

    public int? Mont { get; set; }

    public int? Subconciliacionid { get; set; }
}
