using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaNetos
    {
        private Table tablaNetos;
        private readonly GetLiquidacionByIdResponse _liquidacion;

        public TablaNetos(GetLiquidacionByIdResponse liquidacion)
        {
            tablaNetos = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 }))
                                  .UseAllAvailableWidth();

            _liquidacion = liquidacion;
        }

        public Table Generar()
        {
            decimal brutoOficial = ObtenerBrutoOficial();
            decimal brutoInterno = ObtenerBrutoInterno();

            decimal descuentoOficial = ObtenerDescuentoOficial();
            decimal descuentoInterno = ObtenerDescuentoInterno();

            decimal netoOficial = brutoOficial - descuentoOficial;
            decimal netoInterno = brutoInterno - descuentoInterno;

            tablaNetos = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 }))
                .UseAllAvailableWidth();

            Color grisClaro = new DeviceRgb(240, 240, 240);

            tablaNetos.AddHeaderCell(
                new Cell()
                    .Add(new Paragraph("RESUMEN DE HABERES"))
                    .SetBackgroundColor(grisClaro));

            AgregarFila("Bruto Oficial", brutoOficial.ToString("C"));
            AgregarFila("Descuentos Oficiales", descuentoOficial.ToString("C"));
            AgregarFilaDestacada("Neto Oficial", netoOficial.ToString("C"));

            tablaNetos.AddCell(new Cell(1, 2)
                .Add(new Paragraph(" "))
                .SetBorder(Border.NO_BORDER));

            AgregarFila("Bruto Interno", brutoInterno.ToString("C"));
            AgregarFila("Descuentos Internos", descuentoInterno.ToString("C"));
            AgregarFilaDestacada("Neto Interno", netoInterno.ToString("C"));

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

        private void AgregarFilaDestacada(string concepto, string importe)
        {
            Color grisClaro = new DeviceRgb(240, 240, 240);

            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(concepto))
                    .SetBackgroundColor(grisClaro));

            tablaNetos.AddCell(
                new Cell()
                    .Add(new Paragraph(importe))
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(grisClaro));
        }

        private decimal ObtenerBrutoOficial()
        {
            return _liquidacion.Items
                                .Where(it => it.EsEnBlanco)
                                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo)
                                .Where(it => it.Estado == (int)EstadoItemLiquidacion.ACEPTADO)
                                .Sum(it => it.Monto);
        }

        private decimal ObtenerBrutoInterno()
        {
            return _liquidacion.Items
                                .Where(it => !it.EsEnBlanco)
                                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Remunerativo
                                       || it.TipoItem == (int)TipoItemLiquidacion.NoRemunerativo)
                                .Sum(it => it.Monto);
        }

        private decimal ObtenerDescuentoInterno()
        {
            return _liquidacion.Items
                                .Where(it => !it.EsEnBlanco)
                                .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Descuento)
                                .Sum(it => it.Monto);
        }

        private decimal ObtenerDescuentoOficial()
        {
            return _liquidacion.Items
                               .Where(it => it.EsEnBlanco)
                               .Where(it => it.TipoItem == (int)TipoItemLiquidacion.Retencion)
                               .Sum(it => it.Monto);
        }
    }
}
