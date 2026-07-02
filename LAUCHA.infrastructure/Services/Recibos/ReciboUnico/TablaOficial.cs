using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Borders;
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
                .ToList();

            var remunerativos = itemsEnBlanco
                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo)
                .OrderByDescending(it => it.Monto)
                .ToList();

            var noRemunerativos = itemsEnBlanco
                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                .OrderByDescending(it => it.Monto)
                .ToList();

            var descuentos = itemsEnBlanco
                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Retencion)
                .OrderByDescending(it => it.Monto)
                .ToList();

            float[] pointColumnWidths = { 420F, 180F };

            Table tabla = new Table(pointColumnWidths)
                .SetWidth(UnitValue.CreatePercentValue(100));

            AgregarCabecera(tabla);

            AgregarTituloSeccion(tabla, "REMUNERATIVO");
            foreach (var item in remunerativos)
                AgregarFilaItem(tabla, item.Concepto, item.Monto);

            AgregarTituloSeccion(tabla, "NO REMUNERATIVO");
            foreach (var item in noRemunerativos)
                AgregarFilaItem(tabla, item.Concepto, item.Monto);

            AgregarTituloSeccion(tabla, "DESCUENTOS");
            foreach (var item in descuentos)
                AgregarFilaItem(tabla, item.Concepto,-item.Monto);

            decimal totalRemunerativo = remunerativos.Sum(it => it.Monto);
            decimal totalNoRemunerativo = noRemunerativos.Sum(it => it.Monto);
            decimal totalDescuentos = descuentos.Sum(it => it.Monto);
            decimal sueldoBruto = totalRemunerativo + totalNoRemunerativo;
            decimal neto = sueldoBruto - totalDescuentos;

            AgregarFilaTotal(tabla, "SUELDO BRUTO", sueldoBruto, ColorConstants.LIGHT_GRAY);
            AgregarFilaTotal(tabla, "DESCUENTOS", -totalDescuentos, ColorConstants.LIGHT_GRAY);
            AgregarFilaTotal(tabla, "NETO", neto, ColorConstants.GRAY);

            return tabla;
        }

        private static void AgregarCabecera(Table tabla)
        {
            var fontBold = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);

            tabla.AddCell(new Cell()
                .Add(new Paragraph("CONCEPTO").SetFont(fontBold).SetFontSize(9))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetFontColor(ColorConstants.WHITE));

            tabla.AddCell(new Cell()
                .Add(new Paragraph("MONTO").SetFont(fontBold).SetFontSize(9))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(ColorConstants.DARK_GRAY)
                .SetFontColor(ColorConstants.WHITE));
        }

        private static void AgregarTituloSeccion(Table tabla, string titulo)
        {
            var fontBold = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);

            tabla.AddCell(new Cell(1, 2)
                .Add(new Paragraph(titulo).SetFont(fontBold).SetFontSize(8))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBorder(new SolidBorder(ColorConstants.GRAY, 0.5f))
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetPadding(2));
        }

        private static void AgregarFilaItem(Table tabla, string concepto, decimal monto)
        {
            tabla.AddCell(new Cell()
                .Add(new Paragraph(concepto).SetFontSize(8))
                .SetBorder(new SolidBorder(ColorConstants.GRAY, 0.5f))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetPadding(2));

            tabla.AddCell(new Cell()
                .Add(new Paragraph(monto.ToString("N2")).SetFontSize(8))
                .SetBorder(new SolidBorder(ColorConstants.GRAY, 0.5f))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetPadding(2));
        }

        private static void AgregarFilaTotal(Table tabla, string concepto, decimal monto, Color fondo)
        {
            var fontBold = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);

            tabla.AddCell(new Cell()
                .Add(new Paragraph(concepto).SetFont(fontBold).SetFontSize(8))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorder(new SolidBorder(ColorConstants.GRAY, 0.5f))
                .SetBackgroundColor(fondo)
                .SetPadding(3));

            tabla.AddCell(new Cell()
                .Add(new Paragraph(monto.ToString("N2")).SetFont(fontBold).SetFontSize(8))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(new SolidBorder(ColorConstants.GRAY, 0.5f))
                .SetBackgroundColor(fondo)
                .SetPadding(3));
        }
    }
}