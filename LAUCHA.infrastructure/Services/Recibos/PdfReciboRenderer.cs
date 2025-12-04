using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetRecibo;

namespace LAUCHA.infrastructure.Services.Recibos
{
    internal class PdfReciboRenderer : IReciboRenderer
    {
        public byte[] Render(GetLiquidacionByIdResponse liq)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();
                        iText.Layout.Document document = new iText.Layout.Document(pdf, ps);
                        document.SetFontSize(10);

                    }
                }

                return stream.ToArray();
            }
        }


    }
}
