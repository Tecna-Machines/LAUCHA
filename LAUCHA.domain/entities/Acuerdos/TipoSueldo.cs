namespace LAUCHA.domain.Entities.Acuerdos
{
    public enum TipoSueldo : int
    {

        MENSUAL_FIJO = 10,
        MENSUAL_FIJO_CON_HS_EXTRA = 12,


        /// <summary>
        ///  la parte oficial de los sueldos quincenales sale a partir
        ///  de HsBanco inventadas
        /// </summary>
        QUINCENAL_FIJO_CON_HS_EXTRA = 20,
        QUINCENAL_FIJO = 22,
    }

}
