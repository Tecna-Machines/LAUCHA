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
        public TimeSpan DebeEntrar { get; set; }
        public string Tarde { get; set; } = null!;
        public double HsTrabajadas { get; set; }
        public double Minutos { get; set; }
        public string Area { get; set; } = null!;


        public override string ToString()
        {
            // Define los anchos de las columnas para el formato
            const int nombreWidth = 20;
            const int ingresoWidth = 20;
            const int egresoWidth = 20;
            const int hsWidth = 5;

            // Ajusta la longitud de los valores para que encajen en el ancho definido
            string nombre = NombreCompleto.PadRight(nombreWidth);
            string ingreso = Ingreso.ToString("dd/MM/yyyy HH:mm:ss").PadRight(ingresoWidth);
            string egresoStr = (Egreso == DateTime.MinValue ? "00/00/0000 00:00:00" : Egreso.ToString("dd/MM/yyyy HH:mm:ss")).PadRight(egresoWidth);
            string hs = HsTrabajadas.ToString().PadLeft(hsWidth);
            DateTime ingresoD = Ingreso;

            return $"NOM: {nombre} | INGRESO: {ingreso} | EGRESO: {egresoStr} | HS: {hs}| DIA: {ingresoD.ToString("ddd")}";
        }

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
