using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Cccliente
{
    public int NroContrato { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public string Moneda { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public string Maquina { get; set; } = null!;

    public int EnDivisas { get; set; }

    public float TcCobro { get; set; }

    public int Cobrado { get; set; }

    public float TcMonCob { get; set; }
}
