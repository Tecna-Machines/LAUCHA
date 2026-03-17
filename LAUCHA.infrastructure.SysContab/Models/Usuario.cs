namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreDeUsuario { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public virtual ICollection<ContratosTrabajo> ContratosTrabajos { get; set; } = new List<ContratosTrabajo>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<OrdenDeCompraEstadoCompra> OrdenDeCompraEstadoCompras { get; set; } = new List<OrdenDeCompraEstadoCompra>();

    public virtual ICollection<PagoSueldosManual> PagoSueldosManuals { get; set; } = new List<PagoSueldosManual>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PermisoOrdenUsuariosAprobar> PermisoOrdenUsuariosAprobars { get; set; } = new List<PermisoOrdenUsuariosAprobar>();

    public virtual ICollection<PermisoOrdenUsuariosRevisar> PermisoOrdenUsuariosRevisars { get; set; } = new List<PermisoOrdenUsuariosRevisar>();

    public virtual ICollection<ValoresDolar> ValoresDolars { get; set; } = new List<ValoresDolar>();
}
