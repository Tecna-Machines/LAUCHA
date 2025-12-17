using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class AcuerdoBlancoRepository : IGenericRepository<AcuerdoBlanco>
    {
        private readonly LiquidacionesDbContext _context;

        public AcuerdoBlancoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public AcuerdoBlanco Delete(string id)
        {
            // TODO: no se deberian poder boorar acuerdos
            throw new NotImplementedException();
        }

        public IList<AcuerdoBlanco> GetAll()
        {
            throw new NotImplementedException();
        }

        public AcuerdoBlanco GetById(string codigoContrato)
        {
            throw new NotImplementedException();

        }

        public AcuerdoBlanco Insert(AcuerdoBlanco nuevoAcuerdo)
        {
            throw new NotImplementedException();
        }

        public AcuerdoBlanco Update(AcuerdoBlanco entity)
        {
            //TODO: no es necesario actualizar acuerdos en blanco
            throw new NotImplementedException();
        }

        public int Save() => _context.SaveChanges();
    }
}
