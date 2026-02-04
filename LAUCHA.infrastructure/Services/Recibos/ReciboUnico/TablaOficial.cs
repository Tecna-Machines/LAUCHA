using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaOficial
    {
        public static Table Generar(GetLiquidacionByIdResponse liq)
        {
            var itemsEnBlanco = liq.Items
            .Where(it => it.EsEnBlanco && it.Estado != (int)EstadoItemLiquidacion.ANULADO)
            .OrderBy(it => it.TipoItem)
            .ThenByDescending(it => it.Monto);

            float[] pointColumnWidths = { 150F, 150F, 150F, 150F, 150F };

            Table tablaOficial = new Table(pointColumnWidths);
            AgregarCabeceraOficial(tablaOficial);

            foreach (var it in itemsEnBlanco)
            {
                AgregarFilaItemOficial(tablaOficial, it);
            }

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph("SUBTOTAL:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.GRAY));

            string totalRemunerativo = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo).Sum(it => it.Monto).ToString("N2");
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(totalRemunerativo)));

            string totalRetenciones = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Retencion).Sum(it => it.Monto).ToString("N2");
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(totalRetenciones)));

            string montoNoRemunerativo = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo).Sum(it => it.Monto).ToString("N2");
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(montoNoRemunerativo)));

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph("")));

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph("NETO:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(liq.Montos.EnBlanco.ToString("N2")))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            return tablaOficial;
        }

        private static void AgregarCabeceraOficial(Table tablaOficial)
        {
            // Define el estilo base para los encabezados
            Color colorFondo = ColorConstants.LIGHT_GRAY;
            TextAlignment alineacionCentro = TextAlignment.CENTER;

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);

            Func<string, TextAlignment, Cell> CrearCeldaEncabezado = (texto, alineacion) =>
            {
                return new Cell()
                    .Add(new Paragraph(texto).SetFont(boldFont).SetFontSize(10))
                    .SetBackgroundColor(colorFondo)
                    .SetTextAlignment(alineacion)
                    .SetPadding(5);
            };

            tablaOficial.AddCell(CrearCeldaEncabezado("Conceptos", TextAlignment.LEFT));
            tablaOficial.AddCell(CrearCeldaEncabezado("Remunerativo", alineacionCentro));
            tablaOficial.AddCell(CrearCeldaEncabezado("Descuentos", alineacionCentro));
            tablaOficial.AddCell(CrearCeldaEncabezado("No Remunerativo", alineacionCentro));
            tablaOficial.AddCell(CrearCeldaEncabezado("Fecha", alineacionCentro));
        }

        private static void AgregarFilaItemOficial(Table tablaOficial, ItemLiquidacionByIdResponse item)
        {

            string formatoMonto = "N2"; // Formato numérico con 2 decimales
            TextAlignment alineacionMonto = TextAlignment.RIGHT;

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(item.Concepto))
                .SetTextAlignment(TextAlignment.LEFT));

            string montoRemuneracion = item.TipoItem == (int)TipoItemLiquidacion.Remunerativo ? item.Monto.ToString(formatoMonto) : string.Empty;
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(montoRemuneracion))
                .SetTextAlignment(alineacionMonto));

            string montoDescuento = item.TipoItem == (int)TipoItemLiquidacion.Retencion ? "-" + item.Monto.ToString(formatoMonto) : string.Empty;
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(montoDescuento))
                .SetTextAlignment(alineacionMonto));

            string montoNoRemunerativo = item.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo ? item.Monto.ToString(formatoMonto) : string.Empty;
            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(montoNoRemunerativo))
                .SetTextAlignment(alineacionMonto));

            tablaOficial.AddCell(new Cell()
                .Add(new Paragraph(item.Fecha.ToString("dd/MM/yyyy")))
                .SetTextAlignment(TextAlignment.RIGHT));
        }
    }
}

