using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaHeader
    {
        private static readonly Color HeaderBgColor = new DeviceRgb(220, 220, 220); // Gris claro
        private static readonly float DefaultFontSize = 10f;
        private static readonly float HeaderFontSize = 12f;

        /// <summary>
        /// Agrega la sección de encabezado al documento PDF.
        /// </summary>
        public static Div GenerarCabecera(GetLiquidacionByIdResponse liquidacion)
        {
            var cabecera = new Div();

            float[] titleColWidths = { 400f, 150f };
            Table titleTable = new Table(titleColWidths).SetBorder(Border.NO_BORDER);

            titleTable.AddCell(new Cell().SetBorder(Border.NO_BORDER)
                .Add(new Paragraph("RECIBO DE SUELDO").SetFontSize(HeaderFontSize)));

            titleTable.AddCell(new Cell().SetBorder(Border.NO_BORDER)
                .Add(new Paragraph($"CÓDIGO: {liquidacion.Codigo}")
                .SetTextAlignment(TextAlignment.RIGHT).SetFontSize(DefaultFontSize)));

            cabecera.Add(titleTable);

            cabecera.Add(new LineSeparator(new SolidLine(1f))
                .SetMarginTop(5).SetMarginBottom(5));

            float[] liqDataColWidths = { 200f, 350f };
            Table liqDataTable = new Table(liqDataColWidths);

            string periodo = $"{liquidacion.Quincena.Nro}º Quincena de {liquidacion.Quincena.Mes}/{liquidacion.Quincena.Anio}";
            liqDataTable.AddCell(CreateCell("PERIODO:", periodo, true));
            liqDataTable.AddCell(CreateCell("CONCEPTO:", liquidacion.Concepto, false));

            cabecera.Add(liqDataTable);

            cabecera.Add(new LineSeparator(new SolidLine(0.5f))
                .SetMarginTop(5).SetMarginBottom(5));

            float[] empDataColWidths = { 183.33f, 183.33f };
            Table empDataTable = new Table(empDataColWidths).SetMarginBottom(10);

            string nombreCompleto = $"{liquidacion.Empleado.Nombre} {liquidacion.Empleado.Apellido}";
            empDataTable.AddCell(CreateCell("APELLIDO Y NOMBRE:", nombreCompleto, true));
            empDataTable.AddCell(CreateCell("DNI:", liquidacion.Empleado.Dni, true));

            string fechaAlta = liquidacion.Empleado.FechaAlta.ToString("dd/MM/yyyy");
            string fechaIngreso = liquidacion.Empleado.FechaIngreso.ToString("dd/MM/yyyy");

            empDataTable.AddCell(CreateCell("FECHA DE ALTA:", fechaAlta, true));
            empDataTable.AddCell(CreateCell("FECHA DE INGRESO:", fechaIngreso, true));

            cabecera.Add(empDataTable);

            return cabecera;
        }

        /// <summary>
        /// Crea una celda de tabla con formato de etiqueta/valor.
        /// </summary>
        private static Cell CreateCell(string label, string value, bool isHeader)
        {
            Paragraph p = new Paragraph()
                .SetFontSize(DefaultFontSize)
                .SetMargin(3);

            p.Add(new Text(label));

            p.Add(new Text($" {value}"));

            Cell cell = new Cell()
                .Add(p)
                .SetBorder(new SolidBorder(HeaderBgColor, 0.5f));

            return cell;
        }

    }
}
