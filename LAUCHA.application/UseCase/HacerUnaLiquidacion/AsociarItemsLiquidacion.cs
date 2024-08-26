using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class AsociarItemsLiquidacion : IRecuperarItemsParaLiquidacion
    {
        private readonly IRemuneracionRepository _RemuneracionRepositoryEspecifico;
        private readonly IRetencionRepository _RetencionRepositoryEspecifico;
        private readonly INoRemuneracionRepository _NoRemuneracionRepositoryEspecifico;
        private readonly IDescuentoRepository _DescuentoRepositoryEspecifo;
        private readonly IGenericRepository<Descuento> _DescuentoRepository;
        private readonly IMenuesService _MenuService;
        private readonly ICalculadoraCredito _CalculadoraCredito;



        public AsociarItemsLiquidacion(IRemuneracionRepository remuneracionRepositoryEspecifico,
                                       IRetencionRepository retencionRepositoryEspecifico,
                                       IMenuesService menuService,
                                       INoRemuneracionRepository noRemuneracionRepositoryEspecifico,
                                       IDescuentoRepository descuentoRepositoryEspecifo,
                                       IGenericRepository<Descuento> descuentoRepository,
                                       ICalculadoraCredito calculadoraCredito)
        {
            _RemuneracionRepositoryEspecifico = remuneracionRepositoryEspecifico;
            _RetencionRepositoryEspecifico = retencionRepositoryEspecifico;
            _MenuService = menuService;
            _NoRemuneracionRepositoryEspecifico = noRemuneracionRepositoryEspecifico;
            _DescuentoRepositoryEspecifo = descuentoRepositoryEspecifo;
            _DescuentoRepository = descuentoRepository;
            _CalculadoraCredito = calculadoraCredito;
        }

        public async Task<List<Remuneracion>> ObtenerRemuneracionesParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            var remuneraciones = await _RemuneracionRepositoryEspecifico.
                      ObtenerRemuneracionesFiltradas(NumeroCuenta, inicioPeriodo, finPeriodo, null, null, 1, 1000);

            return remuneraciones.Registros;
        }

        public async Task<List<Retencion>> ObtenerRetencionesParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            var retenciones = await _RetencionRepositoryEspecifico.
                      ObtenerRetencionesFiltradas(NumeroCuenta, inicioPeriodo, finPeriodo, null, null, 1, 1000);


            return retenciones.Registros;
        }

        public async Task<List<Descuento>> ObtenerDescuentosParaLiquidacion(string NumeroCuenta, string dniEmp, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            //TODO: eliminar despues de PRUEBAS IMPORTANTE
            //se coloco la linea correcta
            var costosComida = await _MenuService.ObtenerGastosComida(dniEmp, inicioPeriodo, finPeriodo);

            //TODO: llamar a una logica para crear el descuento de un credito
            _CalculadoraCredito.CrearDescuentosCreditos(NumeroCuenta);

            var descuentoComidaDTO = new CrearDescuentoDTO
            {
                Descripcion = $"comida: ({costosComida.cantidadPedidos}) pedidos dentro del periodo",
                Monto = (costosComida.costoTotal - costosComida.descuento),
                NumeroCuenta = NumeroCuenta,
                NumeroConcepto = null
            };


            _DescuentoRepository.Insert(new DescuentoMapper().CrearDescuento(descuentoComidaDTO));
            _DescuentoRepository.Save();

            var descuentos = await _DescuentoRepositoryEspecifo.
                            ObtenerDescuentosFiltrados(NumeroCuenta, inicioPeriodo, finPeriodo, null, null, 1, 1000);

            return descuentos.Registros;
        }

        public async Task<List<NoRemuneracion>> ObtenerNoRemunerativoParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            var noRemuneraciones = await _NoRemuneracionRepositoryEspecifico.
                ObtenerNoRemuneracionesFiltradas(NumeroCuenta, inicioPeriodo, finPeriodo, null, null, 1, 1000);

            return noRemuneraciones.Registros;
        }
    }
}
