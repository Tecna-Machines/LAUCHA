using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.AcuerdosBlancos.ToList();
        }

        public AcuerdoBlanco GetById(string codigoContrato)
        {
            AcuerdoBlanco? acuerdo = _context.AcuerdosBlancos.FirstOrDefault(a => a.CodigoContrato == codigoContrato);
            return acuerdo != null ? acuerdo : throw new NullReferenceException();
        }

        public AcuerdoBlanco Insert(AcuerdoBlanco nuevoAcuerdo)
        {
            _context.Add(nuevoAcuerdo);
            return nuevoAcuerdo;
        }

        public AcuerdoBlanco Update(AcuerdoBlanco entity)
        {   
            //TODO: no es necesario actualizar acuerdos en blanco
            throw new NotImplementedException();
        }
    }
}
