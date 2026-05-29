using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.tests.Features.Empleados
{
    internal class EmpleadoFakeRepository : IEmpleadoRepository
    {
        public List<Empleado> Empleados { get; } = [];

        public Task<IEnumerable<Empleado>> FindByNameOrSurname(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Empleado>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Empleado?> GetByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Empleado emp)
        {
            Empleados.Add(emp);
            return Task.CompletedTask;
        }

        public Task<Empleado> Update(Empleado emp)
        {
            throw new NotImplementedException();
        }
    }
}
