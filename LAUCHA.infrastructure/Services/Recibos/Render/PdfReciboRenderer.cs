using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetRecibo;
using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.infrastructure.Services.Recibos.ReciboUnico;

namespace LAUCHA.infrastructure.Services.Recibos.Render
{
    internal class PdfReciboRenderer : IReciboRenderer
    {

        public byte[] Render(GetLiquidacionByIdResponse liq)
        {

            var recibo = new ReciboSueldo(liq);

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            using var doc = new iText.Layout.Document(pdf);

            doc.Add(TablaHeader.GenerarCabecera(recibo.Liquidacion));
            doc.Add(TablaOficial.Generar(recibo.Liquidacion));

            recibo.IncluirTablaInterna();

            if (recibo.IncluirInterna)
            {
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(TablaInterno.Generar(recibo.Liquidacion));
            }

            if (recibo.Asistencias != null)
            {
                doc.Add(new Paragraph(""));
                doc.Add(TablaAsistencias.Generar(recibo.Asistencias));
            }
            doc.Close();

            return ms.ToArray();
        }



        public byte[] Render(GetLiquidacionByIdResponse liq, GetEmpleadoAsistenciasResponse asistencias)
        {

            var recibo = new ReciboSueldo(liq);
            recibo.AgregarAsistencias(asistencias);

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            using var doc = new iText.Layout.Document(pdf);

            doc.Add(TablaHeader.GenerarCabecera(recibo.Liquidacion));
            doc.Add(TablaOficial.Generar(recibo.Liquidacion));

            recibo.IncluirTablaInterna();

            if (recibo.IncluirInterna)
            {
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(TablaInterno.Generar(recibo.Liquidacion));
            }

            if (recibo.Asistencias != null)
            {
                doc.Add(new Paragraph(""));
                doc.Add(TablaAsistencias.Generar(recibo.Asistencias));
            }
                doc.Close();

            return ms.ToArray();
        }


    }
}
