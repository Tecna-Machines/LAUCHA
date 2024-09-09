using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

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
            _context.HabilitacionHorasExtra.Add(habilitacion);
            _context.SaveChanges();

            habilitacion.Empleado = _context.Empleados.Find(habilitacion.DniEmpleado) ?? throw new ArgumentNullException();
            habilitacion.Responsable = _context.Empleados.Find(habilitacion.DniResponsable) ?? throw new ArgumentNullException();

            return habilitacion;
        }

        public List<HabilitacionHorasExtra> obtenerHabilitacionEmpleado(string dniEmpleado)
        {
            return _context.HabilitacionHorasExtra
                            .Include(he => he.Empleado)
                            .Include(he => he.Responsable)
                            .Where(he => he.Equals(dniEmpleado)).ToList();
        }

        public List<HabilitacionHorasExtra> obtenerHabilitacionesEmpleadoPeriodo(string dniEmpleado,
                                                                                 DateTime fechaInicio,
                                                                                 DateTime fechaFin)
        {
            return _context.HabilitacionHorasExtra
                            .Include(he => he.Empleado)
                            .Include(he => he.Responsable)
                            .Where(hs => hs.DniEmpleado == dniEmpleado
                            && hs.FechaInicio >= fechaInicio
                            && hs.FechaFin <= fechaFin)
                            .ToList();
        }
    }
}
