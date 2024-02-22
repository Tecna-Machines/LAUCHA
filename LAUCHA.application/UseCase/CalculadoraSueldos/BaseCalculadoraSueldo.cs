﻿using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    internal abstract class BaseCalculadoraSueldo : IEstrategiaCalcularSueldo
    {
        protected RetencionMapper _MapperRetencion;
        protected CalculadorDePorcentaje _CalculadoraPorcentaje;
        protected RemuneracionMapper _MapperRemuneracion;


        public BaseCalculadoraSueldo()
        {
            _MapperRetencion = new ();
            _CalculadoraPorcentaje = new();
            _MapperRemuneracion = new();
        }

        protected bool EsPrimeraQuincena()
        {
            return DateTime.Now.Day < 15;
        }

        protected Retencion CrearRetencion(string descripcion, decimal monto, int indice, string numeroCuenta)
        {
            var retencionDTO = new CrearRetencionDTO
            {
                Descripcion = descripcion,
                Monto = monto,
                NumeroCuenta = numeroCuenta
            };

            var retencion = _MapperRetencion.GenerarRetencion(retencionDTO);

            retencion.CodigoRetencion = retencion.CodigoRetencion + indice;

            return retencion;
        }

        protected bool EsPrimeraQuicena()
        {
            return DateTime.Now.Day < 15;
        }

        public abstract List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta);
        public abstract List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta);
    }
}