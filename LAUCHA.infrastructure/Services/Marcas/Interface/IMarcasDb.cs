using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.infrastructure.Services.Marcas.Interface
{
    public interface IMarcasDb
    {
        public List<MarcaDb> GetUserMarcas(string dni, DateTime fechaInicio, DateTime fechaFin);

        public List<MarcaDb> GetMarcas(DateTime fechaInicio, DateTime fechaFin);
    }
}
