using System;
using System.Collections.Generic;

namespace LAUCHA.infrastructure.SysContab.Models;

public partial class Seguimiento2
{
    public int Id { get; set; }

    public int PagoNro { get; set; }

    public string TipoPago { get; set; } = null!;

    public string NombreCuenta { get; set; } = null!;

    public float MontoPesos { get; set; }

    public float? ValorMonedaOrien { get; set; }

    public int? CodigoGastoId { get; set; }

    public int? NroCt { get; set; }

    public DateTime? FechaCt { get; set; }

    public int? SubcodigoGastoId { get; set; }

    public int? PagoId { get; set; }

    public string Descripcion { get; set; } = null!;
}
