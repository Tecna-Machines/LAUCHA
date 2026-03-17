namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Segguimiento2
{
    public int Id { get; set; }

    public string? NombreCuenta { get; set; }

    public float MontoPesos { get; set; }

    public int? NroCt { get; set; }

    public string? Descripcion { get; set; }

    public float? MontoDolares { get; set; }

    public int? CodigoGastoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreProveedor { get; set; } = null!;

    public string? DescripcionCompra { get; set; }
}
