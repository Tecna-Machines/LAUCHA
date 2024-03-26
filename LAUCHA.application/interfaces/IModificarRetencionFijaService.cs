using LAUCHA.application.DTOs.RetencionesFijasDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IModificarRetencionFijaService
    {
        RetencionFijaDTO ModificarRetencionFija(string codigoRetencionFija,ModificadorRetencionFijaDTO modifcaciones);
    }
}
