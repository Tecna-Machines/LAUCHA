using LAUCHA.application.interfaces;
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
            //TODO: implementar logica 

            //un empleado puede tener varias creditos/adelantos a la vez
            List<Credito> creditosPorPagar = _CreditoRepositoryEspecifico.ObtenerCreditosSinPagarDeCuenta(NumeroCuenta);

            foreach (Credito credito in creditosPorPagar) 
            {
                if (credito.Suspendido){ credito.Suspendido = false;}
                procesarCredito(credito);

            }
        }

        private void procesarCredito(Credito credito)
        {
            decimal aDescontar = credito.MontoCuota();
            credito.CobrarProximaCuota();

            _CreditoRepository.Update(credito);

            Descuento descuento = new Descuento(credito.Cuenta.NumeroCuenta)
            {
                Fecha = DateTime.Now,
                Monto = aDescontar,
                Descripcion = $"{credito.Descripcion} | cuota ({credito.CantidadCuotasPagadas+1}/{(credito.CantidadCuotasPagadas+1) + credito.CantidadCuotasFaltantes})"
            };

            _DescuentoRepository.Insert(descuento);
            _DescuentoRepository.Save();

            PagoCredito pagoCredito = new PagoCredito
            {
                CodigoCredito = credito.CodigoCredito,
                CodigoDescuento = descuento.CodigoDescuento,
                Descripcion = $"Pago de credito: {credito.Descripcion}",
                FechaPago = DateTime.Now,
                Monto = aDescontar,
            };

            _PagoCreditoRepository.Insert(pagoCredito);
            _PagoCreditoRepository.Save();
        }
    }
}
