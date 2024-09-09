using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.AgregarUnAdicional
{
    public class CrearAdicionalService : ICrearAdicionalService
    {
        private readonly IGenericRepository<Adicional> _repository;
        private readonly ILogsApp log;

        public CrearAdicionalService(IGenericRepository<Adicional> repository, ILogsApp log)
        {
            _repository = repository;
            this.log = log;
        }

        public AdicionalDTO CrearNuevoAdicional(AdicionalDTO nuevoAdicional)
        {
            log.LogInformation("creando nuevo adicional: {adi}", nuevoAdicional.Concepto);

            Adicional adicional = new Adicional
            {
                CodigoAdicional = nuevoAdicional.Codigo,
                Concepto = nuevoAdicional.Concepto,
                EsPorcentual = nuevoAdicional.EsPorcentual,
                Unidades = nuevoAdicional.Cantidad
            };

            adicional = _repository.Insert(adicional);

            log.LogInformation("se creo el adicional exitosamente");

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
