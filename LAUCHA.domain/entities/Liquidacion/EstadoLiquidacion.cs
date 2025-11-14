namespace LAUCHA.domain.Entities.Liquidacion
{
    /// <summary>
    /// representa el estado en el cual se encuentra una liquidacion
    /// </summary>
    public enum EstadoLiquidacion
    {
        /// <summary>
        /// la liquidacion permite agregar y quitar items
        /// </summary>
        PENDIENTE,
        /// <summary>
        /// la liquidacion no puede ser modificada y queda inmutable
        /// </summary>
        SELLADA
    }

}
