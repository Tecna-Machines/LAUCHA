using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetRecibos;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal class PdfReciboMultipleRenderer : IReciboMultipleRenderer
    {
        private Document? _document;
        public byte[] Render(IEnumerable<GetLiquidacionByIdResponse> liquidaciones)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();

                        using (Document document = new Document(pdf, ps))
                        {
                            _document = document;
                            _document.SetFontSize(10);

                            var first = true;

                            foreach (var liq in liquidaciones)
                            {
                                if (!first)
                                {
                                    // Salto a la proxima pagina
                                    _document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                }

                                CrearReciboLiquidacion(liq);

                                first = false;
                            }

                        }
                    }
                }
                return stream.ToArray();
            }
        }

        public void CrearReciboLiquidacion(GetLiquidacionByIdResponse liq)
        {
            HeaderPdf.AgregarHeader(_document!, liq);
            DetalleRecibo.AgregarDetalleEnBlanco(_document!, liq);
            _document!.Add(new Paragraph("").SetHeight(10f));

            DetalleRecibo.AgregarDetalleEnNegro(_document!, liq);


            _document!.Add(new Paragraph("").SetHeight(10f));
            DetalleRecibo.AgregarDetallePagar(_document!, liq);
        }
    }
}
