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
        INCOMPLETO,

        /// <summary>
        /// la cuota no se descontara automaticamente en la proxima liquidacion
        /// </summary>
        SUSPENDIDO
    }
}
