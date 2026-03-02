using LAUCHA.domain.Entities.Asistencias;

namespace LAUCHA.infrastructure.asistencias.Models
{
    internal class MarcasMySQL
    {
        public string? Dni { get; set; }
        public string? NombreCompleto { get; set; }
        public DateTime? Ingreso { get; set; }
        public DateTime? Egreso { get; set; }
        public TimeSpan? DebeEntrar { get; set; }
        public int? Tarde { get; set; }
        public double? HsTrabajadas { get; set; }
        public double? Minutos { get; set; }
        public string? Area { get; set; }


        public Asistencia MapToAsistenciaEntity()
        {
            DateTime? debeEntrarDt = null;

            if (DebeEntrar.HasValue)
            {
                var fechaBase =
                    Ingreso?.Date ?? DateTime.Today;

                debeEntrarDt = fechaBase + DebeEntrar.Value;
            }

            return Asistencia.Crear(
                Dni ?? "",
                Ingreso,
                Egreso,
                debeEntrarDt
            );
        }

        public static MarcasMySQL MapToMarcasMySQL(Asistencia a)
        {

            return new MarcasMySQL
            {
                Dni = a.DniEmpleado,
                NombreCompleto = "marca manual",
                Ingreso = a.Ingreso!.Value.LocalDateTime,          //ingreso es datetimeoffset pero el ingreso de MarcasMySQL es un datetime arreglalo xfa
                Egreso = a.Egreso!.Value.LocalDateTime,            //lo miso aqui
                Tarde = 0,
                DebeEntrar = new TimeSpan(),
                HsTrabajadas = 0,
                Minutos = 0,
                Area = "manual"
            };
        }
    }
}
