using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.RetencionesCatalogo;
using System.Collections.Immutable;

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
        public decimal ValorSueldoOJornal { get; set; }
        public decimal Sueldo { get; set; }
        public string? Notas { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;

        public TipoSueldo TipoSueldo { get; set; }
        public ICollection<Adicional> Adicionales { get; set; } = null!;
        public ICollection<RetencionAcuerdo> Retenciones { get; set; } = null!;

        public static Acuerdo Crear(string dni,
                                    decimal sueldo,
                                    decimal valorBlanco,
                                    decimal valorHora,
                                    TipoSueldo tipoSueldo)
        {
            return new Acuerdo
            {
                Codigo = CodigoAcuerdo.Generar(dni),
                DniEmpleado = dni,
                Sueldo = sueldo,
                Fecha = DateTime.Now,
                ValorSueldoOJornal = valorBlanco,
                ValorHora = valorHora,
                TipoSueldo = tipoSueldo,
                Adicionales = new List<Adicional>(),
                Retenciones = new List<RetencionAcuerdo>()
            };
        }

        public void AgregarAdicional(Adicional adicional)
        {
            if (adicional.CodigoAcuerdo != Codigo)
                throw new ArgumentException("codigo de acuerdo no valido");

            this.Adicionales.Add(adicional);
        }

        public bool EsMensual()
        {
            if (TipoSueldo == TipoSueldo.MENSUAL_FIJO) return true;
            if (TipoSueldo == TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA) return true;

            return false;
        }

        public void AgregarNota(string nota)
        {
            this.Notas = nota;
        }

        public void AgregarRetencion(CatalogoRetencion retencion)
        {
            Retenciones.Add(RetencionAcuerdo.Generar(retencion, this));
        }

        public bool PuedeHacerHorasExtra()
        {
            if (TipoSueldo == TipoSueldo.MENSUAL_FIJO)
                return false;

            if (TipoSueldo == TipoSueldo.QUINCENAL_FIJO)
                return false;

            return true;
        }

        public IEnumerable<RetencionAcuerdo> GetRetenciones() => Retenciones.ToImmutableList();

        public IEnumerable<RetencionAcuerdo> GetRetencionesPrimeraQuincena()
            => Retenciones.Where(r => r.PrimeraQuincena == true)
               .ToImmutableList();
        public IEnumerable<RetencionAcuerdo> GetRetencionesSegundaQuincena()
            => Retenciones
               .ToImmutableList();

        public IEnumerable<Adicional> GetAdicionales() => Adicionales.ToImmutableList();



    }
}
