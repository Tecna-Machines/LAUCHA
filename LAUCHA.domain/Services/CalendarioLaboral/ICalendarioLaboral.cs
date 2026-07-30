namespace LAUCHA.domain.Services.CalendarioLaboral
{
    public interface ICalendarioLaboral
    {
        Task<int> CalcularDiasHabiles(int anio, int mes, int numeroQuincena);
    }
}
