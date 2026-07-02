using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class TablaHeader
    {
        private static readonly Color HeaderBgColor = new DeviceRgb(220, 220, 220);
        private static readonly Color BorderColor = new DeviceRgb(120, 120, 120);

        private const float FontSize = 7f;
        private const float EmpresaFontSize = 8f;

        public static Div GenerarCabecera(GetLiquidacionByIdResponse liquidacion)
        {
            var cabecera = new Div();

            Table tabla = new Table(UnitValue.CreatePercentArray(new float[]
            {
                8, 12, 12, 34, 18
            }))
            .UseAllAvailableWidth()
            .SetMarginBottom(6);

            AgregarFilaEmpresa(tabla);
            AgregarFilaTitulos(tabla);
            AgregarFilaDatosLiquidacion(tabla, liquidacion);
            AgregarFilaTitulosEmpleado(tabla);
            AgregarFilaDatosEmpleado(tabla, liquidacion);

            cabecera.Add(tabla);

            return cabecera;
        }

        private static void AgregarFilaEmpresa(Table tabla)
        {
            tabla.AddCell(new Cell(1, 6)
                .Add(new Paragraph("EMPRESA").SetFontSize(EmpresaFontSize))
                .Add(new Paragraph("AKER INGENIERIA SRL").SetFontSize(EmpresaFontSize))
                .Add(new Paragraph("C.U.I.T. EMPRESA : 30-71085260-6").SetFontSize(EmpresaFontSize))
                .SetPadding(3)
                .SetBorder(Borde()));
        }

        private static void AgregarFilaTitulos(Table tabla)
        {
            tabla.AddCell(CeldaTitulo("QUINCENA."));
            tabla.AddCell(CeldaTitulo("MES"));
            tabla.AddCell(CeldaTitulo("AÑO"));
            tabla.AddCell(CeldaTitulo("APELLIDO Y NOMBRE"));
            tabla.AddCell(CeldaTitulo("CÓDIGO"));
        }

        private static void AgregarFilaDatosLiquidacion(Table tabla, GetLiquidacionByIdResponse liquidacion)
        {
            string nombreCompleto = $"{liquidacion.Empleado.Apellido} {liquidacion.Empleado.Nombre}";

            tabla.AddCell(CeldaDato(liquidacion.Quincena.Nro.ToString()));
            tabla.AddCell(CeldaDato(liquidacion.Quincena.Mes.ToString()));
            tabla.AddCell(CeldaDato(liquidacion.Quincena.Anio.ToString()));
            tabla.AddCell(CeldaDato(nombreCompleto, TextAlignment.LEFT));
            tabla.AddCell(CeldaDato(liquidacion.Codigo));
        }

        private static void AgregarFilaTitulosEmpleado(Table tabla)
        {
            tabla.AddCell(CeldaTitulo("CUIL", 2));
            tabla.AddCell(CeldaTitulo("FECHA ALTA", 2));
            tabla.AddCell(CeldaTitulo("FECHA INGRESO", 2));
        }

        private static void AgregarFilaDatosEmpleado(Table tabla, GetLiquidacionByIdResponse liquidacion)
        {
            tabla.AddCell(CeldaDato(liquidacion.Empleado.Cuil, TextAlignment.CENTER, 2));
            tabla.AddCell(CeldaDato(liquidacion.Empleado.FechaAlta.ToString("dd/MM/yyyy"), TextAlignment.CENTER, 2));
            tabla.AddCell(CeldaDato(liquidacion.Empleado.FechaIngreso.ToString("dd/MM/yyyy"), TextAlignment.CENTER, 2));
        }

        private static Cell CeldaTitulo(string texto, int colspan = 1)
        {
            return new Cell(1, colspan)
                .Add(new Paragraph(texto).SetFontSize(FontSize))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetBackgroundColor(HeaderBgColor)
                .SetPadding(2)
                .SetBorder(Borde());
        }

        private static Cell CeldaDato(string texto, TextAlignment align = TextAlignment.CENTER, int colspan = 1)
        {
            return new Cell(1, colspan)
                .Add(new Paragraph(texto ?? "").SetFontSize(FontSize))
                .SetTextAlignment(align)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetMinHeight(18)
                .SetPadding(2)
                .SetBorder(Borde());
        }

        private static Border Borde()
        {
            return new SolidBorder(BorderColor, 0.5f);
        }
    }
}