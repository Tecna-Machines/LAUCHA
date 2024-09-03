namespace LAUCHA.domain.entities.diasEspeciales
{
    public class DiaFeriado
    {
        public DateTime FechaFeriado { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
