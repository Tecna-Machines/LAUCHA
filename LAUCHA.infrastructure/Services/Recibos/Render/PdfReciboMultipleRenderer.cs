using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetRecibos;
using LAUCHA.infrastructure.Services.Recibos.ReciboUnico;

namespace LAUCHA.infrastructure.Services.Recibos.Render
{
    internal sealed class PdfReciboMultipleRenderer : IReciboMultipleRenderer
    {
        private readonly IGetEmpleadoAsistencias _asistenciasEmpleado;

        public PdfReciboMultipleRenderer(IGetEmpleadoAsistencias asistenciasEmpleados)
        {
            _asistenciasEmpleado = asistenciasEmpleados;
        }

        public async Task<byte[]> Render(IEnumerable<GetLiquidacionByIdResponse> liquidaciones)
        {
            using var stream = new MemoryStream();
            using var writer = new PdfWriter(stream);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf);

            document.SetFontSize(10);

            bool first = true;

            foreach (var liq in liquidaciones)
            {
                if (!first)
                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                await RenderReciboAsync(document, liq);

                first = false;
            }

            document.Close();
            return stream.ToArray();
        }

        private async Task RenderReciboAsync(Document doc, GetLiquidacionByIdResponse liq)
        {
            var recibo = new ReciboSueldo(liq);
            var asistencias = await GetAsistencias(liq);

            recibo.AgregarAsistencias(asistencias.Value);

            doc.Add(TablaHeader.GenerarCabecera(recibo.Liquidacion));
            doc.Add(TablaOficial.Generar(recibo.Liquidacion));

            recibo.IncluirTablaInterna();

            if (recibo.IncluirSueldoInterno)
            {
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(TablaInterno.Generar(recibo.Liquidacion));
            }

            if (recibo.Asistencias != null)
            {
                doc.Add(new Paragraph().SetMarginTop(8));
                doc.Add(TablaAsistencias.Generar(recibo.Asistencias, recibo.Feriados));
            }
        }

        public async Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetLiquidacionByIdResponse liq)
        {
            DateTime inicioMes = new DateTime(liq.Quincena.Anio, liq.Quincena.Mes, 1);
            DateTime finMes = new DateTime(liq.Quincena.Anio, liq.Quincena.Mes, DateTime.DaysInMonth(liq.Quincena.Anio, liq.Quincena.Mes));

            var resultAsistencia = await _asistenciasEmpleado.GetAsistencias(new GetEmpleadoAsistenciaRequest(liq.Empleado.Dni, inicioMes, finMes));

            return resultAsistencia;
        }
    }

}
