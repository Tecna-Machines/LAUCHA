﻿using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces
{
    public interface IModuloLiquidador
    {
        Task EjecutarRutina(LiquidacionPayload payload);
    }
}