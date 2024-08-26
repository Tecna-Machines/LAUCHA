namespace LAUCHA.domain.entities
{
    public class Remuneracion
    {
        public string CodigoRemuneracion { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsBlanco { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public IList<RemuneracionPorLiquidacionPersonal> RemuneracionPorLiquidacionPersonales { get; set; } = null!;
    }
}
