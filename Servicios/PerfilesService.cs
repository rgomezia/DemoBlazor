using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http.Headers;
using System.Text;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IPerfilesService
    {
        Task<IList<Perfil>> GetPerfilesAsync(string token, int idEmpresa);
        Task<PerfilModulo> PatchPerfilModuloAsync(PerfilModulo perfil);
        Task<OperacionesModulo> PatchPerfilModuloOperacionAsync(OperacionesModulo operacion);
        Task<Operacion> PostOperacionAsync(string token, Operacion operacion);
        Task<Perfil> PostPerfilAsync(string token, Perfil perfil);

        Task<Perfil> PutPerfilAsync(string token, Perfil perfil);

    }

    public class PerfilesService : IPerfilesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public PerfilesService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IList<Perfil>> GetPerfilesAsync(string token, int idEmpresa)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return JsonConvert.DeserializeObject<IList<Perfil>>(await _httpClient.GetStringAsync(urlLogin + $"Perfil/PerfilesAplicacion/{4}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<PerfilModulo> PatchPerfilModuloAsync(PerfilModulo perfil)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string state = "0";
            if (perfil.acceso == true)
                state = "0";
            else
                state = "1";


            var body = JsonConvert.SerializeObject(new
            {
                operationType = "0",
                path = "acceso",
                op = "replace",
                value = state
            });


            HttpContent httpContent = new StringContent("[" + body + "]", Encoding.UTF8, "application/json");
            var response = (await _httpClient.PatchAsync(urlLogin + $"PerfilModulo/{perfil.id}", httpContent));

            if (response.StatusCode.ToString() == "OK")
                return perfil;
            else
                return null;
        }

        public async Task<OperacionesModulo> PatchPerfilModuloOperacionAsync(OperacionesModulo operacion)
        {
            string state = "0";
            if (operacion.acceso == true)
                state = "0";
            else
                state = "1";


            var body = JsonConvert.SerializeObject(new
            {
                operationType = "0",
                path = "acceso",
                op = "replace",
                value = state
            });
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent("[" + body + "]", Encoding.UTF8, "application/json");
            var response = (await _httpClient.PatchAsync(urlLogin + $"PerfilModuloOperacion/{operacion.id}", httpContent));

            if (response.StatusCode.ToString() == "OK")
                return operacion;
            else
                return null;
        }

        public async Task<Operacion> PostOperacionAsync(string token, Operacion operacion)
        {

            var body = JsonConvert.SerializeObject(new
            {
                nombre = operacion.nombre,
                estado = "0",
                idModulo = operacion.idModulo,
                acceso = 0
            });

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PostAsync(urlLogin + $"Operacion", httpContent));

            if (response.StatusCode.ToString() == "OK")
                return operacion;
            else
                return null;
        }

        public async Task<Perfil> PostPerfilAsync(string token, Perfil perfil)
        {
            int state = 0;
            if (perfil.Estado == true)
                state = 1;
            else
                state = 0;

            var body = JsonConvert.SerializeObject(new
            {
                nombre = perfil.Nombre,
                estado = state,
                id_aplicacion = 4,
            });

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PostAsync(urlLogin + $"Perfil", httpContent));

            if (response.StatusCode.ToString() == "OK")
                return perfil;
            else
                return null;
        }

        public async Task<Perfil> PutPerfilAsync(string token, Perfil perfil)
        {
            int state = 0;
            if (perfil.Estado == true)
                state = 1;
            else
                state = 0;

            var body = JsonConvert.SerializeObject(new
            {
                nombre = perfil.Nombre,
                estado = state,
                id_aplicacion = 4,
            });

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PostAsync(urlLogin + $"Perfil/{perfil.Id}", httpContent));

            if (response.StatusCode.ToString() == "OK")
                return perfil;
            else
                return null;


        }
    }
    public class PatchUsuarioPerfil
    {
        public string operationType { get; set; }
        public string path { get; set; }
        public string op { get; set; }
        public int value { get; set; }
    }

}
