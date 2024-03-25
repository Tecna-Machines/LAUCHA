using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class GeneradorRecibosLiquidacion : IGeneradorRecibos
    {
        private readonly ConvertidorNumeroEnPalabra _GeneradorNumeroPalabra;
        private DateTime _FechaIngreso;
        public GeneradorRecibosLiquidacion()
        {
            _GeneradorNumeroPalabra = new();
        }

        public byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion,DateTime fechaIngreso)
        {
            _FechaIngreso = fechaIngreso;

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

                Table acuerdo = this.GeneralTablaAcuerdo(liquidacion);

                document.Add(new Paragraph("\n"));
                document.Add(acuerdo);

                Paragraph subtituloRemuBlanca = new Paragraph("sueldo en banco")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();


                Paragraph subtituloRemuNegro = new Paragraph("sueldo en efectivo")
                           .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                           .SetFontSize(14)
                           .SetBold();

                Table tablaBlanco = this.GenerarTablaSueldoBlanco(liquidacion.Items.Retenciones, liquidacion.Items.Remuneraciones,liquidacion.Items.NoRemuneraciones);
                Table netoBlanco = this.GenerarTablaMontoNeto(false, liquidacion.TotalPagarBanco);
                Table netoEfectivo = this.GenerarTablaMontoNeto(true, liquidacion.TotalPagarEfectivo);

                Table tablaEfectivo = this.GenerarTablaSueldoEfectivo(liquidacion.Items.Descuentos, liquidacion.Items.Remuneraciones);

                document.Add(subtituloRemuBlanca);
                document.Add(tablaBlanco);
                document.Add(new Paragraph("\n"));
                document.Add(netoBlanco);

                string montoTextoNeto = _GeneradorNumeroPalabra.ConvertirDecimalPalabra(liquidacion.TotalPagarBanco);
                Table tablaMontoText = new Table(1).UseAllAvailableWidth();
                tablaMontoText.AddCell(new Paragraph("Son: "+montoTextoNeto));

                document.Add(tablaMontoText);
                document.Add(new Paragraph("\n"));

                document.Add(subtituloRemuNegro);
                document.Add(tablaEfectivo);


                document.Add(new Paragraph("\n"));
                document.Add(netoEfectivo);

                document.Add(new Paragraph("\n"));
                document.Add(GenerarTablaResumen(liquidacion));


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

        private Table GenerarTablaSueldoBlanco(List<RetencionDTO> retenciones,
                                               List<RemuneracionDTO> remuneraciones,
                                               List<NoRemuneracionDTO> noRemuneraciones)
        {
            Table tablaParteBlanco = new Table(4).UseAllAvailableWidth();

            // Crear celdas de encabezado y establecer el color de fondo
            Cell descripcionHeaderCell = new Cell().Add(new Paragraph("DESCRIPCION")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell remuHeaderCell = new Cell().Add(new Paragraph("REMUNERATIVO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell noRemuHeaderCell = new Cell().Add(new Paragraph("NO REMUNERATIVO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell descuentoHeaderCell = new Cell().Add(new Paragraph("DESCUENTO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            // Agregar celdas de encabezado a la tabla
            tablaParteBlanco.AddHeaderCell(descripcionHeaderCell);
            tablaParteBlanco.AddHeaderCell(remuHeaderCell);
            tablaParteBlanco.AddHeaderCell(noRemuHeaderCell);
            tablaParteBlanco.AddHeaderCell(descuentoHeaderCell);

            var listaRemuneracionesBlanca = remuneraciones.Where(r => r.EsBlanco == true);
            var listaRetenciones = retenciones;

            decimal totalRemunerativo = 0;
            decimal totalNoRemunerativo = 0;
            decimal totalRetenciones = 0;
;
            foreach (RemuneracionDTO remuBlanca in listaRemuneracionesBlanca)
            {
                tablaParteBlanco.AddCell(remuBlanca.Descripcion);
                tablaParteBlanco.AddCell(remuBlanca.Monto.ToString("C"));
                tablaParteBlanco.AddCell("");
                tablaParteBlanco.AddCell("");

                totalRemunerativo += remuBlanca.Monto;

            }

            foreach(NoRemuneracionDTO noRemuBlanca in noRemuneraciones)
            {
                tablaParteBlanco.AddCell(noRemuBlanca.Descripcion);
                tablaParteBlanco.AddCell("");
                tablaParteBlanco.AddCell(noRemuBlanca.Monto.ToString("C"));
                tablaParteBlanco.AddCell("");

                totalNoRemunerativo += noRemuBlanca.Monto;

            }

            foreach (RetencionDTO retencion in listaRetenciones)
            {
                tablaParteBlanco.AddCell(retencion.Descripcion);
                tablaParteBlanco.AddCell("");
                tablaParteBlanco.AddCell("");
                tablaParteBlanco.AddCell($"{retencion.Monto.ToString("C")}");

                totalRetenciones += retencion.Monto;

            }

            tablaParteBlanco.AddCell((new Paragraph("SUBTOTALES:").SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
            tablaParteBlanco.AddCell(totalRemunerativo.ToString("C"));
            tablaParteBlanco.AddCell(totalNoRemunerativo.ToString("C"));
            tablaParteBlanco.AddCell(totalRetenciones.ToString("C"));

            return tablaParteBlanco;
        }

        private Table GenerarTablaSueldoEfectivo(List<DescuentoDTO> descuentos, List<RemuneracionDTO> remuneraciones)
        {
            var listaRemuneracionesNegro = remuneraciones.Where(r => r.EsBlanco == false);
            var listaDescuentos = descuentos;

            Table tablaParteEfectivo = new Table(3).UseAllAvailableWidth();

            // Crear celdas de encabezado y establecer el color de fondo
            Cell descripcionHeaderCell = new Cell().Add(new Paragraph("DESCRIPCION")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell fechaHeaderCell = new Cell().Add(new Paragraph("FECHA")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell montoHeaderCell = new Cell().Add(new Paragraph("MONTO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            // Agregar celdas de encabezado a la tabla
            tablaParteEfectivo.AddHeaderCell(descripcionHeaderCell);
            tablaParteEfectivo.AddHeaderCell(fechaHeaderCell);
            tablaParteEfectivo.AddHeaderCell(montoHeaderCell);

            foreach (RemuneracionDTO remuEfectivo in listaRemuneracionesNegro)
            {
                tablaParteEfectivo.AddCell(remuEfectivo.Descripcion);
                tablaParteEfectivo.AddCell(remuEfectivo.Fecha);
                tablaParteEfectivo.AddCell(remuEfectivo.Monto.ToString("C"));
            }

            foreach (DescuentoDTO descuento in listaDescuentos)
            {
                tablaParteEfectivo.AddCell(descuento.Descripcion);
                tablaParteEfectivo.AddCell(descuento.Fecha.ToString("dd/MM/yyyy"));
                tablaParteEfectivo.AddCell($"- {descuento.Monto.ToString("C")}");
            }

            return tablaParteEfectivo;
        }

        private Table GenerarTablaMontoNeto(bool esEfecitvo, decimal monto)
        {
            string leyenda = esEfecitvo == true ? "EFECTIVO" : "DEPOSITO";

            Table tablaNeto = new Table(2).UseAllAvailableWidth();
            Cell celdaDescripcion = new Cell().Add(new Paragraph($"TOTAL NETO A PAGAR EN {leyenda}: "))
                                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                                    .SetTextAlignment(TextAlignment.RIGHT);

            Cell celdaMontoNegro = new Cell().Add(new Paragraph(monto.ToString("C")));

            tablaNeto.AddHeaderCell(celdaDescripcion);
            tablaNeto.AddHeaderCell(celdaMontoNegro);

            return tablaNeto;
        }

        private Table GenerarTablaHeader(LiquidacionDTO liquidacion)
        {
            string periodo = $"{liquidacion.Periodo.Inicio.ToString("dd/MM/yyyy")} - {liquidacion.Periodo.Fin.ToString("dd/MM/yyyy")}";

            decimal totaSueldo = liquidacion.TotalBrutoEfectivo + liquidacion.TotalBrutoBanco;

            Table header = new Table(2).UseAllAvailableWidth();

            // Crear celda para el título que abarca 2 columnas
            Cell celdaTitulo = new Cell(1, 2).Add(new Paragraph("RECIBO DE SUELDO"))
                                             .SetTextAlignment(TextAlignment.CENTER);

            celdaTitulo.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            header.AddHeaderCell(celdaTitulo);

            // Agregar celdas a la tabla
            header.AddHeaderCell(new Cell().Add(new Paragraph("Codigo liquidacion: ").SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Codigo).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("Apellido y nombre")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Empleado)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("N° de documento")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(liquidacion.Dni)));

            header.AddHeaderCell(new Cell().Add(new Paragraph("Fecha ingreso")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(_FechaIngreso.ToString("dd/MM/yyyy"))));

            header.AddHeaderCell(new Cell().Add(new Paragraph("Periodo liquidado")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(periodo)));

            return header;
        }

        private Table GeneralTablaAcuerdo(LiquidacionDTO liquidacion)
        {
            Table AcuerdoTable = new Table(4).UseAllAvailableWidth();

            Cell celdaTitulo = new Cell(1, 4).Add(new Paragraph("RESUMEN DE ACUERDO"))
                                            .SetTextAlignment(TextAlignment.LEFT);

            celdaTitulo.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            AcuerdoTable.AddHeaderCell(celdaTitulo);

            Cell numeroAcuerdo = new Cell().Add(new Paragraph("N° DE ACUERDO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell totalBruto = new Cell().Add(new Paragraph("TOTAL SUELDO BRUTO")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell totalPorHora = new Cell().Add(new Paragraph("MONTO POR HORA")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);
            Cell modalidad = new Cell().Add(new Paragraph("MODALIDAD")).SetBackgroundColor(ColorConstants.LIGHT_GRAY);

            AcuerdoTable.AddHeaderCell(numeroAcuerdo);
            AcuerdoTable.AddHeaderCell(totalBruto);
            AcuerdoTable.AddHeaderCell(totalPorHora);
            AcuerdoTable.AddHeaderCell(modalidad);

            AcuerdoTable.AddCell(liquidacion.Contrato.Codigo);
            AcuerdoTable.AddCell(liquidacion.Contrato.MontoFijo.ToString("C"));
            AcuerdoTable.AddCell(liquidacion.Contrato.MontoHora.ToString("C"));
            AcuerdoTable.AddCell(liquidacion.Contrato.Modalidad.Descripcion);

            return AcuerdoTable;
        }

        private Table GenerarTablaResumen(LiquidacionDTO liquidacion)
        {
            decimal totalPagado = liquidacion.TotalPagarBanco + liquidacion.TotalPagarEfectivo;

            Table resumenTable = new Table(2).UseAllAvailableWidth();

            Cell celdaTitulo = new Cell(1,2).Add(new Paragraph("RESUMEN"))
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
