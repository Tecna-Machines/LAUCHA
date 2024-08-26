namespace LAUCHA.domain.entities
{
    public class Modalidad
    {
        public string CodigoModalidad { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public IList<ModalidadPorContrato> ModalidadesPorContratos { get; set; } = null!;
    }
}
