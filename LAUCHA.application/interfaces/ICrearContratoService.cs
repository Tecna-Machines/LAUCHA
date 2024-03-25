using LAUCHA.application.DTOs.ContratoDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ICrearContratoService
    {
        ContratoDTO CrearNuevoContrato(CrearContratoDTO nuevoContrato);
    }
}
