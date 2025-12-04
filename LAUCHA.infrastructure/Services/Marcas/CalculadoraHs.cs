using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.infrastructure.Services.Marcas
{
    internal class CalculadoraHs
    {
        private bool esFinde(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        public double calcularHs(List<MarcaDb> marcas)
        {
            return marcas.Sum(m => m.HsTrabajadas);
        }

        public double calculaHsExtrasDiasHabiles(List<MarcaDb> marcas)
        {
            double hsExtra = 0;
            double hsJornada = 9;


            foreach (var marc in marcas)
            {
                bool esfinde = this.esFinde(marc.Ingreso);

                if (marc.HsTrabajadas > hsJornada && !esfinde)
                {
                    hsExtra += (marc.HsTrabajadas - hsJornada);
                }

            }

            return hsExtra;
        }

        public double calcularHsExtraDobleFinde(List<MarcaDb> marcas)
        {
            double hs = 0;
            double hsJornadaReducida = 6;

            foreach (var marc in marcas)
            {
                bool esfinde = this.esFinde(marc.Ingreso);

                if (esfinde && marc.HsTrabajadas > hsJornadaReducida)
                {
                    hs += (marc.HsTrabajadas - hsJornadaReducida);
                }
            }

            return hs;
        }

        public double calcularHsFindeSemana(List<MarcaDb> marcas)
        {
            double hsFinde = 0;
            double hsJornardaReducida = 6;

            foreach (var marc in marcas)
            {
                bool esfinde = this.esFinde(marc.Ingreso);

                if (esfinde)
                {
                    double hsDia = marc.HsTrabajadas;

                    if (hsDia > hsJornardaReducida) { hsDia = hsJornardaReducida; }
                    hsFinde += hsDia;
                }
            }

            return hsFinde;
        }



    }
}
