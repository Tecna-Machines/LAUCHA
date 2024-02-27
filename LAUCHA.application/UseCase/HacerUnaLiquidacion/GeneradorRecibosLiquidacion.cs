using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.DescuentoDTOs;
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
                Document document = new Document(pdf, PageSize.A4);
                PageSize ps = pdf.GetDefaultPageSize();
                document.SetFontSize(10);


                // Crear tabla para la información
                Table header = this.GenerarTablaHeader(liquidacion);
                document.Add(header);



                Paragraph subtituloRemuBlanca = new Paragraph("sueldo en banco")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();


                Paragraph subtituloRemuNegro = new Paragraph("sueldo en efectivo")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();

                Table tablaBlanco = this.GenerarTablaSueldoBlanco(liquidacion.Items.Retenciones, liquidacion.Items.Remuneraciones);
                Table netoBlanco = this.GenerarTablaMontoNeto(false, liquidacion.TotalPagarBanco);
                Table netoEfectivo = this.GenerarTablaMontoNeto(true, liquidacion.TotalPagarEfectivo);

                Table tablaEfectivo = this.GenerarTablaSueldoEfectivo(liquidacion.Items.Descuentos, liquidacion.Items.Remuneraciones);

                document.Add(subtituloRemuBlanca);
                document.Add(tablaBlanco);
                document.Add(new Paragraph("\n"));
                document.Add(netoBlanco);

                document.Add(new Paragraph("\n"));

                document.Add(subtituloRemuNegro);
                document.Add(tablaEfectivo);


                document.Add(new Paragraph("\n"));
                document.Add(netoEfectivo);


                // Crear una tabla para las firmas
                Table tablaFirmas = new Table(2).UseAllAvailableWidth();
                tablaFirmas.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                // Agregar celdas para las firmas del empleado y el empleador
                tablaFirmas.AddCell(new Cell().Add(new Paragraph("Firma del Empleado:")).SetTextAlignment(TextAlignment.LEFT));
                tablaFirmas.AddCell(new Cell().Add(new Paragraph("Firma del Empleador:")).SetTextAlignment(TextAlignment.LEFT));

                tablaFirmas.SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(),
                                            ps.GetWidth() - document.GetLeftMargin() - document.GetRightMargin());
                document.Add(tablaFirmas);

                // Cerrar el documento
                document.Close();

                return stream.ToArray();
            }

        }

        private Table GenerarTablaSueldoBlanco(List<RetencionDTO> retenciones, List<RemuneracionDTO> remuneraciones)
        {
            Table tablaParteBlanco = new Table(4).UseAllAvailableWidth();

            // Crear celdas de encabezado y establecer el color de fondo
            Cell codigoHeaderCell = new Cell().Add(new Paragraph("cod. operacion")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell descripcionHeaderCell = new Cell().Add(new Paragraph("descripcion")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell fechaHeaderCell = new Cell().Add(new Paragraph("fecha")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell montoHeaderCell = new Cell().Add(new Paragraph("monto")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            // Agregar celdas de encabezado a la tabla
            tablaParteBlanco.AddHeaderCell(codigoHeaderCell);
            tablaParteBlanco.AddHeaderCell(descripcionHeaderCell);
            tablaParteBlanco.AddHeaderCell(fechaHeaderCell);
            tablaParteBlanco.AddHeaderCell(montoHeaderCell);

            var listaRemuneracionesBlanca = remuneraciones.Where(r => r.EsBlanco == true);
            var listaRetenciones = retenciones;

            foreach (RemuneracionDTO remuBlanca in listaRemuneracionesBlanca)
            {
                tablaParteBlanco.AddCell(remuBlanca.Codigo);
                tablaParteBlanco.AddCell(remuBlanca.Descripcion);
                tablaParteBlanco.AddCell(remuBlanca.Fecha);
                tablaParteBlanco.AddCell(remuBlanca.Monto.ToString("C"));

            }

            foreach (RetencionDTO retencion in listaRetenciones)
            {
                tablaParteBlanco.AddCell(retencion.Codigo);
                tablaParteBlanco.AddCell(retencion.Descripcion);
                tablaParteBlanco.AddCell(retencion.Fecha.ToString("dd/MM/yyyy"));
                tablaParteBlanco.AddCell($"-{retencion.Monto.ToString("C")}");

            }

            return tablaParteBlanco;
        }

        private Table GenerarTablaSueldoEfectivo(List<DescuentoDTO> descuentos, List<RemuneracionDTO> remuneraciones)
        {
            var listaRemuneracionesNegro = remuneraciones.Where(r => r.EsBlanco == false);
            var listaDescuentos = descuentos;

            Table tablaParteEfectivo = new Table(4).UseAllAvailableWidth();

            // Crear celdas de encabezado y establecer el color de fondo
            Cell codigoHeaderCell = new Cell().Add(new Paragraph("cod. operacion")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell descripcionHeaderCell = new Cell().Add(new Paragraph("descripcion")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell fechaHeaderCell = new Cell().Add(new Paragraph("fecha")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell montoHeaderCell = new Cell().Add(new Paragraph("monto")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            // Agregar celdas de encabezado a la tabla
            tablaParteEfectivo.AddHeaderCell(codigoHeaderCell);
            tablaParteEfectivo.AddHeaderCell(descripcionHeaderCell);
            tablaParteEfectivo.AddHeaderCell(fechaHeaderCell);
            tablaParteEfectivo.AddHeaderCell(montoHeaderCell);

            foreach (RemuneracionDTO remuEfectivo in listaRemuneracionesNegro)
            {
                tablaParteEfectivo.AddCell(remuEfectivo.Codigo);
                tablaParteEfectivo.AddCell(remuEfectivo.Descripcion);
                tablaParteEfectivo.AddCell(remuEfectivo.Fecha);
                tablaParteEfectivo.AddCell(remuEfectivo.Monto.ToString("C"));
            }

            foreach (DescuentoDTO descuento in listaDescuentos)
            {
                tablaParteEfectivo.AddCell(descuento.Codigo);
                tablaParteEfectivo.AddCell(descuento.Descripcion);
                tablaParteEfectivo.AddCell(descuento.Fecha.ToString("dd/MM/yyyy"));
                tablaParteEfectivo.AddCell(descuento.Monto.ToString("C"));
            }

            return tablaParteEfectivo;
        }

        private Table GenerarTablaMontoNeto(bool esEfecitvo, decimal monto)
        {
            string leyenda = esEfecitvo == true ? "EN EFECTIVO" : "EN EL BANCO";

            Table tablaNeto = new Table(2).UseAllAvailableWidth();
            Cell celdaDescripcion = new Cell().Add(new Paragraph($"TOTAL NETO A PAGAR {leyenda}: "))
                                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            Cell celdaMontoNegro = new Cell().Add(new Paragraph(monto.ToString("C")));

            tablaNeto.AddHeaderCell(celdaDescripcion);
            tablaNeto.AddHeaderCell(celdaMontoNegro);

            return tablaNeto;
        }

        private Table GenerarTablaHeader(LiquidacionDTO liquidacion)
        {
            string periodo = $"{liquidacion.Periodo.Inicio.ToString("dd/MM/yyyy")} - {liquidacion.Periodo.Fin.ToString("dd/MM/yyyy")}";

            Table header = new Table(2).UseAllAvailableWidth();

            // Crear celda para el título que abarca 2 columnas
            Cell celdaTitulo = new Cell(1, 2).Add(new Paragraph("RECIBO DE SUELDO"))
                                             .SetTextAlignment(TextAlignment.CENTER);

            celdaTitulo.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            header.AddHeaderCell(celdaTitulo);

            // Agregar celdas a la tabla
            header.AddHeaderCell(new Cell().Add(new Paragraph("apellido y nombre")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Empleado)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("N° de documento")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Dni)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("monto bruto banco")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.TotalBrutoBanco.ToString("C"))));

            header.AddHeaderCell(new Cell().Add(new Paragraph("monto bruto efectivo")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.TotalBrutoEfectivo.ToString("C"))));

            header.AddHeaderCell(new Cell().Add(new Paragraph("periodo liquidado")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(periodo)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("concepto")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Concepto)));

            return header;
        }

    }
}
