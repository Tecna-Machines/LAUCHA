using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using System.Globalization;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal static class DetalleAsistencias
    {
        public static void AgregarDetalleAsistencias(Document doc, GetEmpleadoAsistenciasResponse asistencias)
        {
            float[] pointColumnWidths = { 150F, 150F, 150F, 150F, 150F, 150F,150F };

            Table tablaAsistencias = new Table(pointColumnWidths);

            int mes = asistencias.Asistencias.First().Ingreso.Month;
            int anio = asistencias.Asistencias.First().Ingreso.Year;

            DateTime inicio = new DateTime(anio,mes,1);
            DateTime finMes = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));

            for(var day = inicio; day <= finMes; day =  day.AddDays(1))
            {
                var asistencia = asistencias.Asistencias.FirstOrDefault(d => d.Ingreso.Date == day.Date);

                if (asistencia is not null)
                {
                    AgregarItemAsistencia(tablaAsistencias,asistencia);
                }
                else
                {
                    AgregarDiaVacio(tablaAsistencias, day);
                }

                
            }
     

            doc.Add(tablaAsistencias);
        }

        private static void AgregarItemAsistencia(Table tablaAsistencia, GetEmpleadoAsistenciaResponse item)
        {
            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.Ingreso.ToString("dd/MM/yyyy")))
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

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(item.Ingreso.ToString("dddd", new CultureInfo("es-AR"))))
                .SetTextAlignment(TextAlignment.LEFT));
        }

        private static void AgregarDiaVacio(Table tablaAsistencia, DateTime day)
        {
            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(day.ToString("dd/MM/yyyy")))
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

            tablaAsistencia.AddCell(new Cell()
                .Add(new Paragraph(day.ToString("dddd", new CultureInfo("es-AR"))))
                .SetTextAlignment(TextAlignment.LEFT));
        }
    }
}
