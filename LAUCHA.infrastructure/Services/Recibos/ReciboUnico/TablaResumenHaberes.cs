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
        private Table? tablaResumenHaberes;

        public TablaResumenHaberes(GetLiquidacionByIdResponse liquidacion)
        {
            _liquidacion = liquidacion;
            tablaResumenHaberes = new Table(
        UnitValue.CreatePercentArray(new float[] { 70, 30 }))
    .UseAllAvailableWidth().SetFontSize(8);
        }

        public Table Generar()
        {
            tablaResumenHaberes.AddHeaderCell(
                new Cell(1, 2)
                    .Add(new Paragraph("RESUMEN DE HABERES"))
                    .SetTextAlignment(TextAlignment.CENTER));

            // ==========================================
            // HABERES OFICIALES
            // ==========================================

            AgregarTitulo("HABERES OFICIALES");

            decimal brutoOficial = 0;

            var haberesOficiales = _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Remunerativo ||
                    x.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                .OrderBy(x => x.Nro);

            foreach (var item in haberesOficiales)
            {
                AgregarFila(
                    item.Concepto,
                    item.Monto.ToString("C"));

                brutoOficial += item.Monto;
            }

            AgregarFilaDestacada(
                "BRUTO OFICIAL",
                brutoOficial.ToString("C"),
                new DeviceRgb(220, 235, 255));

            // ==========================================
            // DESCUENTOS OFICIALES
            // ==========================================

            AgregarTitulo("DESCUENTOS OFICIALES");

            decimal descuentosOficiales = 0;

            var itemsDescuentosOficiales = _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Descuento ||
                    x.TipoItem == (int)TipoItemLiquidacion.Retencion)
                .OrderBy(x => x.Nro);

            foreach (var item in itemsDescuentosOficiales)
            {
                AgregarFila(
                    item.Concepto,
                    "-"+item.Monto.ToString("C"));

                descuentosOficiales += item.Monto;
            }

            decimal netoOficial =
                brutoOficial - descuentosOficiales;

            AgregarFilaDestacada(
                "NETO OFICIAL",
                netoOficial.ToString("C"),
                new DeviceRgb(255, 255, 180));

            AgregarSeparador();

            // ==========================================
            // HABERES INTERNOS
            // ==========================================

            AgregarTitulo("HABERES INTERNOS");

            decimal brutoInterno = 0;

            var haberesInternos = _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => !x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Remunerativo ||
                    x.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                .OrderBy(x => x.Nro);

            foreach (var item in haberesInternos)
            {
                AgregarFila(
                    item.Concepto,
                    "-"+item.Monto.ToString("C"));

                brutoInterno += item.Monto;
            }

            AgregarFilaDestacada(
                "BRUTO INTERNO",
                brutoInterno.ToString("C"),
                new DeviceRgb(220, 235, 255));

            // ==========================================
            // DESCUENTOS INTERNOS
            // ==========================================

            AgregarTitulo("DESCUENTOS INTERNOS");

            decimal descuentosInternos = 0;

            var itemsDescuentosInternos = _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => !x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Descuento ||
                    x.TipoItem == (int)TipoItemLiquidacion.Retencion)
                .OrderBy(x => x.Nro);

            foreach (var item in itemsDescuentosInternos)
            {
                AgregarFila(
                    item.Concepto,
                    item.Monto.ToString("C"));

                descuentosInternos += item.Monto;
            }

            decimal netoInterno =
                brutoInterno - descuentosInternos;

            AgregarFilaDestacada(
                "NETO INTERNO",
                netoInterno.ToString("C"),
                new DeviceRgb(255, 255, 180));

            AgregarSeparador();

            // ==========================================
            // TOTAL
            // ==========================================

            decimal totalPercibir =
                netoOficial + netoInterno;

            AgregarFilaDestacada(
                "TOTAL A PERCIBIR",
                totalPercibir.ToString("C"),
                new DeviceRgb(180, 255, 180));

            return tablaResumenHaberes;
        }

        private void AgregarTitulo(string titulo)
        {
            tablaResumenHaberes.AddCell(
                new Cell(1, 2)
                    .Add(new Paragraph(titulo))
                    .SetBackgroundColor(new DeviceRgb(230, 230, 230)));
        }

        private void AgregarFila(string concepto, string importe)
        {
            tablaResumenHaberes.AddCell(
                new Cell()
                    .Add(new Paragraph(concepto))
                    .SetBorderBottom(new SolidBorder(0.5f)));

            tablaResumenHaberes.AddCell(
                new Cell()
                    .Add(new Paragraph(importe))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorderBottom(new SolidBorder(0.5f)));
        }

        private void AgregarFilaDestacada(
            string concepto,
            string importe,
            Color color)
        {
            tablaResumenHaberes.AddCell(
                new Cell()
                    .Add(new Paragraph(concepto))
                    .SetBackgroundColor(color));

            tablaResumenHaberes.AddCell(
                new Cell()
                    .Add(new Paragraph(importe))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(color));
        }

        //TODO: esto no deberia estar aqui 
        private void AgregarSeparador()
        {
            tablaResumenHaberes.AddCell(
                new Cell(1, 2)
                    .Add(new Paragraph(" "))
                    .SetBorder(Border.NO_BORDER));
        }

        private decimal ObtenerBrutoOficial()
        {
            return _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Remunerativo ||
                    x.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                .Sum(x => x.Monto);
        }

        private decimal ObtenerRetencionesOficiales()
        {
            return _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Retencion ||
                    x.TipoItem == (int)TipoItemLiquidacion.Descuento)
                .Sum(x => x.Monto);
        }

        private decimal ObtenerBrutoBolsillo()
        {
            return _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => !x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Remunerativo ||
                    x.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                .Sum(x => x.Monto);
        }

        private decimal ObtenerDescuentosBolsillo()
        {
            return _liquidacion.Items
                .Where(x => x.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                .Where(x => !x.EsEnBlanco)
                .Where(x =>
                    x.TipoItem == (int)TipoItemLiquidacion.Retencion ||
                    x.TipoItem == (int)TipoItemLiquidacion.Descuento)
                .Sum(x => x.Monto);
        }
    }
}
