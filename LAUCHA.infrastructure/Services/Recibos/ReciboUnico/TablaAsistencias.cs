using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using System.Globalization;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal static class TablaAsistencias
    {
        private static readonly CultureInfo CulturaArgentina =
            new("es-AR");

        public static Table Generar(
            GetLiquidacionByIdResponse liquidacion,
            GetEmpleadoAsistenciasResponse? asistencias,
            GetFeriadosMesResponse? feriadosResponse)
        {
            ArgumentNullException.ThrowIfNull(liquidacion);

            IEnumerable<GetFeriadoResponse> feriados =
                feriadosResponse?.Feriados ??
                Enumerable.Empty<GetFeriadoResponse>();

            bool formatoCompacto = !liquidacion.EsQuincenal();

            Table tabla = CrearTabla(formatoCompacto);

            var periodo = ObtenerPeriodo(liquidacion);

            for (
                DateTime dia = periodo.Inicio;
                dia <= periodo.Fin;
                dia = dia.AddDays(1))
            {
                GetEmpleadoAsistenciaResponse? asistencia =
                    asistencias?.Asistencias.FirstOrDefault(
                        a => a.Ingreso.Date == dia.Date);

                GetFeriadoResponse? feriado =
                    ObtenerFeriadoDelDia(dia, feriados);

                AgregarFila(
                    tabla,
                    dia,
                    asistencia,
                    feriado,
                    formatoCompacto);
            }

            return tabla;
        }

        private static (DateTime Inicio, DateTime Fin) ObtenerPeriodo(
            GetLiquidacionByIdResponse liquidacion)
        {
            int anio = liquidacion.Quincena.Anio;
            int mes = liquidacion.Quincena.Mes;

            DateTime primerDiaMes = new(anio, mes, 1);

            DateTime ultimoDiaMes = new(
                anio,
                mes,
                DateTime.DaysInMonth(anio, mes));

            // Los empleados mensuales muestran el mes completo.
            if (!liquidacion.EsQuincenal())
            {
                return (primerDiaMes, ultimoDiaMes);
            }

            // Primera quincena: del día 1 al 15.
            if (liquidacion.Quincena.Nro == 1)
            {
                DateTime finPrimeraQuincena = new(
                    anio,
                    mes,
                    15);

                return (
                    primerDiaMes,
                    finPrimeraQuincena);
            }

            // Segunda quincena: desde el día 16 hasta fin de mes.
            DateTime inicioSegundaQuincena = new(
                anio,
                mes,
                16);

            return (
                inicioSegundaQuincena,
                ultimoDiaMes);
        }

        private static Table CrearTabla(bool formatoCompacto)
        {
            float[] columnas =
            {
                3.5f, // Fecha
                1f,   // Ingreso
                1f,   // Egreso
                1f,   // Horas regulares
                1f,   // Horas extra
                1f,   // Horas dobles
                1f    // Total
            };

            Table tabla = new(columnas);

            tabla.SetWidth(
                UnitValue.CreatePercentValue(70));

            tabla.SetHorizontalAlignment(
                HorizontalAlignment.LEFT);

            tabla.SetFontSize(
                formatoCompacto ? 10 : 11);

            tabla.SetMarginTop(0);
            tabla.SetMarginBottom(0);

            /*
             * Evita que la tabla sea dividida entre páginas.
             *
             * Para los empleados mensuales se utiliza el formato compacto
             * para que el mes completo pueda entrar en la página actual.
             */
            tabla.SetKeepTogether(true);

            AgregarCabecera(
                tabla,
                formatoCompacto);

            return tabla;
        }

        private static void AgregarFila(
            Table tabla,
            DateTime fecha,
            GetEmpleadoAsistenciaResponse? asistencia,
            GetFeriadoResponse? feriado,
            bool formatoCompacto)
        {
            string fechaTexto =
                $"{fecha:dd/MM} " +
                fecha.ToString("ddd", CulturaArgentina);

            if (feriado is not null)
            {
                fechaTexto += $" {feriado.Descripcion}";
            }

            tabla.AddCell(
                CrearCelda(
                    fechaTexto,
                    formatoCompacto,
                    TextAlignment.LEFT));

            if (asistencia is null)
            {
                // Ing, Egr, Reg, Ext, Dobl y Tot.
                for (int i = 0; i < 6; i++)
                {
                    tabla.AddCell(
                        CrearCelda(
                            string.Empty,
                            formatoCompacto));
                }

                return;
            }

            tabla.AddCell(
                CrearCelda(
                    asistencia.Ingreso.ToString("HH:mm"),
                    formatoCompacto));

            tabla.AddCell(
                CrearCelda(
                    asistencia.Egreso.ToString("HH:mm"),
                    formatoCompacto));

            tabla.AddCell(
                CrearCelda(
                    asistencia.HsComunes.ToString(),
                    formatoCompacto));

            tabla.AddCell(
                CrearCelda(
                    asistencia.HsExtra.ToString(),
                    formatoCompacto));

            tabla.AddCell(
                CrearCelda(
                    asistencia.HsDoble.ToString(),
                    formatoCompacto));

            tabla.AddCell(
                CrearCelda(
                    asistencia.HsTotales.ToString(),
                    formatoCompacto));
        }

        private static Cell CrearCelda(
            string texto,
            bool formatoCompacto,
            TextAlignment alineacion = TextAlignment.CENTER)
        {
            float paddingVertical =
                formatoCompacto ? 0.6f : 1.2f;

            Paragraph parrafo = new Paragraph(texto ?? string.Empty)
                .SetMargin(0)
                .SetMultipliedLeading(
                    formatoCompacto ? 0.85f : 0.95f);

            return new Cell()
                .Add(parrafo)
                .SetTextAlignment(alineacion)
                .SetVerticalAlignment(
                    VerticalAlignment.MIDDLE)
                .SetPaddingTop(paddingVertical)
                .SetPaddingBottom(paddingVertical)
                .SetPaddingLeft(1.5f)
                .SetPaddingRight(1.5f);
        }

        private static void AgregarCabecera(
            Table tabla,
            bool formatoCompacto)
        {
            PdfFont font = PdfFontFactory.CreateFont(
                StandardFontFamilies.HELVETICA);

            float tamanioFuente =
                formatoCompacto ? 8 : 9;

            float paddingVertical =
                formatoCompacto ? 1f : 2f;

            Cell Header(string texto)
            {
                Paragraph parrafo = new Paragraph(texto)
                    .SetFont(font)
                    .SetFontSize(tamanioFuente)
                    .SetMargin(0)
                    .SetMultipliedLeading(0.9f);

                return new Cell()
                    .Add(parrafo)
                    .SetBackgroundColor(
                        ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(
                        TextAlignment.CENTER)
                    .SetVerticalAlignment(
                        VerticalAlignment.MIDDLE)
                    .SetPaddingTop(paddingVertical)
                    .SetPaddingBottom(paddingVertical)
                    .SetPaddingLeft(1f)
                    .SetPaddingRight(1f);
            }

            tabla.AddHeaderCell(Header("Fecha"));
            tabla.AddHeaderCell(Header("Ing"));
            tabla.AddHeaderCell(Header("Egr"));
            tabla.AddHeaderCell(Header("Reg"));
            tabla.AddHeaderCell(Header("Ext"));
            tabla.AddHeaderCell(Header("Dobl"));
            tabla.AddHeaderCell(Header("Tot"));
        }

        private static GetFeriadoResponse? ObtenerFeriadoDelDia(
            DateTime dia,
            IEnumerable<GetFeriadoResponse> feriados)
        {
            return feriados.FirstOrDefault(feriado =>
                (!feriado.SeRepite &&
                 feriado.Fecha.Date == dia.Date) ||
                (feriado.SeRepite &&
                 feriado.Fecha.Day == dia.Day &&
                 feriado.Fecha.Month == dia.Month));
        }
    }
}