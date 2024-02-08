using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarRetencionesFijasService
    {
        RetencionFijaDTO ConsultarUnaRetencionFija(string codigoRetencion);
        List<RetencionFijaDTO> ConsultarRetencionesFijas();
    }
}
