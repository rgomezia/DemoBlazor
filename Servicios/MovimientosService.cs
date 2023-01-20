/*
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Requisiciones.Shared;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;
*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Text;
using System.Net.Http.Headers;
using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IMovimientosService
    {
        Task<Movimiento> GetMovimientoAsync(int DocEntry, string token);
        Task<IList<Movimiento>> GetMovimientosAsync(string token);
        Task<GETMovimiento> GetMovimiento2Async(int DocEntry, string token);
        Task<IList<GETMovimiento>> GetMovimientos2Async(string token);
        Task<Movimiento> PostMovimientoAsync(Movimiento adicion, string token);
        Task<IList<OperacionMovimiento>> GetOperacionesAsync(string token);
        Task<IList<Cuba>> GetCubasTodasAsync(string token);
        Task<IList<Cuba>> GetCubasTodasConItemAsync(string ItemCode,string token);
        Task<IList<AlmacenBarrica>> GetAlmacenBarricaDisponiblesAsync(string itemCode, string token);
        Task<IList<AlmacenBarrica>> GetAlmacenBarricaConStockAsync(string token);
        Task<IList<Barrica>> GetBarricasDisponiblesAsync(string itemCode, string WhsCode, string token);
        Task<IList<Barrica>> GetBarricasStockAsync(string itemCode, string WhsCode, string BatchNum, string token);
        Task<IList<Cuba>> GetCubasStockAsync(string token);
        Task<IList<Insumos>> GetInsumosAsync(string token);
        Task<IList<Items>> GetItemsAsync(string token);
    }

    public class MovimientosService : IMovimientosService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public MovimientosService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }

        public async Task<Movimiento> GetMovimientoAsync(int DocEntry, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/{DocEntry}");
                JObject obj = JObject.Parse(json);
                Movimiento searchResults = obj.ToObject<Movimiento>();
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<Movimiento>> GetMovimientosAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino");
                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Movimiento> searchResults = new List<Movimiento>();
                foreach (JToken result in results)
                {
                    Movimiento searchResult = result.ToObject<Movimiento>();
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
        public async Task<GETMovimiento> GetMovimiento2Async(int DocEntry, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/{DocEntry}");
                JObject obj = JObject.Parse(json);
                GETMovimiento searchResults = obj.ToObject<GETMovimiento>();
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<GETMovimiento>> GetMovimientos2Async(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino");
                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<GETMovimiento> searchResults = new List<GETMovimiento>();
                foreach (JToken result in results)
                {
                    GETMovimiento searchResult = result.ToObject<GETMovimiento>();
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
        public async Task<Movimiento> PostMovimientoAsync(Movimiento movimiento, string token)
        {
            var cuerpo = JsonConvert.SerializeObject(movimiento);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(cuerpo, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PostAsync(urlAplicacion + $"MovimientosVino", httpContent));

            if (response.StatusCode.ToString() == "OK")
            {
                dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await response.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
                JObject resultado = JObject.Parse(await response.Content.ReadAsStringAsync());
                movimiento.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
                return movimiento;
            }
            else
            {
                return null;
            }



        }
        public async Task<IList<OperacionMovimiento>> GetOperacionesAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetListaOperacionesMov");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<OperacionMovimiento> searchResults = new List<OperacionMovimiento>();
                foreach (JToken result in results)
                {
                    OperacionMovimiento searchResult = result.ToObject<OperacionMovimiento>();
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
        public async Task<IList<Cuba>> GetCubasStockAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetListaCubasStockMov");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Cuba> searchResults = new List<Cuba>();
                foreach (JToken result in results)
                {
                    Cuba searchResult = result.ToObject<Cuba>();
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
        public async Task<IList<Cuba>> GetCubasTodasAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetListaCubasTodasMov");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Cuba> searchResults = new List<Cuba>();
                foreach (JToken result in results)
                {
                    Cuba searchResult = result.ToObject<Cuba>();
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

        public async Task<IList<Insumos>> GetInsumosAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"AdicionesVino/GetListaInsumos");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Insumos> searchResults = new List<Insumos>();
                foreach (JToken result in results)
                {
                    Insumos searchResult = result.ToObject<Insumos>();
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
        
        public async Task<IList<Items>> GetItemsAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetListaItemsEnologiaMov");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Items> searchResults = new List<Items>();
                foreach (JToken result in results)
                {
                    Items searchResult = result.ToObject<Items>();
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

        public async Task<IList<AlmacenBarrica>> GetAlmacenBarricaDisponiblesAsync(string itemCode, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetAlmacenBarricaDisponibles/"+ itemCode);

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<AlmacenBarrica> searchResults = new List<AlmacenBarrica>();
                foreach (JToken result in results)
                {
                    AlmacenBarrica searchResult = result.ToObject<AlmacenBarrica>();
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
        public async Task<IList<AlmacenBarrica>> GetAlmacenBarricaConStockAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetAlmacenBarricaStock");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<AlmacenBarrica> searchResults = new List<AlmacenBarrica>();
                foreach (JToken result in results)
                {
                    AlmacenBarrica searchResult = result.ToObject<AlmacenBarrica>();
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
        public async Task<IList<Barrica>> GetBarricasDisponiblesAsync(string itemCode, string WhsCode, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetBarricasDisponibles/{itemCode}/{WhsCode}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Barrica> searchResults = new List<Barrica>();
                foreach (JToken result in results)
                {
                    Barrica searchResult = result.ToObject<Barrica>();
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
        public async Task<IList<Barrica>> GetBarricasStockAsync(string itemCode, string WhsCode, string BatchNum, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetBarricasStock/{itemCode}/{WhsCode}/{BatchNum}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Barrica> searchResults = new List<Barrica>();
                foreach (JToken result in results)
                {
                    Barrica searchResult = result.ToObject<Barrica>();
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

        public async Task<IList<Cuba>> GetCubasTodasConItemAsync(string ItemCode, string token)
        {

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"MovimientosVino/GetListaCubasTodasMovItem/{ItemCode}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Cuba> searchResults = new List<Cuba>();
                foreach (JToken result in results)
                {
                    Cuba searchResult = result.ToObject<Cuba>();
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
        /*
public async Task<Requisicion> PostRequisicionAsync(Requisicion requisicion, string token)
{
List<ItemsRequisicion> itemsReq = new();
foreach (var item in requisicion.VID_PRSOLCOMDCollection)
{
itemsReq.Add(new ItemsRequisicion() { U_CardCode1 = item.U_CardCode1, U_CardName = item.U_CardName, U_Dscript = item.U_Dscript, U_ItemCode = item.U_ItemCode, U_Quantity = item.U_Quantity });
}
var requisicionPost = new
{
U_DocDate = requisicion.U_DocDate,
U_Comments = requisicion.U_Comments,
U_Source = "P",
U_ProyNum = requisicion.U_ProyNum,
U_Target = requisicion.U_Target,
U_TipSol = ((char)requisicion.U_TipSol).ToString(),
VID_PRSOLCOMDCollection = itemsReq
};
var cuerpo = JsonConvert.SerializeObject(requisicionPost);

_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
HttpContent httpContent = new StringContent(cuerpo, Encoding.UTF8, "application/json");
var response = (await _httpClient.PostAsync(urlAplicacion + $"Requisicion", httpContent));

if (response.StatusCode.ToString() == "OK")
{
dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await response.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
JObject resultado = JObject.Parse(await response.Content.ReadAsStringAsync());
requisicion.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
return requisicion;
}
else
{
return null;
}

}
public async Task<Requisicion> PatchRequisicionAsync(Requisicion requisicion, string token)
{
List<ItemsRequisicion> itemsReq = new();
foreach (var item in requisicion.VID_PRSOLCOMDCollection)
{
itemsReq.Add(new ItemsRequisicion() { U_CardCode1 = item.U_CardCode1, U_CardName = item.U_CardName, U_Dscript = item.U_Dscript, U_ItemCode = item.U_ItemCode, U_Quantity = item.U_Quantity });
}
var requisicionPatch = new
{
DocEntry = @$"{requisicion.DocEntry}",
U_Comments = requisicion.U_Comments,
VID_PRSOLCOMDCollection = itemsReq
};
var cuerpo = JsonConvert.SerializeObject(requisicionPatch);

_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
HttpContent httpContent = new StringContent(cuerpo, Encoding.UTF8, "application/json");
var response = (await _httpClient.PatchAsync(urlAplicacion + $"Requisicion/{requisicion.DocEntry}", httpContent));

if (response.StatusCode.ToString() == "OK")
{
return requisicion;
}
else
{
return null;
}

}
public async Task<IList<Proveedor>> GetProveedoresAsync(string token)
{
try
{
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var json = await _httpClient.GetStringAsync(urlAplicacion + $"Proveedor/ListaBusquedaReq");

JObject obj = JObject.Parse(json);
IList<JToken> results = obj["Results"].ToList();
IList<Proveedor> searchResults = new List<Proveedor>();
foreach (JToken result in results)
{
  Proveedor searchResult = result.ToObject<Proveedor>();
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
public async Task<IList<Proyectos>> GetProyectosAsync(string token)
{
try
{
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var json = await _httpClient.GetStringAsync(urlAplicacion + $"Proyecto/ListaProyectoUsuarioSAP");

JObject obj = JObject.Parse(json);
IList<JToken> results = obj["Results"].ToList();
IList<Proyectos> searchResults = new List<Proyectos>();
foreach (JToken result in results)
{
  Proyectos searchResult = result.ToObject<Proyectos>();
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
public async Task<IList<Destino>> GetDestinoAsync(string token)
{
try
{
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var json = await _httpClient.GetStringAsync(urlAplicacion + $"Requisicion/ListaDestinoUsuarioSAP");

JObject obj = JObject.Parse(json);
IList<JToken> results = obj["Results"].ToList();
IList<Destino> searchResults = new List<Destino>();
foreach (JToken result in results)
{
  Destino searchResult = result.ToObject<Destino>();
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

public async Task<IList<Items>> GetItemsAsync(TipoSol tipoSol, string proyecto, string token)
{
try
{
_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var url = $"Item/ListaBusquedaReq/{((char)tipoSol).ToString()}/{proyecto}";
var json = await _httpClient.GetStringAsync(urlAplicacion + url);

JObject obj = JObject.Parse(json);
IList<JToken> results = obj["Results"].ToList();
IList<Items> searchResults = new List<Items>();
foreach (JToken result in results)
{
  Items searchResult = result.ToObject<Items>();
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
*/

    }
}
