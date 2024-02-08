using LAUCHA.application.DTOs.ContratoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface ICrearContratoService
    {
        ContratoDTO CrearNuevoContrato(CrearContratoDTO nuevoContrato);
    }
}
