using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> GetUsuariosAsync(string token, int idEmpresa);
        Task <Usuario> PatchUsuarioPerfil(string token, Usuario usuario);
    }

    public class UsuariosService : IUsuariosService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public UsuariosService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync(string token, int idEmpresa)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return JsonConvert.DeserializeObject<IEnumerable<Usuario>>(await _httpClient.GetStringAsync(urlLogin + $"Usuario/UsuariosEmpresa/{idEmpresa}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<Usuario> PatchUsuarioPerfil(string token, Usuario usuario)
        {

            try
            {
                var body = JsonConvert.SerializeObject(new{
                    operationType = "0",
                    path = "idPerfil",
                    op = "replace",
                    value = usuario.idPerfil
                });

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpContent httpContent = new StringContent("["+body+"]", Encoding.UTF8, "application/json");
                var response = await _httpClient.PatchAsync(urlLogin + $"Usuario/{usuario.id}", httpContent);

                return usuario;

            }
            catch (Exception ex)
            {
                return null;
            }



        }
    }
}

public class PatchUsuarioPerfil
{
    public string operationType { get; set; }
    public string path { get; set; }
    public string op { get; set; }
    public int value { get; set; }
}