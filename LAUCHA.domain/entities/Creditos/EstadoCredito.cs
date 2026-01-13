namespace LAUCHA.domain.Entities.Creditos
{
    public enum EstadoCredito
    {
        /// <summary>
        /// el credito se pago en su totalidad
        /// </summary>
        COMPLETADO,

        /// <summary>
        /// el credito fue anulado , no se descontaran
        /// mas cuotas
        /// </summary>
        ANULADO,

        /// <summary>
        /// aun quedan cuotas por pagar del 
        /// credito
        /// </summary>
        PENDIENTE,

        /// <summary>
        /// la cuota no se descontara automaticamente en la proxima liquidacion
        /// </summary>
        SUSPENDIDO,

        /// <summary>
        /// el credito fue creado pero aun no 
        /// se acredito en la liquidacion
        /// </summary>
        SOLICITADO
    }
}
