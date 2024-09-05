using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class HabilitacionHorasExtraRepository : IHabilitacionHorasExtraRepository
    {
        private readonly LiquidacionesDbContext _context;

        public HabilitacionHorasExtraRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public HabilitacionHorasExtra cargarNuevaHabilitacionHsExtra(HabilitacionHorasExtra habilitacion)
        {
            throw new NotImplementedException();
        }

        public List<HabilitacionHorasExtra> obtenerHabilitacionEmpleado(string dniEmpleado)
        {
            return _context.HabilitacionHorasExtra.Where(he => he.Equals(dniEmpleado)).ToList();
        }

        public List<HabilitacionHorasExtra> obtenerHabilitacionesEmpleadoPeriodo(string dniEmpleado,
                                                                                 DateTime fechaInicio,
                                                                                 DateTime fechaFin)
        {
            return _context.HabilitacionHorasExtra.Where(hs => hs.DniEmpleado == dniEmpleado
                && hs.FechaInicio >= fechaInicio 
                && hs.FechaFin <= fechaFin) 
                .ToList();
        }
    }
}
