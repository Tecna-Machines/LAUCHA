using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;

namespace LAUCHA.application.UseCase.GenerarRecibo
{
    public class GeneradorRecibosLiquidacion : IGeneradorRecibos
    {
        private readonly ConvertidorNumeroEnPalabra _GeneradorNumeroPalabra;
        private readonly GeneradorTablasComunes _GeneradorTablasComunes;
        private readonly GeneradorTablasSueldos _GeneradorTablasSueldo;
        private DateTime _FechaIngreso;
        private readonly ILogsApp log;
        public GeneradorRecibosLiquidacion(ILogsApp log)
        {
            _GeneradorNumeroPalabra = new();
            _GeneradorTablasComunes = new();
            _GeneradorTablasSueldo = new();
            this.log = log;
        }

        public byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion, DateTime fechaIngreso)
        {
            log.LogInformation("generando recibo de la liquidacion N: {n}", liquidacion.Codigo);

            _FechaIngreso = fechaIngreso;

            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();
                        iText.Layout.Document document = new iText.Layout.Document(pdf, ps);

                        // Generar contenido de la primera página
                        GenerarPaginaReciboBlanco(document, ps, liquidacion);

                        // Agregar salto de página
                        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                        // Generar contenido de la segunda página
                        GenerarPaginaReciboNegro(document, ps, liquidacion);
                    }
                }

                return stream.ToArray();
            }
        }


        private void GenerarPaginaReciboBlanco(iText.Layout.Document document, PageSize ps, LiquidacionDTO liquidacion)
        {
            iText.Layout.Document primeraPagina = document;

            primeraPagina.Add(_GeneradorTablasComunes.GenerarTablaHeader(liquidacion, _FechaIngreso));
            primeraPagina.Add(new Paragraph("\n"));

            primeraPagina.Add(_GeneradorTablasComunes.GeneralTablaAcuerdo(liquidacion));
            primeraPagina.Add(new Paragraph("\n"));

            Paragraph subtituloRemuBlanca = new Paragraph("Detalle de sueldo")
           .SetTextAlignment(TextAlignment.LEFT)
           .SetFontSize(14)
           .SetBold();

            primeraPagina.Add(subtituloRemuBlanca);

            primeraPagina.Add(_GeneradorTablasSueldo.GenerarTablaSueldoBlanco(liquidacion));
            primeraPagina.Add(new Paragraph("\n"));

            primeraPagina.Add(_GeneradorTablasComunes.GenerarTablaMontoNeto(false, liquidacion.TotalPagarBanco));
            primeraPagina.Add(new Paragraph("\n"));
            primeraPagina.Add(_GeneradorTablasComunes.GenerarTablaFooter(primeraPagina, ps));

        }

        private void GenerarPaginaReciboNegro(iText.Layout.Document document, PageSize ps, LiquidacionDTO liquidacion)
        {
            iText.Layout.Document segundaPagina = document;

            segundaPagina.Add(_GeneradorTablasComunes.GenerarTablaHeader(liquidacion, _FechaIngreso));
            segundaPagina.Add(new Paragraph("\n"));

            segundaPagina.Add(_GeneradorTablasComunes.GeneralTablaAcuerdo(liquidacion));
            segundaPagina.Add(new Paragraph("\n"));

            Paragraph subtituloRemuNegro = new Paragraph("Detalle de sueldo")
           .SetTextAlignment(TextAlignment.LEFT)
           .SetFontSize(14)
           .SetBold();

            segundaPagina.Add(subtituloRemuNegro);

            segundaPagina.Add(_GeneradorTablasSueldo.GenerarTablaSueldoEfectivo(liquidacion));
            segundaPagina.Add(new Paragraph("\n"));
            segundaPagina.Add(_GeneradorTablasComunes.GenerarTablaMontoNeto(true, liquidacion.TotalPagarEfectivo));
            segundaPagina.Add(new Paragraph("\n"));
            segundaPagina.Add(GenerarTablaResumen(liquidacion));
            segundaPagina.Add(new Paragraph("\n"));
            segundaPagina.Add(_GeneradorTablasComunes.GenerarTablaFooter(segundaPagina, ps));

        }

        private Table GenerarTablaResumen(LiquidacionDTO liquidacion)
        {
            decimal totalPagado = liquidacion.TotalPagarBanco + liquidacion.TotalPagarEfectivo;

            Table resumenTable = new Table(2).UseAllAvailableWidth();

            Cell celdaTitulo = new Cell(1, 2).Add(new Paragraph("RESUMEN"))
                                            .SetBold()
                                            .SetTextAlignment(TextAlignment.LEFT);

            celdaTitulo.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            resumenTable.AddHeaderCell(celdaTitulo);

            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph("Total cobrado en deposito")));
            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.TotalPagarBanco.ToString("C"))));

            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph("Total cobrado en efectivo")));
            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.TotalPagarEfectivo.ToString("C"))));

            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph("Total cobrado:")
                                      .SetBold()
                                      .SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));

            resumenTable.AddHeaderCell(new Cell().Add(new Paragraph(totalPagado.ToString("C"))));

            return resumenTable;
        }

    }
}
