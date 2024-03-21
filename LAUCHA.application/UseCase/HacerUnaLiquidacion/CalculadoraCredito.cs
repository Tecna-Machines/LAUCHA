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

            //crear un descuento con lo equivalente a 1 cuota

            //crear un PagoCredito y guardarlo

            //el codigo de pago credito tiene el formato CPR{ANIO}{DNI}{HORA}{DIA}{MES}

            // NOTA: no olvidar de usar el metodo save() de los repositorios 

            //NOTA: si el metodo crece bastante considere usar metodos mas pequeños pero privados en esta clase
        }
    }
}
