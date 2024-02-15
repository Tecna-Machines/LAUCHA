using LAUCHA.application.DTOs.DescuentoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IOperarDescuentosService
    {
        DescuentoDTO CrearUnDescuentoNuevo(CrearDescuentoDTO nuevoDescuentoDTO);
    }
}
