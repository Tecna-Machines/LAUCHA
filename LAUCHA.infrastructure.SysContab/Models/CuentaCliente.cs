using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class CuentaCliente
{
    public string? Cliente { get; set; }

    public string? Maquina { get; set; }

    public int Nro { get; set; }

    public string Contrato { get; set; } = null!;

    public string? DescripcionPago { get; set; }

    public int Cobrado { get; set; }

    public int VaríacionCc { get; set; }

    public string? Moneda { get; set; }

    public string? FechaPagocc { get; set; }

    public double Tccobro { get; set; }

    public double Tcmoncont { get; set; }
}
