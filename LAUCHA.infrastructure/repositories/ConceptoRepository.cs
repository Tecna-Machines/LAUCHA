using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class ConceptoRepository : IGenericRepository<Concepto>
    {
        private readonly LiquidacionesDbContext _context;

        public ConceptoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Concepto Delete(string numeroConcepto)
        {
            Concepto? encontrado = _context.Conceptos.Find(int.Parse(numeroConcepto));

            if (encontrado == null) { throw new NullReferenceException(); }

            _context.Remove(encontrado);
            return encontrado;
        }

        public IList<Concepto> GetAll()
        {
            return _context.Conceptos.ToList();
        }

        public Concepto GetById(string numeroConcepto)
        {
            Concepto? encontrado = _context.Conceptos.Find(int.Parse(numeroConcepto));
            return encontrado != null ? encontrado : throw new NullReferenceException();
        }

        public Concepto Insert(Concepto conceptoNuevo)
        {
            _context.Add(conceptoNuevo);
            return conceptoNuevo;
        }
        public Concepto Update(Concepto entity)
        {
            //TODO: quizas innecesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

    }
}
