using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.ModalidadDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    public class ContratoMapper
    {
        public ContratoDTO GenerarContrato(Contrato contrato, Modalidad modalidad,
                                           Empleado empleado,List<Adicional>adicionales,AcuerdoBlanco acuerdoBlanco)
        {   
            List<AdicionalDTO> adicionalesDTOs = new List<AdicionalDTO>();

            ModalidadDTO modalidadDTO = new ModalidadDTO
            {
                Codigo = modalidad.CodigoModalidad,
                Descripcion = modalidad.Descripcion
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
                    Codigo = adicional.CodigoAdicional,
                    Concepto = adicional.Concepto,
                    Cantidad = adicional.Unidades,
                    EsPorcentual = adicional.EsPorcentual
                };

                adicionalesDTOs.Add(nuevoAdicional);
            }

            return new ContratoDTO
            {
                Codigo = contrato.CodigoContrato,
                Dni = empleado.Dni,
                Empleado = $"{empleado.Nombre} {empleado.Apellido}",
                Fecha = contrato.FechaContrato.ToString("dd-MM-yyyy"),
                MontoHora = contrato.MontoPorHora,
                MontoFijo = contrato.MontoFijo,
                Tipo = contrato.TipoContrato,
                Modalidad = modalidadDTO,
                Adicionales = adicionalesDTOs,
                AcuerdoBlanco = acuerdoDTO
            };
        }
    }
}
