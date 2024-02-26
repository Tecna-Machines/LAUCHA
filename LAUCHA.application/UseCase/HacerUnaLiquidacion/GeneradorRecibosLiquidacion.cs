using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.interfaces;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class GeneradorRecibosLiquidacion : IGeneradorRecibos
    {
        public byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf,PageSize.A4);


                // Crear encabezado con fondo gris
                Table headerTable = new Table(1).UseAllAvailableWidth();
                headerTable.SetBackgroundColor(ColorConstants.LIGHT_GRAY);

                // Agregar celdas al encabezado
                headerTable.AddCell(new Cell().Add(new Paragraph($"Fecha de Liquidación: {liquidacion.Fecha.ToShortDateString()}")));
                headerTable.AddCell(new Cell().Add(new Paragraph($"Código de Liquidación: {liquidacion.Codigo}")));
                headerTable.AddCell(new Cell().Add(new Paragraph($"Empleado: {liquidacion.Empleado}")));

                document.Add(headerTable);
                document.Add(new Paragraph("\n"));


                // Crear tabla para la información
                Table infoTable = new Table(2).UseAllAvailableWidth();

                // Agregar información a la tabla
                infoTable.AddCell("DNI del empleado:").AddCell(liquidacion.Dni);
                infoTable.AddCell("Concepto:").AddCell(liquidacion.Concepto);

                document.Add(infoTable);


                // Agregar tabla de remuneraciones blancas
                Table tablaRemuneracionesBlancas = new Table(4).UseAllAvailableWidth();

                // Crear celdas de encabezado y establecer el color de fondo
                Cell codigoHeaderCell = new Cell().Add(new Paragraph("CODIGO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                Cell descripcionHeaderCell = new Cell().Add(new Paragraph("DESCRIPCION")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                Cell montoHeaderCell = new Cell().Add(new Paragraph("MONTO ($)")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                Cell fechaHeaderCell = new Cell().Add(new Paragraph("FECHA")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

                // Agregar celdas de encabezado a la tabla
                tablaRemuneracionesBlancas.AddHeaderCell(codigoHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(descripcionHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(montoHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(fechaHeaderCell);

                var listaRemuneracionBlancas = liquidacion.Items.Remuneraciones.Where(r => r.EsBlanco == true);

                foreach (RemuneracionDTO remuneracion in listaRemuneracionBlancas)
                {
                    tablaRemuneracionesBlancas.AddCell(remuneracion.Codigo);
                    tablaRemuneracionesBlancas.AddCell(remuneracion.Descripcion);
                    tablaRemuneracionesBlancas.AddCell(remuneracion.Monto.ToString("C"));
                    tablaRemuneracionesBlancas.AddCell(remuneracion.Fecha);
                }


                // Agregar tabla de retenciones
                Table tablaRetenciones = new Table(4).UseAllAvailableWidth();

                // Agregar celdas de encabezado a la tabla
                tablaRetenciones.AddHeaderCell(codigoHeaderCell);
                tablaRetenciones.AddHeaderCell(descripcionHeaderCell);
                tablaRetenciones.AddHeaderCell(montoHeaderCell);
                tablaRetenciones.AddHeaderCell(fechaHeaderCell);

                foreach (RetencionDTO retencion in liquidacion.Items.Retenciones)
                {
                    tablaRetenciones.AddCell(retencion.Codigo);
                    tablaRetenciones.AddCell(retencion.Descripcion);
                    tablaRetenciones.AddCell(retencion.Monto.ToString("C"));
                    tablaRetenciones.AddCell(retencion.Fecha.ToString("dd/MM/yyyy"));
                }

                // Agregar celdas de encabezado a la tabla
                tablaRemuneracionesBlancas.AddHeaderCell(codigoHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(descripcionHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(montoHeaderCell);
                tablaRemuneracionesBlancas.AddHeaderCell(fechaHeaderCell);

                // Agregar tabla de remuneracion en negro
                Table tablaRemuneracionNegro = new Table(4).UseAllAvailableWidth();
                tablaRemuneracionNegro.AddHeaderCell(codigoHeaderCell);
                tablaRemuneracionNegro.AddHeaderCell(descripcionHeaderCell);
                tablaRemuneracionNegro.AddHeaderCell(montoHeaderCell);
                tablaRemuneracionNegro.AddHeaderCell(fechaHeaderCell);

                var listaRemuneracionNegro = liquidacion.Items.Remuneraciones.Where(r => r.EsBlanco == false);


                foreach (RemuneracionDTO remuNegro in listaRemuneracionNegro)
                {
                    tablaRemuneracionNegro.AddCell(remuNegro.Codigo);
                    tablaRemuneracionNegro.AddCell(remuNegro.Descripcion);
                    tablaRemuneracionNegro.AddCell(remuNegro.Monto.ToString("C"));
                    tablaRemuneracionNegro.AddCell(remuNegro.Fecha);

                }

                Table tablaPagarNegro = new Table(2).UseAllAvailableWidth();
                Cell celdaDescripcion = new Cell().Add(new Paragraph("TOTAL A PAGAR EFECTIVO: ")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                Cell celdaMontoNegro = new Cell().Add(new Paragraph(liquidacion.TotalPagarEfectivo.ToString("C")));

                tablaPagarNegro.AddHeaderCell(celdaDescripcion);
                tablaPagarNegro.AddHeaderCell(celdaMontoNegro);

                Table tablaPagarBlanco = new Table(2).UseAllAvailableWidth();
                Cell celdaDescripcionB = new Cell().Add(new Paragraph("TOTAL A PAGAR EN BANCO: ")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                Cell celdaMontoBlanco = new Cell().Add(new Paragraph(liquidacion.TotalPagarBanco.ToString("C")));

                tablaPagarBlanco.AddHeaderCell(celdaDescripcionB);
                tablaPagarBlanco.AddHeaderCell(celdaMontoBlanco);


                Paragraph subtituloRemuBlanca = new Paragraph("sueldo formal")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();

                Paragraph remuneracionSub = new Paragraph("Remuneraciones")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(10)
                           .SetBold();

                Paragraph retenSub = new Paragraph("Retenciones")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(10)
                           .SetBold();

                Paragraph subtituloRemuNegro = new Paragraph("sueldo informal")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();

                document.Add(subtituloRemuBlanca);
                document.Add(remuneracionSub);
                document.Add(tablaRemuneracionesBlancas);
                document.Add(new Paragraph("\n"));
                document.Add(retenSub);
                document.Add(tablaRetenciones);
                document.Add(new Paragraph("\n"));
                document.Add(tablaPagarBlanco);

                document.Add(new Paragraph("\n"));

                document.Add(subtituloRemuNegro);
                document.Add(tablaRemuneracionNegro);
                document.Add(new Paragraph("\n"));
                document.Add(tablaPagarNegro);

                // Cerrar el documento
                document.Close();

                return stream.ToArray();
            }
        }
    }
}
