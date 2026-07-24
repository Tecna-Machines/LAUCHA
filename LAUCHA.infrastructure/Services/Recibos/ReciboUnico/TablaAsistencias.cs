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
        public static Table Generar(
            GetLiquidacionByIdResponse liquidacion,
            GetEmpleadoAsistenciasResponse? asistencias,
            GetFeriadosMesResponse? feriadosResponse)
        {
            ArgumentNullException.ThrowIfNull(liquidacion);

            IEnumerable<GetFeriadoResponse> feriados =
                feriadosResponse?.Feriados ??
                Enumerable.Empty<GetFeriadoResponse>();

            Table tabla = CrearTabla();

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
                    feriado);
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

            // Los empleados mensuales siempre muestran el mes completo.
            if (!liquidacion.EsQuincenal())
            {
                return (primerDiaMes, ultimoDiaMes);
            }

            // Primera quincena: del día 1 al 15.
            if (liquidacion.Quincena.Nro == 1)
            {
                DateTime finPrimeraQuincena = new(anio, mes, 15);

                return (primerDiaMes, finPrimeraQuincena);
            }

            // Segunda quincena: del día 16 hasta el último día del mes.
            DateTime inicioSegundaQuincena = new(anio, mes, 16);

            return (inicioSegundaQuincena, ultimoDiaMes);
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

            Table tabla = new(columnas);

            // Ocupa la mitad del ancho disponible de la hoja.
            tabla.SetWidth(UnitValue.CreatePercentValue(50));

            // Queda alineada a la izquierda.
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
                $"{fecha:dd/MM} " +
                fecha.ToString("ddd", new CultureInfo("es-AR"));

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
                // Columnas posteriores a Fecha:
                // Ing, Egr, Reg, Ext, Dobl y Tot.
                for (int i = 0; i < 6; i++)
                {
                    tabla.AddCell(CrearCelda(string.Empty));
                }

                return;
            }

            tabla.AddCell(
                CrearCelda(asistencia.Ingreso.ToString("HH:mm")));

            tabla.AddCell(
                CrearCelda(asistencia.Egreso.ToString("HH:mm")));

            tabla.AddCell(
                CrearCelda(asistencia.HsComunes.ToString()));

            tabla.AddCell(
                CrearCelda(asistencia.HsExtra.ToString()));

            tabla.AddCell(
                CrearCelda(asistencia.HsDoble.ToString()));

            tabla.AddCell(
                CrearCelda(asistencia.HsTotales.ToString()));
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