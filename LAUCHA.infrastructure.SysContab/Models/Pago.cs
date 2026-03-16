using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Pago
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaPago { get; set; }

    public int? ConciliacionId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Conciliacione? Conciliacione { get; set; }

    public virtual CuentaCorrienteCliente1? CuentaCorrienteCliente1 { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<OrdenesDeCompra> OrdenesDeCompras { get; set; } = new List<OrdenesDeCompra>();

    public virtual Usuario? Usuario { get; set; }
}
