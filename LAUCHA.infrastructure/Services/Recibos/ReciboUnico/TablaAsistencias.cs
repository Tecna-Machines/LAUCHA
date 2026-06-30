using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;
using System.Globalization;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal static class TablaAsistencias
    {
        public static Table Generar(
            GetEmpleadoAsistenciasResponse? asistencias,
            GetFeriadosMesResponse? feriadosResponse)
        {
            IEnumerable<GetFeriadoResponse> feriados =
                feriadosResponse?.Feriados ??
                Enumerable.Empty<GetFeriadoResponse>();

            Table tabla = CrearTabla();

            if (asistencias is not null && asistencias.Asistencias.Any())
            {
                int mes = asistencias.Asistencias.First().Ingreso.Month;
                int anio = asistencias.Asistencias.First().Ingreso.Year;

                DateTime inicio = new(anio, mes, 1);
                DateTime finMes = new(anio, mes, DateTime.DaysInMonth(anio, mes));

                for (DateTime day = inicio; day <= finMes; day = day.AddDays(1))
                {
                    var asistencia = asistencias.Asistencias
                        .FirstOrDefault(a => a.Ingreso.Date == day.Date);

                    var feriado = ObtenerFeriadoDelDia(day, feriados);

                    AgregarFila(
                        tabla,
                        day,
                        asistencia,
                        feriado);
                }
            }

            return tabla;
        }

        private static Table CrearTabla()
        {
            float[] columnas =
            {
                3.5f, // Fecha
                1f,   // Ing
                1f,   // Egr
                1f,   // Reg
                1f,   // Ext
                1f,   // Dobl
                1f    // Tot
            };

            Table tabla = new Table(columnas);

            // Ocupa la mitad del ancho disponible de la hoja
            tabla.SetWidth(UnitValue.CreatePercentValue(50));

            // La deja alineada a la izquierda
            tabla.SetHorizontalAlignment(HorizontalAlignment.LEFT);

            tabla.SetFontSize(6);
            tabla.SetMarginTop(0);
            tabla.SetMarginBottom(0);

            AgregarCabecera(tabla);

            return tabla;
        }

        private static void AgregarFila(
            Table tabla,
            DateTime fecha,
            GetEmpleadoAsistenciaResponse? asistencia,
            GetFeriadoResponse? feriado)
        {
            string fechaTexto =
                $"{fecha:dd/MM} {fecha.ToString("ddd", new CultureInfo("es-AR"))}";

            if (feriado is not null)
            {
                fechaTexto += $" {feriado.Descripcion}";
            }

            tabla.AddCell(
                CrearCelda(
                    fechaTexto,
                    TextAlignment.LEFT));

            if (asistencia is null)
            {
                // Son 6 columnas después de Fecha:
                // Ing, Egr, Reg, Ext, Dobl, Tot
                for (int i = 0; i < 6; i++)
                {
                    tabla.AddCell(CrearCelda(string.Empty));
                }

                return;
            }

            tabla.AddCell(CrearCelda(asistencia.Ingreso.ToString("HH:mm")));
            tabla.AddCell(CrearCelda(asistencia.Egreso.ToString("HH:mm")));
            tabla.AddCell(CrearCelda(asistencia.HsComunes.ToString()));
            tabla.AddCell(CrearCelda(asistencia.HsExtra.ToString()));
            tabla.AddCell(CrearCelda(asistencia.HsDoble.ToString()));
            tabla.AddCell(CrearCelda(asistencia.HsTotales.ToString()));
        }

        private static Cell CrearCelda(
            string texto,
            TextAlignment alineacion = TextAlignment.CENTER)
        {
            return new Cell()
                .Add(new Paragraph(texto))
                .SetTextAlignment(alineacion)
                .SetPadding(2);
        }

        private static void AgregarCabecera(Table tabla)
        {
            PdfFont font = PdfFontFactory.CreateFont(
                StandardFontFamilies.HELVETICA);

            Cell Header(string texto)
            {
                return new Cell()
                    .Add(
                        new Paragraph(texto)
                            .SetFont(font)
                            .SetFontSize(6))
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(3);
            }

            tabla.AddCell(Header("Fecha"));
            tabla.AddCell(Header("Ing"));
            tabla.AddCell(Header("Egr"));
            tabla.AddCell(Header("Reg"));
            tabla.AddCell(Header("Ext"));
            tabla.AddCell(Header("Dobl"));
            tabla.AddCell(Header("Tot"));
        }

        private static GetFeriadoResponse? ObtenerFeriadoDelDia(
            DateTime day,
            IEnumerable<GetFeriadoResponse> feriados)
        {
            return feriados.FirstOrDefault(f =>
                (!f.SeRepite && f.Fecha.Date == day.Date) ||
                (f.SeRepite &&
                 f.Fecha.Day == day.Day &&
                 f.Fecha.Month == day.Month));
        }
    }
}