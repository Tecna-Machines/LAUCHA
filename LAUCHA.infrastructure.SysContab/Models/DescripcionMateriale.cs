using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class DescripcionMateriale
{
    public int Id { get; set; }

    public string NombreMaterial { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
