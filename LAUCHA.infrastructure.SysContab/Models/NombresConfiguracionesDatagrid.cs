using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class NombresConfiguracionesDatagrid
{
    public int Id { get; set; }

    public string NombreConfiguracion { get; set; } = null!;

    public string NombreDgSegunTipoDeDatosAsociados { get; set; } = null!;
}
