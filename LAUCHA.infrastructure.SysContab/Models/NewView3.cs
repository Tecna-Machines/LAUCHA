using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class NewView3
{
    public string Ubic { get; set; } = null!;

    public int Cant { get; set; }

    public string? Pieza { get; set; }

    public int? MaquinaId { get; set; }
}
