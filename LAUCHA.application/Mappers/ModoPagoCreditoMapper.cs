using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Mappers
{
    internal static class ModoPagoCreditoMapper
    {
        private static ModoPagoCredito ToModoPagoCredito(int value)
        {
            if (!Enum.IsDefined(typeof(ModoPagoCredito), value))
                throw new ArgumentOutOfRangeException(nameof(value), $"Valor no válido: {value}");
            return (ModoPagoCredito)value;
        }
    }
}
