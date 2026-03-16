using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Cobro
{
    public int? Año { get; set; }

    public int? Mes { get; set; }

    public string Maquina { get; set; } = null!;

    public int Nro { get; set; }

    public decimal? EnMonCtrto { get; set; }

    public string Nombremoneda { get; set; } = null!;
}
