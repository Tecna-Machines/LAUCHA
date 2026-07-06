namespace LAUCHA.application.Features.Empleados.GetEmpleados
{
    public record GetEmpleadosResponse(int Total, List<GetEmpleadoResponse> Empleados);

    public record GetEmpleadoResponse(string Dni,
                                      string Cuil,
                                      string Nombre,
                                      string Apellido,
                                      string AcuerdoId,
                                      int TipoSueldo);


}
