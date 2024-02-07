using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface ICrearEmpleadoService
    {
        EmpleadoDTO CargarNuevoEmpleado(CrearEmpleadoDTO nuevoEmpleado);
    }
}
