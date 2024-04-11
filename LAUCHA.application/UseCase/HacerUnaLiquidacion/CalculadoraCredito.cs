﻿using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class CalculadoraCredito : ICalculadoraCredito
    {
        private readonly IGenericRepository<Descuento> _DescuentoRepository;
        private readonly IGenericRepository<PagoCredito> _PagoCreditoRepository;
        private readonly IGenericRepository<Credito> _CreditoRepository;
        private readonly ICreditoRepository _CreditoRepositoryEspecifico;

        public CalculadoraCredito(IGenericRepository<Descuento> descuentoRepository,
                                  IGenericRepository<PagoCredito> pagoCreditoRepository,
                                  IGenericRepository<Credito> creditoRepository,
                                  ICreditoRepository creditoRepositoryEspecifico)
        {
            _DescuentoRepository = descuentoRepository;
            _PagoCreditoRepository = pagoCreditoRepository;
            _CreditoRepository = creditoRepository;
            _CreditoRepositoryEspecifico = creditoRepositoryEspecifico;
        }

        public void CrearDescuentosCreditos(string NumeroCuenta)
        {
            List<Credito> creditosPorPagar = _CreditoRepositoryEspecifico.ObtenerCreditosSinPagarDeCuenta(NumeroCuenta);

            foreach (Credito credito in creditosPorPagar) 
            {
                if (credito.Suspendido) { credito.Suspendido = false; _CreditoRepository.Save(); continue; }
                procesarCredito(credito);
                
            }
        }

        private void procesarCredito(Credito credito) 
        {
            decimal aDescontar = credito.MontoCuota();
            credito.CobrarProximaCuota();
            Descuento descuento = _DescuentoRepository.Insert(new Descuento(credito.Cuenta.NumeroCuenta)
            {
                Fecha = DateTime.Now,
                Monto = aDescontar,
                Descripcion = "Descuento sin descripcion"
            });
            _DescuentoRepository.Save();
            PagoCredito pagoCredito = _PagoCreditoRepository.Insert(new PagoCredito
            {
                Descuento = descuento,
                Credito = credito,
                Descripcion = "Pago credito sin descripcion",
                FechaPago = DateTime.Now,
                Monto = aDescontar,
            });
            
            _PagoCreditoRepository.Save();
            _CreditoRepository.Save();

            credito.PagosCreditos.Add(pagoCredito);
        }
    }
}
