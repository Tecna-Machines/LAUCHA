using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsultarAdicionales
{
    public class ConsultarAdicionales: IConsultarAdicionalesService
    {   
        private readonly IGenericRepository<Adicional> _repository;

        public ConsultarAdicionales(IGenericRepository<Adicional> repository)
        {
            _repository = repository;
        }

        public AdicionalDTO ObtenerAdicionalPorCodigo(string codigoAdicional)
        {
            Adicional adicionalConsultado = _repository.GetById(codigoAdicional);

            return new AdicionalDTO
            {
                Codigo = adicionalConsultado.CodigoAdicional,
                Cantidad = adicionalConsultado.Unidades,
                Concepto = adicionalConsultado.Concepto,
                EsPorcentual = adicionalConsultado.EsPorcentual
            };
        }

        public List<AdicionalDTO> ObtenerTodosLosAdicionales()
        {
            List<Adicional> adicionales = _repository.GetAll().ToList();
            List<AdicionalDTO> adicionalDTOs = new List<AdicionalDTO>();

            foreach (var adicional in adicionales)
            {
                var adicionalMapeado = new AdicionalDTO
                {
                    Codigo = adicional.CodigoAdicional,
                    Cantidad = adicional.Unidades,
                    Concepto = adicional.Concepto,
                    EsPorcentual = adicional.EsPorcentual
                };

                adicionalDTOs.Add(adicionalMapeado);
            }

            return adicionalDTOs;
        }
    }
}
