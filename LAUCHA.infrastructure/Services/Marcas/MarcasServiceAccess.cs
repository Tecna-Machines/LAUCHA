using LAUCHA.domain.interfaces.IServices;
using LAUCHA.infrastructure.Services.Marcas.Interface;
namespace LAUCHA.infrastructure.Services.Marcas
{
    public class MarcasServiceAccess : ISistemaMarcas
    {
        private readonly IMarcasDb marcasDatabase;
        private readonly CalculadoraHs _calculadoraHs;

        public MarcasServiceAccess(IMarcasDb marcasDatabase)
        {
            this.marcasDatabase = marcasDatabase;
            this._calculadoraHs = new();
        }



        public HorasPeriodo GetHorasPeriodo(string dni, DateTime desde, DateTime hasta)
        {
            List<domain.interfaces.IServices.MarcaDb> marcas = marcasDatabase.GetUserMarcas(dni, desde, hasta);

            decimal hsTotalesTrabajadas = (decimal)_calculadoraHs.calcularHs(marcas);
            decimal hsFinde = (decimal)_calculadoraHs.calcularHsFindeSemana(marcas);
            decimal hsExtraHabiles = (decimal)_calculadoraHs.calculaHsExtrasDiasHabiles(marcas);
            decimal hsExtraFindeDoble = (decimal)_calculadoraHs.calcularHsExtraDobleFinde(marcas);
            decimal hsNormales = hsTotalesTrabajadas - hsExtraFindeDoble - hsFinde - hsExtraHabiles;

            return new HorasPeriodo
            {
                Totales = hsTotalesTrabajadas,
                Habiles = hsNormales,
                Extra = hsExtraHabiles + hsFinde,
                Doble = hsExtraFindeDoble
            };
        }

        public List<domain.interfaces.IServices.MarcaDb> GetDesdePeriodo(string dni, DateTime desde, DateTime hasta)
        {
            return marcasDatabase.GetUserMarcas(dni, desde, hasta);
        }

        public List<MarcaResponse> GetDesdePeriodoVista(string dni, DateTime desde, DateTime hasta)
        {
            //utilice este metodo para visualizar marcas de una forma mas clara y detallada
            var marcasOriginales = marcasDatabase.GetUserMarcas(dni, desde, hasta);
            List<MarcaResponse> marcasVista = new();

            foreach (var marc in marcasOriginales)
            {
                List<MarcaDb> marca = new() { marc };

                decimal hsTotalesTrabajadas = (decimal)_calculadoraHs.calcularHs(marca);
                decimal hsFinde = (decimal)_calculadoraHs.calcularHsFindeSemana(marca);
                decimal hsExtraHabiles = (decimal)_calculadoraHs.calculaHsExtrasDiasHabiles(marca);
                decimal hsExtraFindeDoble = (decimal)_calculadoraHs.calcularHsExtraDobleFinde(marca);
                decimal hsNormales = hsTotalesTrabajadas - hsExtraFindeDoble - hsFinde - hsExtraHabiles;

                var aux = new MarcaResponse
                {
                    IdPersonal = marc.IdPersonal,
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
