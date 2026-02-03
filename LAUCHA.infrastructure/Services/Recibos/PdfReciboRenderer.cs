using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetRecibo;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal class PdfReciboRenderer : IReciboRenderer
    {
        private GetLiquidacionByIdResponse? _liquidacion;
        private Document? _document;

        public byte[] Render(GetLiquidacionByIdResponse liq)
        {
            _liquidacion = liq;

            return CrearRecibo();
        }

        private byte[] CrearRecibo()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();

                        using (Document document = new iText.Layout.Document(pdf, ps))
                        {
                            _document = document;
                            _document.SetFontSize(10);

                            AgregarHeader();
                            AgregarDetalleEnBlanco();
                            AgregarDetalleEnNegro();
                            AgregarDetalleMontoNeto();
                        }
                    }
                }
                return stream.ToArray();
            }
        }

        public byte[] Render(GetLiquidacionByIdResponse liquidacion, GetEmpleadoAsistenciasResponse asistencias)
        {
            _liquidacion = liquidacion;

            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();

                        using (Document document = new iText.Layout.Document(pdf, ps))
                        {
                            _document = document;
                            _document.SetFontSize(10);

                            AgregarHeader();
                            AgregarDetalleEnBlanco();
                            AgregarDetalleEnNegro();
                            AgregarDetalleMontoNeto();
                            AgregarDetalleAsistencias(asistencias);

                        }
                    }
                }
                return stream.ToArray();
            }
        }


        private void AgregarHeader()
        {
            HeaderPdf.AgregarHeader(_document!, _liquidacion!);
        }

        private void AgregarDetalleEnBlanco()
        {
            DetalleRecibo.AgregarDetalleEnBlanco(_document!, _liquidacion!);
            _document!.Add(new Paragraph("").SetHeight(10f));
        }

        private void AgregarDetalleEnNegro()
        {
            DetalleRecibo.AgregarDetalleEnNegro(_document!, _liquidacion!);
        }

        private void AgregarDetalleMontoNeto()
        {
            _document!.Add(new Paragraph("").SetHeight(10f));
            DetalleRecibo.AgregarDetallePagar(_document!, _liquidacion!);
        }

        private void AgregarDetalleAsistencias(GetEmpleadoAsistenciasResponse asistencias)
        {
            _document!.Add(new Paragraph("").SetHeight(10f));
            DetalleAsistencias.AgregarDetalleAsistencias(_document!, asistencias);
        }

    }
}
