using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ConciliacionesVerificar
{
    public int? SubConciliacion { get; set; }

    public int? TotMontoDatosBco { get; set; }

    public int? TotMontoContab { get; set; }

    public int? Diferencia { get; set; }

    public int? Conciliacion { get; set; }

    public string? FechaConciliacion { get; set; }

    public int? PagoNro { get; set; }
}
