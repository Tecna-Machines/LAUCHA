namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ContratosTrabajo
{
    public int Id { get; set; }

    public int MaquinaId { get; set; }

    public string CodigoContrato { get; set; } = null!;

    public int? CodigoGastoId { get; set; }

    public int? CodigoPagoId { get; set; }

    public int PrecioTrabajoPesos { get; set; }

    public bool? PrecioEnDolares { get; set; }

    public int PrecioTrabajoDolares { get; set; }

    public int TipoDeCambio { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? MonedaId { get; set; }

    public int AGastar { get; set; }

    public int? UsuarioId { get; set; }

    public virtual CodigosGasto? CodigoGasto { get; set; }

    public virtual CodigosGasto? CodigoPago { get; set; }

    public virtual ICollection<CuentaCorrienteCliente1> CuentaCorrienteCliente1s { get; set; } = new List<CuentaCorrienteCliente1>();

    public virtual Maquina Maquina { get; set; } = null!;

    public virtual Moneda? Moneda { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
