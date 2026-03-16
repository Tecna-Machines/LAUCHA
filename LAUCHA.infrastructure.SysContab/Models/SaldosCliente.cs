using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class SaldosCliente
{
    public int? TotDeuda { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Nombremoneda { get; set; } = null!;
}
