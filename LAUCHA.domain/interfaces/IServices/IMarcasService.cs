using System.Text.RegularExpressions;

namespace LAUCHA.domain.interfaces.IServices
{
    public class HorasPeriodo
    {
        public decimal HorasTotales { get; set; }
        public decimal HorasHabiles { get; set; }
        public decimal HorasExtraTotales { get; set; }
        public decimal HorasDoble { get; set; }
    }

    public class Marca
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

    public class MarcaVista
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


        public interface IMarcasService
    {
        HorasPeriodo ConsularHorasPeriodo(string dni, DateTime desde, DateTime hasta);
        List<Marca> ConsultarMarcasPeriodo(string dni, DateTime desde, DateTime hasta);
        List<MarcaVista> ConsultarMarcasPeriodoVista(string dni, DateTime desde, DateTime hasta);
    }
}
