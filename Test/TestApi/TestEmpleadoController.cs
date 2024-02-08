using LAUCHA.api.Controllers;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace TestApi
{
    public class TestEmpleadoController
    {
        [Fact]
        public void CrearEmpleadoOK()
        {
            //ARRANGE
            var mockCrearEmpleadoService = new Mock<ICrearEmpleadoService>();
            var controller = new EmpleadoController(mockCrearEmpleadoService.Object);

            var empleadoRequest = new CrearEmpleadoDTO
            {
                Dni = "34444",
                Nombre = "John",
                Apellido = "Turner",
                FechaIngreso = DateTime.Now,
                FechaNacimiento = DateTime.Now,
            };

            //ACT
            var result = controller.CrearNuevoEmpleado(empleadoRequest);

            //ASSERT
            // Verificar si el resultado es un objeto JsonResult
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            var content = jsonResult.Value as EmpleadoDTO;


            // Verificar si el JSON contiene la información esperada
            Assert.Contains(empleadoRequest.Dni, content.Dni);
        }
    }
}