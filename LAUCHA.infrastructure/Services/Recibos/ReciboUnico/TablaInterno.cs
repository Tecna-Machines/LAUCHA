using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaInterno
    {
        public static Table Generar(GetLiquidacionByIdResponse liq)
        {
            var itemsEnNegro = liq.Items
             .Where(it => !it.EsEnBlanco && it.Estado != (int)EstadoItemLiquidacion.ANULADO)
             .OrderBy(it => it.TipoItem)
             .ThenByDescending(it => it.Monto);

            float[] pointColumnWidths = { 150F, 150F, 150F, 150F };

            Table tablaInterno = new Table(pointColumnWidths);
            tablaInterno.SetFontSize(8);

            AgregarCabeceraEnNegro(tablaInterno);

            foreach (var it in itemsEnNegro)
            {
                AgregarFilaItemNegro(tablaInterno, it);
            }

            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph("SUBTOTAL:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.GRAY));

            string totalRemunerativo = itemsEnNegro.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo).Sum(it => it.Monto).ToString("N2");
            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph(totalRemunerativo))
                .SetTextAlignment(TextAlignment.RIGHT))
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            string totalDescuentos = itemsEnNegro.Where(it => it.TipoItem == (int)TipoItemLiquidacion.Descuento).Sum(it => it.Monto).ToString("N2");
            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph(totalDescuentos))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph("")));

            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph("NETO:"))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            tablaInterno.AddCell(new Cell()
                .Add(new Paragraph(liq.Montos.EnNegro.ToString("N2")))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY));


            return tablaInterno;
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

        private static void AgregarFilaItemNegro(Table detalleEnNegro, ItemLiquidacionByIdResponse item)
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
                .SetTextAlignment(TextAlignment.RIGHT));
        }
    }
}
