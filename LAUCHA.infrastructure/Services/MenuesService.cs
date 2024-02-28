using LAUCHA.domain.interfaces.IServices;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace LAUCHA.infrastructure.Services
{
    public class MenuesService : IMenuesService
    {
        private readonly HttpClient _httpClient;
        private string UsuarioService { get; set; } = "123456789";
        private string PasswordUsuario { get; set; } = "12345";

        public MenuesService(HttpClient httpClient) => (_httpClient) = (httpClient);
        public async Task<CostoPersonalResponse> ObtenerGastosComida(string dniEmpleado, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            string token = await ObtenerJwtToken();


            PersonalResponse empleado = await ObtenerPersonaDelMenu(dniEmpleado,token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var costos = await _httpClient.GetFromJsonAsync<CostoPersonalResponse>
                                ($"{_httpClient.BaseAddress}Costo/personal?fechaInicio={inicioPeriodo.ToString("MM/dd/yyyy")}" +
                                $"&fechaFin={finPeriodo.ToString("MM/dd/yyyy")}&" +
                                $"idPersonal={empleado.id}");

            return costos! ?? throw new NullReferenceException();
        }

        private async Task<PersonalResponse> ObtenerPersonaDelMenu(string dniEmpleado,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Console.WriteLine($"{_httpClient.BaseAddress}Personal");

            var listaPersonal = await _httpClient.GetFromJsonAsync<List<PersonalResponse>>($"{_httpClient.BaseAddress}Personal");

            if (listaPersonal != null)
            {
                var persona = listaPersonal.Where(p => p.dni == dniEmpleado).FirstOrDefault();

                if (persona != null)
                {
                    return persona;
                }
            }

            throw new NullReferenceException();
        }

        private async Task<string> ObtenerJwtToken()
        {
            UsuarioLoginRequest credenciales = new UsuarioLoginRequest
            {
                username = this.UsuarioService,
                password = this.PasswordUsuario
            };

            string json = JsonSerializer.Serialize(credenciales);
            var request = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}Personal/login", request);

            response.EnsureSuccessStatusCode();

            string jsonRequest = await response.Content.ReadAsStringAsync();

            if (jsonRequest != null)
            {
                UsuarioLoginResponse loginResponse = JsonSerializer.Deserialize<UsuarioLoginResponse>(jsonRequest);

                return loginResponse.token;
            }

            throw new NullReferenceException();
        }
    }
}
