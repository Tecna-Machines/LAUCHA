using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class CreditoMapper
    {
        public CreditoDTO GenerarCreditoDTO(Credito credito) 
        {
            List<PagoCreditoDTO> pagosCreditoDTO = new List<PagoCreditoDTO>();
            foreach (PagoCredito pc in credito.PagosCreditos)
            {
                PagoCreditoDTO pagoCreditoDto = new PagoCreditoDTO
                {
                    Descripcion = pc.Descripcion,
                    FechaPago = pc.FechaPago,
                    Monto = pc.Monto,
                };
            }
            CreditoDTO creditoDTO = new CreditoDTO
            {
                CantidadCuotasFaltantes = credito.CantidadCuotasFaltantes,
                Codigo = credito.CodigoCredito,
                Concepto = new ConceptoDTO { Nombre = credito.Concepto.NombreConcepto, Numero = credito.Concepto.NumeroConcepto },
                FechaInicio = credito.FechaInicio,
                MontoCuota = credito.MontoCuota(),
                MontoFaltante = credito.montoFaltante(),
                Pagos = pagosCreditoDTO,
            };
            return creditoDTO;
        }
    }
}
