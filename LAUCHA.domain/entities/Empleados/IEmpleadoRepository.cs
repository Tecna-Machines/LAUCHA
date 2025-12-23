namespace LAUCHA.domain.Entities.Empleados
{
    public interface IEmpleadoRepository
    {
        Task Insert(Empleado emp);
        Task<Empleado?> GetByDni(string dni);
        Task<IEnumerable<Empleado>> GetAll();
        Task<IEnumerable<Empleado>> FindByNameOrSurname(string name);
        Task<Empleado> Update(Empleado emp);
    }
}
