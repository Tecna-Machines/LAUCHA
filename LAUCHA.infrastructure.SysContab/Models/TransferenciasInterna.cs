using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class TransferenciasInterna
{
    public int? DesdeId { get; set; }

    public int HaciaId { get; set; }

    public string? FechaTrasf { get; set; }

    public int? MontoEnviado { get; set; }

    public string EnviadoEn { get; set; } = null!;

    public double? TcO { get; set; }

    public int? MontoRecibido { get; set; }

    public string RecibidoEn { get; set; } = null!;

    public double? TcD { get; set; }

    public string? Descripcion { get; set; }

    public string Desde { get; set; } = null!;

    public string Hacia { get; set; } = null!;
}
