using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class ValoresDolar
{
    public int Id { get; set; }

    public double ValorDolar { get; set; }

    public int UsuarioResponsableid { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Usuario UsuarioResponsable { get; set; } = null!;
}
