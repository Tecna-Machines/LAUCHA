using LAUCHA.application.Common.Errors;

namespace LAUCHA.application.Features.Empleados
{
    public static class EmpleadoErrors
    {
        public static readonly Error Obtener = new("Consulta.empleados.fallo");
        public static readonly Error Crear = new("Parametros.invalidos");
        public static readonly Error Guardar = new("Error.Guardado");

    }
}
