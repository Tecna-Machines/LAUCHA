namespace LAUCHA.application.Features.Empleados.GetEmpleados
{
    public record GetEmpleadosResponse(int Total, List<GetEmpleadoResponse> Empleados);

    public record GetEmpleadoResponse(string Dni,
                                      string Nombre,
                                      string Apellido,
                                      string Cuenta,
                                      string Acuerdo,
                                      int TipoSueldo);


}
