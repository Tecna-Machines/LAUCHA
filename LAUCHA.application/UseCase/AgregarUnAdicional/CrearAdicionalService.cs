using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.AgregarUnAdicional
{
    internal class CrearAdicionalService: ICrearAdicionalService
    {
        private readonly IGenericRepository<Adicional> _repository;

        public CrearAdicionalService(IGenericRepository<Adicional> repository)
        {
            _repository = repository;
        }

        public AdicionalDTO CrearNuevoAdicional(AdicionalDTO nuevoAdicional)
        {
            Adicional adicional = new Adicional
            {
                CodigoAdicional = nuevoAdicional.Codigo,
                Concepto = nuevoAdicional.Concepto,
                EsPorcentual = nuevoAdicional.EsPorcentual,
                Unidades = nuevoAdicional.Cantidad
            };

            adicional = _repository.Insert(adicional);

            return new AdicionalDTO
            {
                Codigo = adicional.CodigoAdicional,
                Cantidad = adicional.Unidades,
                Concepto = adicional.Concepto,
                EsPorcentual = adicional.EsPorcentual
            };
        }
    }
}
