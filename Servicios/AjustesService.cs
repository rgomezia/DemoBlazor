using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using DemoBlazor.Models;
using Newtonsoft.Json.Converters;
using System.Dynamic;


namespace DemoBlazor.Services
{
    public interface IAjustesService
    {
        //Task<Entrada> PostEntradaVino(Entrada entrada, string token);
        Task<IList<ItemAjuste>> GetListaItemsEnologiaPTAJ(string token);
        //Task<Entrada> GetEntradaVino(string DocEntry, string token);

        Task<IList<CubaEntradaVino>> GetListaCubasStockAjus(string token);

        Task<AjustesDTo> PostAjuste(AjustesDTo entrada, string token);

        Task<IList<Operaciones>> GetListaOperaciones(string token);

        Task<IList<AjusteAtributos>> GetAjusteAtributos(string token, string lote);

        Task<AjusteAtributos> PostAjusteAtributos (string token, AjusteAtributos ajuste);
    }
    public class AjustesService : IAjustesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public AjustesService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IList<ItemAjuste>> GetListaItemsEnologiaPTAJ(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion+$"Ajustes/GetListaItemsEnologiaPTAJ");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<ItemAjuste> searchResults = new List<ItemAjuste>();
                foreach (JToken result in results)
                {
                    ItemAjuste searchResult = result.ToObject<ItemAjuste>();
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

        public async Task<IList<CubaEntradaVino>> GetListaCubasStockAjus(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Ajustes/GetListaCubasStockAjus");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<CubaEntradaVino> searchResults = new List<CubaEntradaVino>();
                foreach (JToken result in results)
                {
                    CubaEntradaVino searchResult = result.ToObject<CubaEntradaVino>();
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


        public async Task<AjustesDTo> PostAjuste(AjustesDTo ajuste, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string json = JsonConvert.SerializeObject(ajuste);

                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = (await _httpClient.PostAsync(urlAplicacion + $"Ajustes", httpContent));

                if (result.StatusCode.ToString() == "OK")
                {
                    dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await result.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
                    JObject resultado = JObject.Parse(await result.Content.ReadAsStringAsync());
                    ajuste.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
                    return ajuste;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<Operaciones>> GetListaOperaciones(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Ajustes/GetListaOperacionesAjus");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Operaciones> searchResults = new List<Operaciones>();
                foreach (JToken result in results)
                {
                    Operaciones searchResult = result.ToObject<Operaciones>();
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

        public async Task<IList<AjusteAtributos>> GetAjusteAtributos(string token, string lote)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Ajustes/GetUltimoAjuste/{lote}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<AjusteAtributos> searchResults = new List<AjusteAtributos>();
                foreach (JToken result in results)
                {
                    AjusteAtributos searchResult = result.ToObject<AjusteAtributos>();
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


        public async Task<AjusteAtributos> PostAjusteAtributos( string token ,AjusteAtributos ajuste)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string json = JsonConvert.SerializeObject(ajuste);

                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = (await _httpClient.PostAsync(urlAplicacion + $"Ajustes", httpContent));

                if (result.StatusCode.ToString() == "OK")
                {
                    dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await result.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
                    JObject resultado = JObject.Parse(await result.Content.ReadAsStringAsync());
                    ajuste.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
                    return ajuste;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
