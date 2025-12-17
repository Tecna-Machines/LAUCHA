using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal static class HeaderPdf
    {
        private static readonly Color HeaderBgColor = new DeviceRgb(220, 220, 220); // Gris claro
        private static readonly float DefaultFontSize = 10f;
        private static readonly float HeaderFontSize = 12f;

        /// <summary>
        /// Agrega la sección de encabezado al documento PDF.
        /// </summary>
        public static void AgregarHeader(Document document, GetLiquidacionByIdResponse liquidacion)
        {
            float[] titleColWidths = { 400f, 150f };
            Table titleTable = new Table(titleColWidths);
            titleTable.SetBorder(Border.NO_BORDER);

            Cell titleCell = new Cell().Add(new Paragraph("RECIBO DE SUELDO")
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetFontSize(HeaderFontSize)
                                        .SetBorder(Border.NO_BORDER));

            titleTable.AddCell(titleCell);

            Cell codeCell = new Cell().Add(new Paragraph($"CÓDIGO: {liquidacion.Codigo}")
                                      .SetTextAlignment(TextAlignment.RIGHT)
                                      .SetFontSize(DefaultFontSize)
                                      .SetBorder(Border.NO_BORDER));

            titleTable.AddCell(codeCell);

            document.Add(titleTable);

            document.Add(new LineSeparator(new SolidLine(1f))
                                           .SetMarginTop(5)
                                           .SetMarginBottom(5));

            float[] liqDataColWidths = { 200f, 350f };
            Table liqDataTable = new Table(liqDataColWidths);

            string periodo = $"{liquidacion.Quincena.Nro}º Quincena de {liquidacion.Quincena.Mes}/{liquidacion.Quincena.Anio}";
            liqDataTable.AddCell(CreateCell("PERÍODO:", periodo, true));

            liqDataTable.AddCell(CreateCell("CONCEPTO:", liquidacion.Concepto, false));

            document.Add(liqDataTable);
            document.Add(new LineSeparator(new SolidLine(0.5f)).SetMarginTop(5).SetMarginBottom(5));

            // --- 3. Tabla de Datos del Empleado ---
            float[] empDataColWidths = { 183.33f, 183.33f }; // 3 columnas iguales
            Table empDataTable = new Table(empDataColWidths);
            empDataTable.SetMarginBottom(10); // Margen inferior para separarlo del detalle

            // Fila 1: Nombre Completo y DNI
            string nombreCompleto = $"{liquidacion.Empleado.Nombre} {liquidacion.Empleado.Apellido}";
            empDataTable.AddCell(CreateCell("APELLIDO Y NOMBRE:", nombreCompleto, true));
            empDataTable.AddCell(CreateCell("DNI:", liquidacion.Empleado.Dni, true));

            // Fila 2: Fechas
            string fechaAlta = liquidacion.Empleado.FechaAlta.ToString("dd/MM/yyyy");
            string fechaIngreso = liquidacion.Empleado.FechaIngreso.ToString("dd/MM/yyyy");

            empDataTable.AddCell(CreateCell("FECHA DE ALTA:", fechaAlta, true));
            empDataTable.AddCell(CreateCell("FECHA DE INGRESO:", fechaIngreso, true));
            // Espacio en blanco
            empDataTable.AddCell(CreateCell("", "", false));

            document.Add(empDataTable);
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
