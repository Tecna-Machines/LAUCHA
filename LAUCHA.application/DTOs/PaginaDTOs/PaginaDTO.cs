namespace LAUCHA.application.DTOs.PaginaDTOs
{
    public class PaginaDTO<T>
    {
        public int TotalEncontrados { get; set; }
        public int Paginas { get; set; }
        public int Index { get; set; }
        public List<T> Resultados { get; set; } = null!;
    }
}
