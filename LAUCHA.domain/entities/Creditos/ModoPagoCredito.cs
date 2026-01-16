namespace LAUCHA.domain.Entities.Creditos
{
    /// <summary>
    /// define la forma en como se iran descontando
    /// las cuotas del credito en las liquidaciones
    /// </summary>
    public enum ModoPagoCredito
    {
        /// <summary>
        /// se descontara una cuota en cada quincena
        /// </summary>
        AMBAS_QUINCENAS,


        /// <summary>
        /// solo se descontara una cuota en la primera quincena
        /// </summary>
        PRIMERA_QUINCENA,


        /// <summary>
        /// solo se descontara una cuota en la segunda quincena
        /// </summary> 
        SEGUNDA_QUINCENA

    }
}
