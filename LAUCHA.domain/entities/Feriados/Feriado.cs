namespace LAUCHA.domain.Entities.Feriados
{
    public class Feriado
    {
        public DateTime Fecha { get; set; }
        public bool EsPermanente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Creacion { get; set; }

        public Feriado(DateTime fecha,string descripcion)
        { 
          if(string.IsNullOrEmpty(descripcion))
            {
                throw new ArgumentException("descripcion.nula");
            }

            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.Creacion = DateTime.Now;
            this.EsPermanente = false;
        }    

        public void MarcarComoPermanente()
        {
            this.EsPermanente = true;
        }

    }
}
