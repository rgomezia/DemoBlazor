using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IModulosService
    {
        Task<List<OperacionesModulo>> GetOperacionesModulo(string token, int modulo, int perfil);
        Task<IList<OperacionesModulo>> GetOperacionesModuloPerfilAsync(int modulo, int? perfil);
        Task<IList<PerfilModulo>> GetModulosPerfilAsync(int? idPerfil);
    }

    public class ModulosService : IModulosService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public ModulosService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IList<PerfilModulo>> GetModulosPerfilAsync(int? idPerfil)
        {
            try
            {
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return JsonConvert.DeserializeObject<IList<PerfilModulo>>(await _httpClient.GetStringAsync(urlLogin + $"Modulo/ModulosPerfil/{idPerfil}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<IList<OperacionesModulo>> GetOperacionesModuloPerfilAsync(int modulo, int? perfil)
        {
            try
            {
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return JsonConvert.DeserializeObject<IList<OperacionesModulo>>(await _httpClient.GetStringAsync(urlLogin + $"Operacion/GetOperacionesModuloPerfil/{modulo}/{perfil}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<List<OperacionesModulo>> GetOperacionesModulo(string token, int modulo, int perfil)
        {
            try
            {
                var urlBase = urlLogin;
                var client = new RestClient(urlBase + $"Operacion/GetOperacionesModuloPerfil/{modulo}/{perfil}");
                var request = new RestRequest(Method.GET);
                var response = await client.GetAsync<List<OperacionesModulo>>(request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
