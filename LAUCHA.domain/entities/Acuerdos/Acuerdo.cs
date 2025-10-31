using LAUCHA.domain.entities.Contrato;

namespace LAUCHA.domain.Entities.Acuerdos
{
    public class Acuerdo
    {
        public string Codigo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal ValorHora { get; set; }

        /// <summary>
        /// indica la parte legal del empleado , si es mensual sera un monto fijo
        /// si es jornal indicara el valor por hora
        /// </summary>
        public decimal ValorBlanco { get; set; }
        public decimal Sueldo { get; set; }
        public string? Notas { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
        public TipoSueldo TipoSueldo { get; set; }
        public ICollection<Adicional> Adicionales { get; set; } = null!;


        public static Acuerdo Crear(string dni,
                                    decimal sueldo,
                                    decimal valorBlanco,
                                    decimal valorHora)
        {
            return new Acuerdo
            {
                Codigo = CodigoAcuerdo.Generar(dni),
                DniEmpleado = dni,
                Sueldo = sueldo,
                Fecha = DateTime.Now,
                ValorBlanco = valorBlanco,
                ValorHora = valorHora,
                Adicionales = new List<Adicional>()
            };
        }

        public void AgregarAdicional(Adicional adicional)
        {
            if (adicional.CodigoContrato != Codigo)
                throw new ArgumentException("codigo de acuerdo no valido");

            this.Adicionales.Add(adicional);
        }

        public void AgregarNota(string nota)
        {
            this.Notas = nota;
        }


    }
}
