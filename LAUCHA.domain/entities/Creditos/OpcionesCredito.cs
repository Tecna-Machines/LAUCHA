namespace LAUCHA.domain.Entities.Creditos
{
    public sealed record OpcionesCredito(string Dni,
                                         decimal MontoPrestar,
                                         decimal MontoDevolver,
                                         string Descripcion,
                                         ModoPagoCredito ModoPago,
                                         int CantidadCuotas);
}
