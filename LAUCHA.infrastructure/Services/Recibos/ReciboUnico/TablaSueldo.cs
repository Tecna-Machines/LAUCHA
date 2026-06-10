using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaSueldo
    {
        private Table tablaNetos;
        private readonly GetLiquidacionByIdResponse _liquidacion;

        public TablaSueldo(GetLiquidacionByIdResponse liquidacion)
        {
            tablaNetos = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 }))
                                  .UseAllAvailableWidth().SetFontSize(8);

            _liquidacion = liquidacion;
        }

        public Table Generar()
        {
            decimal brutoTotal = _liquidacion.Acuerdo.Sueldo;

            tablaNetos = new Table(
                    UnitValue.CreatePercentArray(new float[] { 70, 30 }))
                .UseAllAvailableWidth();

            tablaNetos.AddHeaderCell(
                new Cell(1, 2)
                    .Add(new Paragraph("RESUMEN DE SUELDO"))
                    .SetTextAlignment(TextAlignment.CENTER));

            // Sueldo base

            AgregarFila(
                "Sueldo Base",
                _liquidacion.Acuerdo.Sueldo.ToString("C"));

            // Adicionales

            foreach (var adicional in _liquidacion.Acuerdo.Adicionales)
            {
                string descripcion =
                    adicional.EsEnBlanco
                        ? $"{adicional.Concepto} (Oficial)"
                        : $"{adicional.Concepto} (Interno)";

                AgregarFila(
                    descripcion,
                    adicional.Monto.ToString("C"));

                brutoTotal += adicional.Monto;
            }

            AgregarSeparador();

            // Bruto

            AgregarFilaDestacada(
                "BRUTO TOTAL",
                brutoTotal.ToString("C"),
                new DeviceRgb(255, 255, 180));

            AgregarSeparador();

            // Distribución

            decimal parteOficial =
                _liquidacion.Acuerdo.ValorBlanco;

            decimal parteInterna =
                brutoTotal - parteOficial;

            AgregarFila(
                "Parte Oficial",
                parteOficial.ToString("C"));

            AgregarFila(
                "Parte Interna",
                parteInterna.ToString("C"));

            return tablaNetos;
        }

        private void AgregarFila(string concepto, string importe)
        {
            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(concepto))
                    .SetBorderBottom(new SolidBorder(0.5f)));

            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(importe))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorderBottom(new SolidBorder(0.5f)));
        }

        private void AgregarFilaDestacada(
            string concepto,
            string importe,
            Color color)
        {
            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(concepto))
                    .SetBackgroundColor(color));

            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(importe))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(color));
        }
        //TODO: esto no deberia estar aqui 
        private void AgregarSeparador()
        {
            tablaNetos.AddCell(
                new Cell(1, 2)
                    .Add(new Paragraph(" "))
                    .SetBorder(Border.NO_BORDER));
        }
    }
}
