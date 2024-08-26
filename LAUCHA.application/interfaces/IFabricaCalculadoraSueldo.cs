namespace LAUCHA.application.interfaces
{
    public interface IFabricaCalculadoraSueldo
    {
        IEstrategiaCalcularSueldo CrearCalculadoraSueldo(int modalidadContrato);
    }
}
