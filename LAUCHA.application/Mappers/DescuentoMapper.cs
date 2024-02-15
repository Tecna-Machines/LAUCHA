using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class DescuentoMapper
    {
        public DescuentoDTO CrearDescuentoDTO(Descuento descuento,Concepto? concepto)
        {
            ConceptoDTO conceptoDTO = new();

            if (concepto != null)
            {
                conceptoDTO = new ConceptoDTO
                {
                    Numero = concepto.NumeroConcepto,
                    Nombre = concepto.NombreConcepto
                };
            } 

            return new DescuentoDTO
            {
                Codigo = descuento.CodigoDescuento,
                Descripcion = descuento.Descripcion,
                Concepto = conceptoDTO,
                Fecha = descuento.Fecha,
                Monto = descuento.Monto,
                NumeroCuenta = descuento.NumeroCuenta
            };
        }

        public Descuento CrearDescuento(CrearDescuentoDTO descuentoDTO)
        {
            DateTime fechaActual = DateTime.Now;

            return new Descuento
            {
                CodigoDescuento = $"D:{descuentoDTO.NumeroCuenta}/{fechaActual.Minute}{fechaActual.Second}",
                Descripcion = descuentoDTO.Descripcion,
                NumeroConcepto = descuentoDTO.NumeroConcepto,
                NumeroCuenta = descuentoDTO.NumeroCuenta,
                Fecha =  fechaActual,
                Monto = descuentoDTO.Monto
            };
        }
    }
}
