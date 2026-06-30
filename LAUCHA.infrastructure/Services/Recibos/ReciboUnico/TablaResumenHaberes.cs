using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaResumenHaberes
    {
        private readonly GetLiquidacionByIdResponse _liquidacion;
        private decimal _brutoBasico;
        private decimal _netoBasico;
        private decimal _netoTotal;
        private decimal _totalFinalAPagar;

        private Table tablaResumenHaberes;

        public TablaResumenHaberes(GetLiquidacionByIdResponse liquidacion)
        {
            _liquidacion = liquidacion;
            tablaResumenHaberes = new Table(
                                    UnitValue.CreatePercentArray(new float[] { 55, 15, 15, 15 }))
                                    .UseAllAvailableWidth()
                                    .SetFontSize(8);
        }

        public Table Generar()
        {
            AgregarEncabezado();
            AgregarParteAcuerdo();
            AgregarParteRetenciones();
            AgregarParteItemsExtra();
            AgregarParteDescuento();
            AgregarPartePagos();

            return tablaResumenHaberes;
        }

        private void AgregarEncabezado()
        {
            tablaResumenHaberes.AddHeaderCell(CeldaEncabezado("Concepto"));
            tablaResumenHaberes.AddHeaderCell(CeldaEncabezado("Cant."));
            tablaResumenHaberes.AddHeaderCell(CeldaEncabezado("Hora"));
            tablaResumenHaberes.AddHeaderCell(CeldaEncabezado("Montos"));
        }
        private Cell CeldaEncabezado(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPadding(4);
        }

        private void AgregarFila(string concepto,
                                decimal? cantidad,
                                decimal? horas,
                                decimal monto,
                                Color? colorFondo = null)
        {
            Cell celdaConcepto = CeldaTexto(concepto);
            Cell celdaCantidad = CeldaNumero(cantidad);
            Cell celdaHora = CeldaNumero(horas);
            Cell celdaMonto = CeldaMonto(monto);

            if (colorFondo is not null)
            {
                celdaConcepto.SetBackgroundColor(colorFondo);
                celdaCantidad.SetBackgroundColor(colorFondo);
                celdaHora.SetBackgroundColor(colorFondo);
                celdaMonto.SetBackgroundColor(colorFondo);
            }

            tablaResumenHaberes.AddCell(celdaConcepto);
            tablaResumenHaberes.AddCell(celdaCantidad);
            tablaResumenHaberes.AddCell(celdaHora);
            tablaResumenHaberes.AddCell(celdaMonto);
        }

        private Cell CeldaTexto(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto ?? string.Empty))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPadding(3);
        }

        private Cell CeldaNumero(decimal? valor)
        {
            return new Cell()
                .Add(new Paragraph(valor.HasValue ? valor.Value.ToString("N2") : string.Empty))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPadding(3);
        }

        private Cell CeldaMonto(decimal monto)
        {
            return new Cell()
                .Add(new Paragraph(monto.ToString("N2")))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPadding(3);
        }


        private void AgregarParteAcuerdo()
        {
            const decimal cantidadHoras = 200m;

            decimal totalMonto = 0m;
            decimal totalHora = 0m;

            decimal sueldo = _liquidacion.Acuerdo.Sueldo;
            decimal valorHoraSueldo = sueldo / cantidadHoras;

            AgregarFila(
                concepto: "Sueldo",
                cantidad: cantidadHoras,
                horas: valorHoraSueldo,
                monto: sueldo
            );

            totalMonto += sueldo;
            totalHora += valorHoraSueldo;

            foreach (var adicional in _liquidacion.Acuerdo.Adicionales)
            {
                decimal montoAdicional = adicional.Monto;
                decimal valorHoraAdicional = montoAdicional / cantidadHoras;

                AgregarFila(
                    concepto: adicional.Concepto,
                    cantidad: cantidadHoras,
                    horas: valorHoraAdicional,
                    monto: montoAdicional
                );

                totalMonto += montoAdicional;
                totalHora += valorHoraAdicional;
            }

            _brutoBasico = _liquidacion.EsQuincenal() ? totalMonto/2 : totalMonto;

            AgregarFila(
                concepto: _liquidacion.EsQuincenal() ? "Bruto básico / 2" : "Bruto básico",
                cantidad: _liquidacion.EsQuincenal() ? 100 : 200,
                horas: totalHora,
                monto: _brutoBasico,
                colorFondo: new DeviceRgb(230, 230, 230)
            );
        }


        private void AgregarParteRetenciones()
        {
            var retenciones = _liquidacion.Items
                .Where(item =>
                    item.Estado == (int)EstadoItemLiquidacion.ACEPTADO &&
                    item.TipoItem == (int)TipoItemLiquidacion.Retencion)
                .ToList();

            decimal totalRetenciones = retenciones.Sum(item => item.Monto);

            if (totalRetenciones > 0)
            {
                AgregarFila(
                    concepto: "Obra social + Jubilación + ARCA + etc",
                    cantidad: null,
                    horas: null,
                    monto: -totalRetenciones
                );
            }

            _netoBasico = _brutoBasico - totalRetenciones;

            AgregarFila(
                concepto: "Neto básico",
                cantidad: null,
                horas: null,
                monto: _netoBasico,
                colorFondo: new DeviceRgb(230, 230, 230)
            );
        }

        private void AgregarParteItemsExtra()
        {
            var conceptosYaMostrados = new HashSet<string>();

            conceptosYaMostrados.Add(NormalizarConcepto("Sueldo"));
            conceptosYaMostrados.Add(NormalizarConcepto("Sueldo mensual"));
            conceptosYaMostrados.Add(NormalizarConcepto("Sueldo quincenal"));

            foreach (var adicional in _liquidacion.Acuerdo.Adicionales)
            {
                conceptosYaMostrados.Add(NormalizarConcepto(adicional.Concepto));
            }

            var itemsExtra = _liquidacion.Items
                .Where(item =>
                    item.Estado == (int)EstadoItemLiquidacion.ACEPTADO &&
                    item.TipoItem == (int)TipoItemLiquidacion.Remunerativo &&
                    item.EsEnBlanco == false &&
                    !conceptosYaMostrados.Contains(NormalizarConcepto(item.Concepto)))
                .ToList();

            decimal totalItemsExtra = 0m;

            foreach (var item in itemsExtra)
            {
                AgregarFila(
                    concepto: item.Concepto,
                    cantidad: null,
                    horas: null,
                    monto: item.Monto
                );

                totalItemsExtra += item.Monto;
            }

            _netoTotal = _netoBasico + totalItemsExtra;

            AgregarFila(
                concepto: "Neto total",
                cantidad: null,
                horas: null,
                monto: _netoTotal,
                colorFondo: new DeviceRgb(210, 210, 210)
            );
        }


        private void AgregarPartePagos()
        {
            if (_liquidacion.Pagos is null || !_liquidacion.Pagos.Any())
            {
                return;
            }

            decimal totalPagos = 0m;

            foreach (var pago in _liquidacion.Pagos.OrderBy(p => p.Fecha))
            {
                string conceptoPago = $"Pago {pago.Modo}";

                AgregarFila(
                    concepto: conceptoPago,
                    cantidad: null,
                    horas: null,
                    monto: pago.Monto
                );

                totalPagos += pago.Monto;
            }

            AgregarFila(
                concepto: "Total pagado",
                cantidad: null,
                horas: null,
                monto: totalPagos,
                colorFondo: new DeviceRgb(230, 230, 230)
            );

            decimal saldoPendiente = _totalFinalAPagar - totalPagos;

            //AgregarFila(
            //    concepto: "Saldo pendiente",
            //    cantidad: null,
            //    horas: null,
            //    monto: saldoPendiente,
            //    colorFondo: new DeviceRgb(170, 170, 170)
            //);
        }
        private string NormalizarConcepto(string concepto)
        {
            return concepto.Trim().ToUpperInvariant();
        }

        private void AgregarParteDescuento()
        {
            var descuentos = _liquidacion.Items
                .Where(item =>
                    item.Estado == (int)EstadoItemLiquidacion.ACEPTADO &&
                    item.TipoItem == (int)TipoItemLiquidacion.Descuento &&
                    item.EsEnBlanco == false &&
                    !EsItemTecnicoDeLiquidacion(item))
                .ToList();

            decimal totalDescuentos = 0m;

            foreach (var descuento in descuentos)
            {
                AgregarFila(
                    concepto: descuento.Concepto,
                    cantidad: null,
                    horas: null,
                    monto: -descuento.Monto
                );

                totalDescuentos += descuento.Monto;
            }

            _totalFinalAPagar = _netoTotal - totalDescuentos;

            AgregarFila(
                concepto: "A pagar en banco y bolsillo",
                cantidad: null,
                horas: null,
                monto: _totalFinalAPagar,
                colorFondo: new DeviceRgb(190, 190, 190)
            );
        }

        private bool EsItemTecnicoDeLiquidacion(ItemLiquidacionByIdResponse item)
        {
            string concepto = NormalizarConcepto(item.Concepto);

            var conceptosTecnicos = new HashSet<string>
                   {
                        NormalizarConcepto("deposito"),
                        NormalizarConcepto("depósito"),
                        NormalizarConcepto("retenciones oficial"),
                        NormalizarConcepto("retencion oficial"),
                        NormalizarConcepto("retenciones oficiales"),
                        NormalizarConcepto("retencion oficial")
            };

            return conceptosTecnicos.Contains(concepto);
        }
    }

}
