using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.Helpers;


namespace LAUCHA.application.UseCase.GenerarRecibo
{
    internal class GeneradorTablasComunes
    {
        private readonly ConvertidorNumeroEnPalabra _GeneradorNumeroPalabra;

        public GeneradorTablasComunes()
        {
            _GeneradorNumeroPalabra = new();
        }

        public Table GenerarTablaHeader(LiquidacionDTO liquidacion, DateTime fechaIngreso)
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
            header.AddHeaderCell(new Cell().Add(new Paragraph(fechaIngreso.ToString("dd/MM/yyyy"))));

            header.AddHeaderCell(new Cell().Add(new Paragraph("Periodo liquidado")));
            header.AddHeaderCell(new Cell().Add(new Paragraph(periodo)));

            return header;
        }

        public Table GenerarTablaFooter(iText.Layout.Document document, PageSize pageSize)
        {
            // Crear una tabla para las firmas
            Table tablaFirmas = new Table(2).UseAllAvailableWidth();
            tablaFirmas.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            // Agregar celdas para las firmas del empleado y el empleador
            tablaFirmas.AddCell(new Cell().Add(new Paragraph("Firma del Empleado:")).SetTextAlignment(TextAlignment.LEFT));
            tablaFirmas.AddCell(new Cell().Add(new Paragraph("Firma del Empleador:")).SetTextAlignment(TextAlignment.LEFT));

            tablaFirmas.SetFixedPosition(document.GetLeftMargin(), document.GetBottomMargin(),
                                        pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin());

            return tablaFirmas;
        }

        public Table GeneralTablaAcuerdo(LiquidacionDTO liquidacion)
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

        public Table GenerarTablaMontoNeto(bool esEfectivo, decimal monto)
        {
            string leyenda = esEfectivo ? "EFECTIVO" : "DEPOSITO";

            Table tablaNeto = new Table(2).UseAllAvailableWidth();
            Cell celdaDescripcion = new Cell().Add(new Paragraph($"TOTAL NETO A PAGAR EN {leyenda}: "))
                                                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                                                .SetTextAlignment(TextAlignment.RIGHT);

            Cell celdaMontoNegro = new Cell().Add(new Paragraph(monto.ToString("C")));

            tablaNeto.AddHeaderCell(celdaDescripcion);
            tablaNeto.AddHeaderCell(celdaMontoNegro);

            // Crear una celda que abarque dos columnas para el monto en texto
            Cell celdaMontoTexto = new Cell(1, 2).Add(new Paragraph("Son: " + _GeneradorNumeroPalabra.ConvertirDecimalPalabra(monto)))
                                                 .SetBackgroundColor(ColorConstants.WHITE)
                                                 .SetTextAlignment(TextAlignment.LEFT);

            tablaNeto.AddCell(celdaMontoTexto);

            return tablaNeto;
        }
    }
}
