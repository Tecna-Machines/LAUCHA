using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class AcobrarCccliente
{
    public int Id { get; set; }

    public string Cliente { get; set; } = null!;

    public string Maquina { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Contrato { get; set; } = null!;

    public float Moneda { get; set; }

    public int Monto { get; set; }

    public int? EnUsdOficial { get; set; }

    public string? Descpago { get; set; }
}
