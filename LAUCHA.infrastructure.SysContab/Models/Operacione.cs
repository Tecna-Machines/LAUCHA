using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Operacione
{
    public int Id { get; set; }

    public int PiezaId { get; set; }

    public int ContenedorId { get; set; }

    public DateTime FechaIniComputada { get; set; }

    public DateTime FechaIni { get; set; }

    public DateTime FechaFin { get; set; }

    public double TMec { get; set; }

    public double TAjustado { get; set; }

    public string? Aclaracion { get; set; }

    public double TProgresoTotal { get; set; }

    public double TiempoOperacion { get; set; }

    public double TRealTotal { get; set; }

    public int? OperadorId { get; set; }

    public int? MotivoId { get; set; }

    public double TFresa { get; set; }

    public double TTorno { get; set; }

    public bool Finalizada { get; set; }

    public virtual Contenedore Contenedor { get; set; } = null!;

    public virtual RazonPararProceso? Motivo { get; set; }

    public virtual Operadore? Operador { get; set; }

    public virtual Pieza Pieza { get; set; } = null!;
}
