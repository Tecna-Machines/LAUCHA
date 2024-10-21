using LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces.V2.IDiasEspecialesServices
{
    public interface ICrearConsultarVacacionesService
    {
        RespuestaVacacionesDTO crearNuevaVacacion(CrearVacacionesDTO vacaciones);
        List<RespuestaVacacionesDTO> obtenerVacacionesEmpleado(string dni, int? anio);
        List<RespuestaVacacionesDTO> obtenerVacacionesAnio(int? anio);
    }
}
