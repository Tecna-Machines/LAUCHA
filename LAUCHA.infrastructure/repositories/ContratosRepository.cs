using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class ContratosRepository : IGenericRepository<Acuerdo>, IContratoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public ContratosRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public List<Acuerdo> ObtenerContratosDeEmpleado(string dniEmpleado)
        {
            return _context.Contratos.Where(c => c.DniEmpleado == dniEmpleado).ToList();
        }

        public Acuerdo Delete(string id)
        {
            // TODO: checar si es necesario
            throw new NotImplementedException();
        }

        public IList<Acuerdo> GetAll()
        {
            return _context.Contratos.ToList();

        }

        public Acuerdo GetById(string codigoContrato)
        {
            Acuerdo? contratoEncontrado = _context.Contratos.Find(codigoContrato);
            return contratoEncontrado != null ? contratoEncontrado : throw new NullReferenceException();
        }

        public Acuerdo Insert(Acuerdo contratoNuevo)
        {
            _context.Add(contratoNuevo);
            return contratoNuevo;
        }

        public Acuerdo ObtenerContratoDeEmpleado(string dniEmpleado)
        {
            Acuerdo? ultimoContratoEmpleado = _context.Contratos.Where(c => c.DniEmpleado == dniEmpleado)
                                               .OrderByDescending(c => c.Fecha).FirstOrDefault();

            return ultimoContratoEmpleado;
        }

        public Acuerdo Update(Acuerdo entity)
        {
            // TODO: quizas no sea necesario
            throw new NotImplementedException();
        }

        public int Save() => _context.SaveChanges();

    }
}
