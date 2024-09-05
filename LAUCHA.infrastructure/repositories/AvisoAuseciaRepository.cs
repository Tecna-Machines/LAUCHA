using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class AvisoAuseciaRepository : IAvisoAusenciaRepository
    {
        private readonly LiquidacionesDbContext _context;

        public AvisoAuseciaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public AvisosAusencia cargarAvisoAusencia(AvisosAusencia aviso)
        {
            _context.AvisosAusencia.Add(aviso);
            _context.SaveChanges();
            return aviso;
        }

        public List<AvisosAusencia> obtenerAvisoAusenciaEmpleadoEnAnio(string dniEmpleado, int anio)
        {
            return _context.AvisosAusencia.Where(aa => aa.DniEmpleado.Equals(dniEmpleado)
                                                && aa.FechaAusencia.Year.Equals(anio)).ToList();
        }
    }
}
