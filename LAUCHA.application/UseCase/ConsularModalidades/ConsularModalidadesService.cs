using LAUCHA.application.DTOs.ModalidadDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsularModalidades
{
    public class ConsultarModalidadesService : IConsultarModalidadesService
    {
        private readonly IGenericRepository<Modalidad> _ModalidadRepository;

        public ConsultarModalidadesService(IGenericRepository<Modalidad> modalidadRepository)
        {
            _ModalidadRepository = modalidadRepository;
        }

        public List<ModalidadDTO> ObtenerTodasLasModalidades()
        {
            List<Modalidad> modalidades = _ModalidadRepository.GetAll().ToList();
            List<ModalidadDTO> modalidadesDTOs = new();

            foreach (var modalidad in modalidades)
            {
                var modalidadDTO = new ModalidadDTO
                {
                    Codigo = modalidad.CodigoModalidad,
                    Descripcion = modalidad.Descripcion
                };

                modalidadesDTOs.Add(modalidadDTO);
            }

            return modalidadesDTOs;
        }
    }
}
