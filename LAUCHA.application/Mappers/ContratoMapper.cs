using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.ModalidadDTOs;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Mappers
{
    public class ContratoMapper
    {
        public ContratoDTO GenerarContrato(Acuerdo contrato, TipoSueldo modalidad,
                                           Empleado empleado, List<Adicional> adicionales, AcuerdoBlanco acuerdoBlanco)
        {
            List<AdicionalDTO> adicionalesDTOs = new List<AdicionalDTO>();

            ModalidadDTO modalidadDTO = new ModalidadDTO
            {
                Codigo = modalidad.ToString(),
                Descripcion = modalidad.ToString()
            };

            AcuerdoBlancoDTO acuerdoDTO = new AcuerdoBlancoDTO
            {
                Cantidad = acuerdoBlanco.Unidades,
                Concepto = acuerdoBlanco.Concepto,
                EsPorcentual = acuerdoBlanco.EsPorcentual
            };

            foreach (var adicional in adicionales)
            {
                var nuevoAdicional = new AdicionalDTO
                {
                    Codigo = adicional.Codigo,
                    Concepto = adicional.Concepto,
                    Cantidad = adicional.Monto,
                    EsPorcentual = adicional.EsPorcentual
                };

                adicionalesDTOs.Add(nuevoAdicional);
            }

            return new ContratoDTO
            {
                Codigo = contrato.Codigo,
                Dni = empleado.Dni,
                Empleado = $"{empleado.Nombre} {empleado.Apellido}",
                Fecha = contrato.Fecha.ToString("dd-MM-yyyy"),
                MontoHora = contrato.ValorHora,
                MontoFijo = contrato.Sueldo,
                Tipo = "contrato.TipoContrato",
                Modalidad = modalidadDTO,
                Adicionales = adicionalesDTOs,
                AcuerdoBlanco = acuerdoDTO
            };
        }
    }
}
