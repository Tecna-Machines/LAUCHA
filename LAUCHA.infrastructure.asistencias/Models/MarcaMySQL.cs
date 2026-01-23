using LAUCHA.domain.Entities.Asistencias;

namespace LAUCHA.infrastructure.asistencias.Models
{
    internal class MarcasMySQL
    {
        public string? Dni { get; set; }
        public string? NombreCompleto { get; set; }
        public DateTime? Ingreso { get; set; }
        public DateTime? Egreso { get; set; }
        public DateTime? DebeEntrar { get; set; }
        public int? Tarde { get; set; }
        public double? HsTrabajadas { get; set; }
        public double? Minutos { get; set; }
        public string? Area { get; set; }


        public Asistencia MapToAsistenciaEntity()
        {
            return Asistencia.Crear(Dni ?? "", Ingreso, Egreso, DebeEntrar);
        }
    }
}
