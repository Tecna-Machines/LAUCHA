using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class PeriodoVacacionRepository : IPeriodoVacacionesRepository
    {
        private readonly LiquidacionesDbContext _context;

        public PeriodoVacacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public PeriodoVacaciones cargarNuevasVacaciones(PeriodoVacaciones vacaciones)
        {
            _context.PeriodoVacaciones.Add(vacaciones);
            _context.SaveChanges();

            vacaciones.Empleado = _context.Empleados.Find(vacaciones.DniEmpleado) 
                                  ?? throw new ArgumentNullException();

            return vacaciones;
        }

        public List<PeriodoVacaciones> obtenerVacacionesDelAnio(int anio)
        {
            return _context.PeriodoVacaciones.Include(v => v.Empleado)
                                             .Where(v => v.FechaInicio.Year == anio)
                                             .ToList();
                                            
        }

        public List<PeriodoVacaciones> obtenerVacacionesEmpleado(string dniEmpleado, int anio)
        {
            return _context.PeriodoVacaciones.
                           Include(v => v.Empleado)
                            .Where(v => v.FechaInicio.Year == anio && v.DniEmpleado == dniEmpleado)
                            .ToList();

        }
    }
}
