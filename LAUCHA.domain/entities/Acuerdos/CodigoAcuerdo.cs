namespace LAUCHA.domain.Entities.Acuerdos
{
    internal static class CodigoAcuerdo
    {
        public static string Generar(string dni)
        => $"{DateTime.Now.ToString("yyyy-mm-dd:ss")}{dni}";
    }
}
