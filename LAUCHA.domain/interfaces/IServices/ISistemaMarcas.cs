namespace LAUCHA.domain.interfaces.IServices
{
    public interface ISistemaMarcas
    {
        HorasPeriodo GetHorasPeriodo(string dni, DateTime desde, DateTime hasta);
        List<MarcaDb> GetDesdePeriodo(string dni, DateTime desde, DateTime hasta);
        List<MarcaResponse> GetDesdePeriodoVista(string dni, DateTime desde, DateTime hasta);
    }

    public class HorasPeriodo
    {
        public decimal Totales { get; set; }
        public decimal Habiles { get; set; }
        public decimal Extra { get; set; }
        public decimal Doble { get; set; }
    }

    public class MarcaDb
    {
        public string IdPersonal { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public DateTime Ingreso { get; set; }
        public DateTime Egreso { get; set; }
        public string Tarde { get; set; } = null!;
        public double HsTrabajadas { get; set; }
        public double Minutos { get; set; }
        public string Area { get; set; } = null!;


    }

    public sealed class MarcaResponse
    {
        public string IdPersonal { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public DateTime Ingreso { get; set; }
        public DateTime Egreso { get; set; }
        public TimeSpan DebeEntrar { get; set; }
        public string Tarde { get; set; } = null!;
        public decimal HsComunes { get; set; }
        public decimal HsExtra { get; set; }
        public decimal HsDoble { get; set; }
        public decimal HsTrabajadas { get; set; }

    }


}
