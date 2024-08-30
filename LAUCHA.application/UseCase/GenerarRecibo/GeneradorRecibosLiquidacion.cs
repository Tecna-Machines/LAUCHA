using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.GenerarRecibo
{
    public class GeneradorRecibosLiquidacion : IGeneradorRecibos
    {
        private readonly IMarcasService _marcasService;
        private readonly ConvertidorNumeroEnPalabra _GeneradorNumeroPalabra;
        private readonly GeneradorTablasComunes _GeneradorTablasComunes;
        private readonly GeneradorTablasSueldos _GeneradorTablasSueldo;
        private DateTime _FechaIngreso;
        private readonly ILogsApp log;
        public GeneradorRecibosLiquidacion(ILogsApp log, IMarcasService marcasService)
        {
            _GeneradorNumeroPalabra = new();
            _GeneradorTablasComunes = new();
            _GeneradorTablasSueldo = new();
            _marcasService = marcasService;
            this.log = log;
        }

        public byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion, DateTime fechaIngreso)
        {
            log.LogInformation("generando recibo de la liquidacion N: {n}", liquidacion.Codigo);

            _FechaIngreso = fechaIngreso;

            //TODO: sacar esta linea , es solo para pruebas
            var marcas = _marcasService.ConsultarMarcasPeriodoVista(liquidacion.Dni, liquidacion.Periodo.Inicio, liquidacion.Periodo.Fin);

            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(stream))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        PageSize ps = pdf.GetDefaultPageSize();
                        iText.Layout.Document document = new iText.Layout.Document(pdf, ps);
                        document.SetFontSize(10);
                        // Generar contenido de la primera página
                        GenerarPaginaReciboBlanco(document, ps, liquidacion);

                        // Agregar salto de página
                        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                        // Generar contenido de la segunda página
                        GenerarPaginaReciboNegro(document, ps, liquidacion);

                        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                        //generar contenido de la pagina de marca
                        GenerarPaginaMarcas(document, ps, liquidacion,marcas);
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

        private void GenerarPaginaMarcas(iText.Layout.Document document, PageSize ps, LiquidacionDTO liquidacion, List<MarcaVista> marcas)
        {
            iText.Layout.Document paginaMarcas = document;

            paginaMarcas.Add(_GeneradorTablasComunes.GenerarTablaHeaderMarcas(liquidacion, _FechaIngreso));
            paginaMarcas.Add(new Paragraph("\n"));

            // Ancho de columnas en porcentajes
            float[] columnWidths = { 5f, 5f, 5f, 5f, 6f,5f,5f,5f };
            Table tablaMarcas = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();
            tablaMarcas.SetFontSize(10);

            // Encabezados
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("fecha")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("entrada")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("salida")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("HS (totales)")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("HS (comunes)")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("HS (extra)")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("HS (doble)")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaMarcas.AddHeaderCell(new Cell().Add(new Paragraph("Día")).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

            DateTime fechaInicio = liquidacion.Periodo.Inicio;
            DateTime fechaFin = liquidacion.Periodo.Fin;

            for (DateTime fechaActual = fechaInicio; fechaActual <= fechaFin; fechaActual = fechaActual.AddDays(1))
            {
                MarcaVista? marcaDelDia = marcas.FirstOrDefault(m => m.Ingreso.Date == fechaActual.Date);
                bool esFinde = fechaActual.DayOfWeek == DayOfWeek.Saturday || fechaActual.DayOfWeek == DayOfWeek.Sunday;

                // Celdas de datos
                Cell fechaCelda = new Cell().Add(new Paragraph(fechaActual.ToString("dd/MM")));
                tablaMarcas.AddCell(fechaCelda);

                if (marcaDelDia != null)
                {
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(marcaDelDia.Ingreso.ToString("HH:mm"))));
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(marcaDelDia.Egreso.ToString("HH:mm"))));
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(Math.Round(marcaDelDia.HsTrabajadas, 2).ToString())));
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(Math.Round(marcaDelDia.HsComunes, 2).ToString())));
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(Math.Round(marcaDelDia.HsExtra, 2).ToString())));
                    tablaMarcas.AddCell(new Cell().Add(new Paragraph(Math.Round(marcaDelDia.HsDoble, 2).ToString())));

                    Cell diaCelda = new Cell().Add(new Paragraph(marcaDelDia.Egreso.ToString("ddd")));
                    if (esFinde)
                    {
                        diaCelda.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                    }
                    tablaMarcas.AddCell(diaCelda);
                }
                else
                {
                    // Día de la semana
                    Cell diaIng = new Cell().Add(new Paragraph(" "));
                    Cell diaEgre = new Cell().Add(new Paragraph(""));
                    Cell diaHs = new Cell().Add(new Paragraph("0"));
                    Cell hsComunes = new Cell().Add(new Paragraph("0"));
                    Cell hsExtra = new Cell().Add(new Paragraph("0"));
                    Cell hsDoble = new Cell().Add(new Paragraph("0"));
                    Cell diaCelda = new Cell().Add(new Paragraph(fechaActual.ToString("ddd")));

                    tablaMarcas.AddCell(diaIng); // Hora de ingreso vacía
                    tablaMarcas.AddCell(diaEgre); // Hora de egreso vacía
                    tablaMarcas.AddCell(diaHs); // Hs totales
                    tablaMarcas.AddCell(hsComunes); // Hs totales
                    tablaMarcas.AddCell(hsExtra); // Hs dobles
                    tablaMarcas.AddCell(hsDoble); // Horas trabajadas vacías

                    if (esFinde)
                    {
                        fechaCelda.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        diaIng.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        diaEgre.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        diaHs.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        hsComunes.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        hsExtra.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        hsDoble.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                        diaCelda.SetBackgroundColor(ColorConstants.DARK_GRAY).SetFontColor(ColorConstants.WHITE);
                    }

                    tablaMarcas.AddCell(diaCelda);
                }
            }

            // Agregar fila de totales
            tablaMarcas.AddFooterCell(new Cell(1, 3).Add(new Paragraph("Totales (HS):"))
                                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBold());

            tablaMarcas.AddFooterCell(new Cell().Add(new Paragraph(Math.Round(marcas.Sum(m => m.HsTrabajadas), 2).ToString())));
            tablaMarcas.AddFooterCell(new Cell().Add(new Paragraph(Math.Round(marcas.Sum(m => m.HsComunes), 2).ToString())));
            tablaMarcas.AddFooterCell(new Cell().Add(new Paragraph(Math.Round(marcas.Sum(m => m.HsExtra), 2).ToString())));
            tablaMarcas.AddFooterCell(new Cell().Add(new Paragraph(Math.Round(marcas.Sum(m => m.HsDoble), 2).ToString())));
            tablaMarcas.AddFooterCell(new Cell().Add(new Paragraph(" "))); // Celda vacía para "Día"

            paginaMarcas.Add(tablaMarcas);
        }



    }
}
