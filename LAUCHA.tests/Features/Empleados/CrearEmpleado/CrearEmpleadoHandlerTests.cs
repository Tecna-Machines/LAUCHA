using FluentAssertions;
using LAUCHA.application;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.domain.Entities.Empleados;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.tests.Features.Empleados.CrearEmpleado
{
    public class CrearEmpleadoHandlerTests
    {
        [Fact]
        public async Task DebeCrearEmpleado()
        {
            // Arrange

            var services = new ServiceCollection();

            services.AddApplicationServices();

            services.AddSingleton<IEmpleadoRepository, EmpleadoFakeRepository>();

            var provider = services.BuildServiceProvider();

            var casoDeUso = provider.GetRequiredService<ICrearEmpleado>();

            var request = new CrearEmpleadoRequest(
                Dni: "12345678",
                Cuil: "20123456783",
                Nombre: "Marcelo",
                Apellido: "Perez",
                FechaIngreso: DateTime.Today,
                FechaNacimiento: new DateTime(1980, 1, 1),
                FechaAlta: DateTime.Today
            );

            // Act

            var result = await casoDeUso.Crear(request);

            // Assert

            result.IsSuccess.Should().BeTrue();

            result.Value.Dni.Should().Be("12345678");
            result.Value.Nombre.Should().Be("Marcelo");
            result.Value.Apellido.Should().Be("Perez");
        }
    }
}
