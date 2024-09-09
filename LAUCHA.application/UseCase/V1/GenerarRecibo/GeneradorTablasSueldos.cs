using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;

namespace LAUCHA.application.UseCase.GenerarRecibo
{
    internal class GeneradorTablasSueldos
    {
        public Table GenerarTablaSueldoBlanco(LiquidacionDTO liquidacion)
        {
            List<RemuneracionDTO> remuneraciones = liquidacion.Items.Remuneraciones;
            List<RetencionDTO> retenciones = liquidacion.Items.Retenciones;
            List<NoRemuneracionDTO> noRemuneraciones = liquidacion.Items.NoRemuneraciones;

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



            foreach (RemuneracionDTO remuBlanca in listaRemuneracionesBlanca)
            {
                tablaParteBlanco.AddCell(remuBlanca.Descripcion);
                tablaParteBlanco.AddCell(remuBlanca.Monto.ToString("C"));
                tablaParteBlanco.AddCell("");
                tablaParteBlanco.AddCell("");

                totalRemunerativo += remuBlanca.Monto;

            }

            foreach (NoRemuneracionDTO noRemuBlanca in noRemuneraciones)
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

            tablaParteBlanco.AddCell(new Paragraph("SUBTOTALES:").SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            tablaParteBlanco.AddCell(totalRemunerativo.ToString("C"));
            tablaParteBlanco.AddCell(totalNoRemunerativo.ToString("C"));
            tablaParteBlanco.AddCell(totalRetenciones.ToString("C"));

            return tablaParteBlanco;
        }

        public Table GenerarTablaSueldoEfectivo(LiquidacionDTO liquidacion)
        {
            List<RemuneracionDTO> remuneraciones = liquidacion.Items.Remuneraciones;
            List<DescuentoDTO> descuentos = liquidacion.Items.Descuentos;

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
    }
}
