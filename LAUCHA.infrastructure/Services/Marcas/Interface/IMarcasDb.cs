using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.infrastructure.Services.Marcas.Interface
{
    public interface IMarcasDb
    {
        public List<Marca> GetUserMarcas(string dni, DateTime fechaInicio, DateTime fechaFin);

        public List<Marca> GetMarcas(DateTime fechaInicio, DateTime fechaFin);
    }
}
