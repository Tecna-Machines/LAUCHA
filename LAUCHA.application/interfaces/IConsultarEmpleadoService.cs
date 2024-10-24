﻿using LAUCHA.application.DTOs.EmpleadoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarEmpleadoService
    {
        EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado);
        List<EmpleadoDTO> ConsultarTodosLosEmpleados();
    }
}
