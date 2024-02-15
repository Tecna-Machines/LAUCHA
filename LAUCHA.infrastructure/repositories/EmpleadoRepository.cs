using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {
        private readonly LiquidacionesDbContext _context;

        public EmpleadoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Empleado Delete(string id)
        {
            Empleado? empleadoEncontrado = _context.Empleados.Find(id);

            if (empleadoEncontrado == null) { throw new NullReferenceException(); }

            _context.Remove(empleadoEncontrado);
            return empleadoEncontrado;
        }

        public IList<Empleado> GetAll()
        {
            return _context.Empleados.ToList();
        }

        public Empleado GetById(string id)
        {
            Empleado? empleadoEncontrado = _context.Empleados.Find(id);
            return empleadoEncontrado != null ? empleadoEncontrado : throw new NullReferenceException();
        }

        public Empleado Insert(Empleado nuevoEmpleado)
        {
            _context.Add(nuevoEmpleado);
            return nuevoEmpleado;
        }

        public Empleado Update(Empleado empleadoCambiar)
        {
            // TODO: implementar metodo
            throw new NotImplementedException();
        }

        public int Save() => _context.SaveChanges();

    }
}
