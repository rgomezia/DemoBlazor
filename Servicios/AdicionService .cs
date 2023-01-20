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
    public interface IAdicionesService
    {
        Task<Adicion> GetAdicionAsync(int DocEntry, string token);
        Task<IList<Adicion>> GetAdicionesAsync(string token);
        Task<Adicion> PostAdicionAsync(Adicion adicion, string token);
        Task<IList<Lotes>> GetLotesAsync(string itemCode, string WhsCode, string token);
        Task<IList<Cuba>> GetCubasAsync(string token);
        Task<IList<Insumos>> GetInsumosAsync(string token, string codCuba);
    }

    public class AdicionesService : IAdicionesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string urlAplicacion;
        private readonly string urlLogin;

        public AdicionesService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            urlAplicacion = _config.GetSection("Services")["apiAplicacion"];
            urlLogin = _config.GetSection("Services")["apiLogin"];
        }
        public async Task<Adicion> GetAdicionAsync(int DocEntry, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"AdicionesVino/{DocEntry}");
                JObject obj = JObject.Parse(json);
                Adicion searchResults = obj.ToObject<Adicion>();
                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                return null;
            }
        }
        public async Task<IList<Adicion>> GetAdicionesAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"AdicionesVino");
                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["value"].ToList();
                IList<Adicion> searchResults = new List<Adicion>();
                foreach (JToken result in results)
                {
                    Adicion searchResult = result.ToObject<Adicion>();
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

        public async Task<Adicion> PostAdicionAsync(Adicion adicion, string token)
        {
            foreach (var item in adicion.VID_ENADICICDCollection) {
                item.U_WhsCode = adicion.VID_ENADICICHCollection.First().U_Cuba;
            }
            var cuerpo2 = JsonConvert.SerializeObject(adicion.VID_ENADICICDCollection);
            var cuerpo3 = JsonConvert.SerializeObject(adicion.VID_ENADICICHCollection);
            List<VIDENADICICDCollectionPost> InsumosPost = JsonConvert.DeserializeObject<List<VIDENADICICDCollectionPost>>(cuerpo2);
            if (InsumosPost == null)
            {
                return null;
            }
            List<VIDENADICICHCollectionPost>  CubaPost = JsonConvert.DeserializeObject<List<VIDENADICICHCollectionPost>>(cuerpo3);
            if (CubaPost == null)
            {
                return null;
            }
            AdicionPost adicionPost = new AdicionPost()
            {
                U_Comentario = adicion.U_Comentario,
                U_NumOT = adicion.U_NumOT,
                U_Estado = "",
                U_FechaEmis = adicion.U_FechaEmis,
                U_UsuApp = "",
                VID_ENADICICDCollection = InsumosPost,
                VID_ENADICICHCollection = CubaPost
            };
            var cuerpo = JsonConvert.SerializeObject(adicionPost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpContent httpContent = new StringContent(cuerpo, Encoding.UTF8, "application/json");
            var response = (await _httpClient.PostAsync(urlAplicacion + $"AdicionesVino", httpContent));

            if (response.StatusCode.ToString() == "OK")
            {
                dynamic contenido = JsonConvert.DeserializeObject<ExpandoObject>(await response.Content.ReadAsStringAsync(), new ExpandoObjectConverter());
                JObject resultado = JObject.Parse(await response.Content.ReadAsStringAsync());
                adicion.DocEntry = Convert.ToInt32(resultado["DocEntry"]);
                return adicion;
            }
            else
            {
                return null;
            }

        }
        public async Task<IList<Lotes>> GetLotesAsync(string itemCode, string WhsCode, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"Item/GetStockLotesAlmacen/{itemCode}/{WhsCode}");

                JObject obj = JObject.Parse(json);
                IList<JToken> results = obj["Results"].ToList();
                IList<Lotes> searchResults = new List<Lotes>();
                foreach (JToken result in results)
                {
                    Lotes searchResult = result.ToObject<Lotes>();
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
        public async Task<IList<Cuba>> GetCubasAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"AdicionesVino/GetListaCubasStock");

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
        public async Task<IList<Insumos>> GetInsumosAsync(string token, string codCuba)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var json = await _httpClient.GetStringAsync(urlAplicacion + $"AdicionesVino/GetListaInsumosAlmacenInsumoCuba/{codCuba}");

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
