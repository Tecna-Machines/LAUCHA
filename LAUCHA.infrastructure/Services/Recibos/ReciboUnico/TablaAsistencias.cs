using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using System.Globalization;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaAsistencias
    {
        public static Table Generar(GetEmpleadoAsistenciasResponse asistencias)
        {
            float[] pointColumnWidths = { 2, 1, 1, 1, 1, 1 };

            Table tablaAsistencias = new Table(pointColumnWidths);

            tablaAsistencias.UseAllAvailableWidth();
            tablaAsistencias.SetFontSize(8);
            AgregarCabecera(tablaAsistencias);

            int mes = asistencias.Asistencias.First().Ingreso.Month;
            int anio = asistencias.Asistencias.First().Ingreso.Year;

            DateTime inicio = new DateTime(anio, mes, 1);
            DateTime finMes = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));

            for (var day = inicio; day <= finMes; day = day.AddDays(1))
            {
                var asistencia = asistencias.Asistencias.FirstOrDefault(d => d.Ingreso.Date == day.Date);

                if (asistencia is not null)
                {
                    AgregarItemAsistencia(tablaAsistencias, asistencia);
                }
                else
                {
                    AgregarDiaVacio(tablaAsistencias, day);
                }


            }

            return tablaAsistencias;
        }

        private static void AgregarItemAsistencia(Table tablaAsistencia, GetEmpleadoAsistenciaResponse item)
        {
            string fechaStr = item.Ingreso.ToString("dd/MM/yyyy");
            string diaStr = item.Ingreso.ToString("dddd", new CultureInfo("es-AR"));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph($"{diaStr} {fechaStr}"))
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.Ingreso.ToString("HH:mm")))
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.Egreso.ToString("HH:mm")))
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.HsComunes.ToString()))
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.HsExtra.ToString()))
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.HsTotales.ToString()))
                .SetTextAlignment(TextAlignment.LEFT));

        }

        private static void AgregarDiaVacio(Table tablaAsistencia, DateTime day)
        {
            string fechaStr = day.ToString("dd/MM/yyyy");
            string diaStr = day.ToString("dddd", new CultureInfo("es-AR"));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph($"{diaStr} {fechaStr}"))
                .SetTextAlignment(TextAlignment.LEFT));


            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph())
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph())
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph())
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph())
                .SetTextAlignment(TextAlignment.LEFT));

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph())
                .SetTextAlignment(TextAlignment.LEFT));

        }

        private static void AgregarCabecera(Table tablaAsistencias)
        {
            Color colorFondo = ColorConstants.LIGHT_GRAY;
            TextAlignment alineacionCentro = TextAlignment.CENTER;

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFontFamilies.HELVETICA);

            Func<string, TextAlignment, Cell> CrearCeldaEncabezado = (texto, alineacion) =>
            {
                return new Cell()
                    .Add(new Paragraph(texto).SetFont(boldFont).SetFontSize(9))
                    .SetBackgroundColor(colorFondo)
                    .SetTextAlignment(alineacion)
                    .SetPadding(5);
            };

            tablaAsistencias.AddCell(CrearCeldaEncabezado("Fecha", TextAlignment.LEFT));
            tablaAsistencias.AddCell(CrearCeldaEncabezado("Ingreso (HH:mm)", alineacionCentro));
            tablaAsistencias.AddCell(CrearCeldaEncabezado("Egreso (HH:mm)", alineacionCentro));
            tablaAsistencias.AddCell(CrearCeldaEncabezado("Hs regular", alineacionCentro));
            tablaAsistencias.AddCell(CrearCeldaEncabezado("Hs Extra", alineacionCentro));
            tablaAsistencias.AddCell(CrearCeldaEncabezado("Hs totales", alineacionCentro));
        }
    }
}
