using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using DemoBlazor.Models;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using Microsoft.Extensions.Logging.Abstractions;

namespace DemoBlazor.Services
{
    public interface IEntradasService
    {
        Task<IList<Operaciones>> GetListaOperaciones(string token);
        Task<IList<EntradasVino>> GeRecepcionesUva(string TipoUva, string token);
        Task<IList<CubaEntradaVino>> GetListaCubas(string token);
        Task<IList<CubaEntradaVino>> GetListaCubasKilosTintaItem(string token , string itemEnologia);
        Task<IList<CubaEntradaVino>> GetListaCubasKilosTinta(string token);
        Task<IList<CubaEntradaVino>> GetListaCubasKilosTintaStock(string token);
        Task<Entrada> PostEntradaVino(Entrada entrada, string token);
        Task<IList<EntradasDto>> GetEntradasVino(string token);
        Task<Entrada> GetEntradaVino(string DocEntry, string token);
        Task<IList<ItemEnologia>> GetListaItemsEnologia(string token, string TipoUva);
        Task<IList<CubaEntradaVino>> GetListaCubasTipoUvaItem(string token, string tipoCuba, string itemCode);
    }
    public class EntradasService : IEntradasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public EntradasService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<IList<Operaciones>> GetListaOperaciones(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaOperaciones");

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

        public async Task<IList<EntradasVino>> GeRecepcionesUva(string TipoUva, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetRecepcionesUva/{TipoUva}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<EntradasVino> searchResults = new List<EntradasVino>();
                foreach (JToken result in results)
                {
                    EntradasVino searchResult = result.ToObject<EntradasVino>();
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

        public async Task<IList<CubaEntradaVino>> GetListaCubas(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaCubas");

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


        public async Task<IList<CubaEntradaVino>> GetListaCubasTipoUvaItem(string token, string tipoCuba, string itemCode)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaCubasTipoUvaItem/{tipoCuba}/{itemCode}");
                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<CubaEntradaVino> searchResults = new List<CubaEntradaVino>();
                foreach (JToken result in results)
                {
                    CubaEntradaVino searchResult = result.ToObject<CubaEntradaVino>();

                    if (searchResult.ItemCode != null)
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


        public async Task<IList<CubaEntradaVino>> GetListaCubasKilosTintaItem(string token ,string itemEnologia)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaCubasKilosTintaItem/{itemEnologia}");

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

        public async Task<IList<CubaEntradaVino>> GetListaCubasKilosTinta(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaCubasKilosTinta");

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


        public async Task<IList<CubaEntradaVino>> GetListaCubasKilosTintaStock(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaCubasKilosTintaStock");

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

        public async Task<Entrada> PostEntradaVino(Entrada entrada, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string json = JsonConvert.SerializeObject(entrada);

                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = (await _httpClient.PostAsync(urlAplicacion + $"EntradasVino", httpContent));

                if (result.StatusCode.ToString() == "OK")
                {
                    dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await result.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
                    JObject resultado = JObject.Parse(await result.Content.ReadAsStringAsync());
                    entrada.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
                    return entrada;
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

        public async Task<IList<EntradasDto>> GetEntradasVino(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<EntradasDto> searchResults = new List<EntradasDto>();
                foreach (JToken result in results)
                {
                    EntradasDto searchResult = result.ToObject<EntradasDto>();
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

        public async Task<Entrada> GetEntradaVino(string DocEntry, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/{DocEntry}");
                var temp = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/{DocEntry}");
                var obj = JsonConvert.DeserializeObject<Entrada>(temp);
                return obj;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }

        public async Task<IList<ItemEnologia>> GetListaItemsEnologia(string token, string TipoUva)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"EntradasVino/GetListaItemsEnologia/{TipoUva}");
                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<ItemEnologia> searchResults = new List<ItemEnologia>();
                foreach (JToken result in results)
                {
                    ItemEnologia searchResult = result.ToObject<ItemEnologia>();
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
    }
}