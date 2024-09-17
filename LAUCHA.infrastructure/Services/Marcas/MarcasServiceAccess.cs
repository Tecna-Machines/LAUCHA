using LAUCHA.domain.interfaces.IServices;
namespace LAUCHA.infrastructure.Services.Marcas
{
    public class MarcasServiceAccess : IMarcasService
    {
        private readonly string _connectionString;
        private readonly AccesDatabaseService _accesDatabaseService;
        private readonly CalculadoraHs _calculadoraHs;
        public MarcasServiceAccess(string connectionString,string networkSource)
        {
            _connectionString = connectionString;
            _accesDatabaseService = new(networkSource,connectionString);
            _calculadoraHs = new();
        }

        public HorasPeriodo ConsularHorasPeriodo(string dni, DateTime desde, DateTime hasta)
        {
            List<domain.interfaces.IServices.Marca> marcas = _accesDatabaseService.GetUserMarcas(dni,desde,hasta);

            decimal hsTotalesTrabajadas = (decimal)_calculadoraHs.calcularHs(marcas);
            decimal hsFinde = (decimal)_calculadoraHs.calcularHsFindeSemana(marcas);
            decimal hsExtraHabiles = (decimal)_calculadoraHs.calculaHsExtrasDiasHabiles(marcas);
            decimal hsExtraFindeDoble = (decimal)_calculadoraHs.calcularHsExtraDobleFinde(marcas);
            decimal hsNormales = hsTotalesTrabajadas - hsExtraFindeDoble - hsFinde - hsExtraHabiles;

            return new HorasPeriodo
            {
                HorasTotales = hsTotalesTrabajadas,
                HorasHabiles = hsNormales,
                HorasExtraTotales = hsExtraHabiles + hsFinde,
                HorasDoble = hsExtraFindeDoble
            };
        }

        public List<domain.interfaces.IServices.Marca> ConsultarMarcasPeriodo(string dni,DateTime desde,DateTime hasta)
        {
            return _accesDatabaseService.GetUserMarcas(dni, desde, hasta);
        }

        public List<MarcaVista> ConsultarMarcasPeriodoVista(string dni, DateTime desde, DateTime hasta)
        {
            //utilice este metodo para visualizar marcas de una forma mas clara y detallada
            var marcasOriginales = _accesDatabaseService.GetUserMarcas(dni, desde, hasta);
            List <MarcaVista> marcasVista = new();

            foreach (var marc in marcasOriginales)
            {
                List<Marca> marca = new(){marc};

                decimal hsTotalesTrabajadas = (decimal)_calculadoraHs.calcularHs(marca);
                decimal hsFinde = (decimal)_calculadoraHs.calcularHsFindeSemana(marca);
                decimal hsExtraHabiles = (decimal)_calculadoraHs.calculaHsExtrasDiasHabiles(marca);
                decimal hsExtraFindeDoble = (decimal)_calculadoraHs.calcularHsExtraDobleFinde(marca);
                decimal hsNormales = hsTotalesTrabajadas - hsExtraFindeDoble - hsFinde - hsExtraHabiles;

                var aux = new MarcaVista
                {
                    IdPersonal = marc.IdPersonal,
                    DebeEntrar = marc.DebeEntrar,
                    Egreso = marc.Egreso,
                    Ingreso = marc.Ingreso,
                    Tarde = marc.Tarde,
                    NombreCompleto = marc.NombreCompleto,
                    HsComunes = hsNormales,
                    HsDoble = hsExtraFindeDoble,
                    HsExtra = hsExtraHabiles + hsFinde,
                    HsTrabajadas = hsTotalesTrabajadas

                };

                marcasVista.Add(aux);
            }

            return marcasVista;
        }
    }
}
