using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal static class DetalleRecibo
    {
        public static void AgregarDetalleEnBlanco(Document doc, GetLiquidacionByIdResponse liq)
        {
            var itemsEnBlanco = liq.Items
             .Where(it => it.EsEnBlanco && it.Estado != (int)EstadoItemLiquidacion.ANULADO)
             .OrderBy(it => it.TipoItem)
             .ThenByDescending(it => it.Monto);

            float[] pointColumnWidths = { 150F, 150F, 150F, 150F, 150F };

            Table detalleEnBlanco = new Table(pointColumnWidths);
            AgregarCabecera(detalleEnBlanco);

            foreach (var it in itemsEnBlanco)
            {
                AgregarFilaItem(detalleEnBlanco, it);
            }

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph("SUBTOTAL:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.GRAY));

            string totalRemunerativo = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo).Sum(it => it.Monto).ToString("N2");
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(totalRemunerativo)));

            string totalRetenciones = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Retencion).Sum(it => it.Monto).ToString("N2");
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(totalRetenciones)));

            string montoNoRemunerativo = itemsEnBlanco.Where(it => it.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo).Sum(it => it.Monto).ToString("N2");
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(montoNoRemunerativo)));

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph("")));

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph("NETO:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(liq.Montos.EnBlanco.ToString("N2")))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            doc.Add(detalleEnBlanco);
        }

        private static void AgregarCabecera(Table detalleEnBlanco)
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

            detalleEnBlanco.AddCell(CrearCeldaEncabezado("Conceptos", TextAlignment.LEFT));
            detalleEnBlanco.AddCell(CrearCeldaEncabezado("Remunerativo", alineacionCentro));
            detalleEnBlanco.AddCell(CrearCeldaEncabezado("Descuentos", alineacionCentro));
            detalleEnBlanco.AddCell(CrearCeldaEncabezado("No Remunerativo", alineacionCentro));
            detalleEnBlanco.AddCell(CrearCeldaEncabezado("Fecha", alineacionCentro));
        }

        private static void AgregarFilaItem(Table detalleEnBlanco, ItemLiquidacionByIdResponse item)
        {

            string formatoMonto = "N2"; // Formato numérico con 2 decimales
            TextAlignment alineacionMonto = TextAlignment.RIGHT;

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(item.Concepto))
                .SetTextAlignment(TextAlignment.LEFT));

            string montoRemuneracion = item.TipoItem == (int)TipoItemLiquidacion.Remunerativo ? item.Monto.ToString(formatoMonto) : string.Empty;
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(montoRemuneracion))
                .SetTextAlignment(alineacionMonto));

            string montoDescuento = item.TipoItem == (int)TipoItemLiquidacion.Retencion ? "-" + item.Monto.ToString(formatoMonto) : string.Empty;
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(montoDescuento))
                .SetTextAlignment(alineacionMonto));

            string montoNoRemunerativo = item.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo ? item.Monto.ToString(formatoMonto) : string.Empty;
            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(montoNoRemunerativo))
                .SetTextAlignment(alineacionMonto));

            detalleEnBlanco.AddCell(new Cell()
                .Add(new Paragraph(item.Fecha.ToString("dd/MM/yyyy")))
                .SetTextAlignment(TextAlignment.CENTER));
        }


        public static void AgregarDetalleEnNegro(Document doc, GetLiquidacionByIdResponse liq)
        {
            var itemsEnNegro = liq.Items
             .Where(it => !it.EsEnBlanco && it.Estado != (int)EstadoItemLiquidacion.ANULADO)
             .OrderBy(it => it.TipoItem)
             .ThenByDescending(it => it.Monto);

            float[] pointColumnWidths = { 150F, 150F, 150F, 150F };

            Table detalleEnNegro = new Table(pointColumnWidths);
            AgregarCabeceraEnNegro(detalleEnNegro);

            foreach (var it in itemsEnNegro)
            {
                AgregarFilItemNegro(detalleEnNegro, it);
            }

            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph("SUBTOTAL:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.GRAY));

            string totalRemunerativo = itemsEnNegro.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo).Sum(it => it.Monto).ToString("N2");
            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(totalRemunerativo)));

            string totalDescuentos = itemsEnNegro.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Descuento).Sum(it => it.Monto).ToString("N2");
            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(totalDescuentos)));

            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph("")));

            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph("NETO:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(liq.Montos.EnNegro.ToString("N2")))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));


            doc.Add(detalleEnNegro);
        }

        private static void AgregarCabeceraEnNegro(Table detalleEnNegro)
        {
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

            detalleEnNegro.AddCell(CrearCeldaEncabezado("Conceptos", TextAlignment.LEFT));
            detalleEnNegro.AddCell(CrearCeldaEncabezado("Remunerativo", alineacionCentro));
            detalleEnNegro.AddCell(CrearCeldaEncabezado("Descuentos", alineacionCentro));
            detalleEnNegro.AddCell(CrearCeldaEncabezado("Fecha", alineacionCentro));
        }

        private static void AgregarFilItemNegro(Table detalleEnNegro, ItemLiquidacionByIdResponse item)
        {

            string formatoMonto = "N2";
            TextAlignment alineacionMonto = TextAlignment.RIGHT;


            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(item.Concepto))
                .SetTextAlignment(TextAlignment.LEFT));

            string montoRemuneracion = item.TipoItem == (int)TipoItemLiquidacion.Remunerativo ? item.Monto.ToString(formatoMonto) : string.Empty;
            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(montoRemuneracion))
                .SetTextAlignment(alineacionMonto));


            string montoDescuento = item.TipoItem == (int)TipoItemLiquidacion.Descuento ? "-" + item.Monto.ToString(formatoMonto) : string.Empty;
            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(montoDescuento))
                .SetTextAlignment(alineacionMonto));

            detalleEnNegro.AddCell(new Cell()
                .Add(new Paragraph(item.Fecha.ToString("dd/MM/yyyy")))
                .SetTextAlignment(TextAlignment.CENTER));
        }

        public static void AgregarDetallePagar(Document doc, GetLiquidacionByIdResponse liq)
        {
            float[] pointColumnWidths = { 150F, 150F };

            Table tablaPagar = new Table(pointColumnWidths);

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

            tablaPagar.AddCell(CrearCeldaEncabezado("DEPOSITO:", TextAlignment.LEFT));
            tablaPagar.AddCell(CrearCeldaEncabezado("A COBRAR:", alineacionCentro));

            tablaPagar.AddCell(new Cell().Add(new Paragraph(liq.Montos.EnBlanco.ToString("C2"))));
            tablaPagar.AddCell(new Cell().Add(new Paragraph(liq.Montos.EnNegro.ToString("C2"))));

            doc.Add(tablaPagar);
        }
    }
}
