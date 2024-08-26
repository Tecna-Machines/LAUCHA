using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.domain.entities;

namespace LAUCHA.application.Mappers
{
    internal class RetencionMapper
    {
        public Retencion GenerarRetencion(CrearRetencionDTO retencionDTO)
        {
            DateTime fechaActual = DateTime.Now;

            return new Retencion
            {
                CodigoRetencion = $"RET:{retencionDTO.NumeroCuenta}{fechaActual.Year}{fechaActual.Hour}{fechaActual.Second}",
                Descripcion = retencionDTO.Descripcion,
                Fecha = fechaActual,
                Monto = retencionDTO.Monto,
                NumeroCuenta = retencionDTO.NumeroCuenta
            };
        }

        public RetencionDTO GenerarRetencionDTO(Retencion retencion)
        {
            return new RetencionDTO
            {
                Codigo = retencion.CodigoRetencion,
                Descripcion = retencion.Descripcion,
                Fecha = retencion.Fecha,
                Monto = retencion.Monto,
                NumeroCuenta = retencion.NumeroCuenta
            };
        }
    }
}
