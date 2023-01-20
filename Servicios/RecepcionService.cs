using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IRecepcionService
    {
        Task<IList<Recepcion>> GetRecepcionesAsync(string token, string TipoUva);
        Task<IList<Recepcion>> GetRecepcionAsync(string itemCode, string BatchNum, string WhsCode, string token);
        Task<IList<Planta>> GetPlantasAsync(string token);
        Task<IList<Zona>> GetZonasAsync(string token);
        Task<IList<Cuartel>> GetCuartelesAsync(string token);
        Task<IList<Variedad>> GetVariedadesAsync(string token);
        Task<Recepcion> PatchRecepcionAsync(Recepcion recepcion, string token);

    }

    public class RecepcionService : IRecepcionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;
        public RecepcionService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IList<Recepcion>> GetRecepcionesAsync(string token, string TipoUva)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"RecepcionUva/GetRecepcionTipo/{TipoUva}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Recepcion> searchResults = new List<Recepcion>();
                foreach (JToken result in results)
                {
                    Recepcion searchResult = result.ToObject<Recepcion>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<IList<Recepcion>> GetRecepcionAsync(string itemCode,string BatchNum,string WhsCode,string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"RecepcionUva/GetRecepcion/{itemCode}/{BatchNum}/{WhsCode}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Recepcion> searchResults = new List<Recepcion>();
                foreach (JToken result in results)
                {
                    Recepcion searchResult = result.ToObject<Recepcion>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<Planta>> GetPlantasAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Planta");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Planta> searchResults = new List<Planta>();
                foreach (JToken result in results)
                {
                    Planta searchResult = result.ToObject<Planta>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<IList<Zona>> GetZonasAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Zona");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Zona> searchResults = new List<Zona>();
                foreach (JToken result in results)
                {
                    Zona searchResult = result.ToObject<Zona>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<Cuartel>> GetCuartelesAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Cuartel");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Cuartel> searchResults = new List<Cuartel>();
                foreach (JToken result in results)
                {
                    Cuartel searchResult = result.ToObject<Cuartel>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<Variedad>> GetVariedadesAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Variedad");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Variedad> searchResults = new List<Variedad>();
                foreach (JToken result in results)
                {
                    Variedad searchResult = result.ToObject<Variedad>();
                    searchResults.Add(searchResult);
                }
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<Recepcion> PatchRecepcionAsync(Recepcion recepcion, string token)
        {
            var recepcionPatch = new
            {
                DocEntry = $@"{recepcion.AbsEntry}",
                U_VD_EN_Planta = recepcion.U_VD_EN_Planta,
                U_VD_EN_Cuartel = recepcion.U_VD_EN_Cuartel,
                U_VD_EN_Zona = recepcion.U_VD_EN_Zona,
                U_VD_EN_Variedad = recepcion.U_VD_EN_Variedad,
                U_VD_EN_Produc = recepcion.U_VD_EN_Produc,
                U_VD_EN_Brix = recepcion.U_VD_EN_Brix,
                U_VD_EN_AT = recepcion.U_VD_EN_AT,
                U_VD_EN_pH = recepcion.U_VD_EN_pH,
                U_VD_EN_AP = recepcion.U_VD_EN_AP ,
                U_VD_EN_Comentario = recepcion.U_VD_EN_Comentario,
                U_VD_EN_TipCosecha = recepcion.U_VD_EN_TipCosecha,
            };
            var cuerpo = JsonConvert.SerializeObject(recepcionPatch);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(cuerpo, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PatchAsync(urlAplicacion + $"RecepcionUva/{recepcion.AbsEntry}", httpContent));

            if (response.StatusCode.ToString() == "OK")
            {
                return recepcion;
            }
            else
            {
                return null;
            }
        }


    }
}
