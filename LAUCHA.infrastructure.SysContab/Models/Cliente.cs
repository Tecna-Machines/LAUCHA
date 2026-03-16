using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string CodigoCliente { get; set; } = null!;

    public int Cuit { get; set; }

    public virtual ICollection<CuentaCorrienteCliente1> CuentaCorrienteCliente1s { get; set; } = new List<CuentaCorrienteCliente1>();

    public virtual ICollection<Maquina> Maquinas { get; set; } = new List<Maquina>();

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
