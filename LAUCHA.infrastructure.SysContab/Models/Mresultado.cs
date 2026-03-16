using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Mresultado
{
    public string? CodigoGasto { get; set; }

    public string? Maquina { get; set; }

    public int? Venta { get; set; }

    public int? Gastado { get; set; }

    public int? Agastarorigen { get; set; }

    public int? FaltaGastar { get; set; }
}
