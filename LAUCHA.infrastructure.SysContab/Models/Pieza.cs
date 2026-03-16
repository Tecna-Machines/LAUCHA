using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Pieza
{
    public int Id { get; set; }

    public int? MaquinaId { get; set; }

    public int? SubconjuntoId { get; set; }

    public int? NumPieza { get; set; }

    public string? SobreCodigo { get; set; }

    public int? MaterialId { get; set; }

    public int Cantidad { get; set; }

    public int? ContenedorId { get; set; }

    public double? TTorno { get; set; }

    public double? TFresa { get; set; }

    public int? Orden { get; set; }

    public string? Aclaracion { get; set; }

    public int? Prioridad { get; set; }

    public bool? FinMec { get; set; }

    public int? LoteTratamiento { get; set; }

    public string? Estado { get; set; }

    public int? PrioridadFinal { get; set; }

    public byte[]? Foto { get; set; }

    public int? Discriminante { get; set; }

    public string? DescripcionDeCompra { get; set; }

    public string? TipoDePieza { get; set; }

    public string? NombrePieza { get; set; }

    public int? OrdenDeCompraId { get; set; }

    public string? Categoria { get; set; }

    public string? HistorialMovimientos { get; set; }

    public string? EstadoActual { get; set; }

    public string? Estructura { get; set; }

    public string? Material { get; set; }

    public string? Proveedor { get; set; }

    public string? Tratamiento { get; set; }

    public string? Responsable { get; set; }

    public virtual Contenedore? Contenedor { get; set; }

    public virtual Historial? Historial { get; set; }

    public virtual ICollection<ItemsOrdenDeCompra> ItemsOrdenDeCompras { get; set; } = new List<ItemsOrdenDeCompra>();

    public virtual Maquina? Maquina { get; set; }

    public virtual Materiale? MaterialNavigation { get; set; }

    public virtual ICollection<Operacione> Operaciones { get; set; } = new List<Operacione>();

    public virtual OrdenesDeCompra? OrdenDeCompra { get; set; }

    public virtual ICollection<PiezaUbicacion> PiezaUbicacions { get; set; } = new List<PiezaUbicacion>();

    public virtual Subconjunto? Subconjunto { get; set; }
}
