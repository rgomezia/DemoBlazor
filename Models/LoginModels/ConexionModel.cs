using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazor.Models.LoginModels
{
    public class ConexionModel
    {
        public static async Task<HttpResponseMessage> Get(string startUrl, string endUrl, string ACCESS_TOKEN = "")
        {
            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri(startUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (ACCESS_TOKEN != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
            }
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + endUrl).Result;
            return response;
        }
        public static async Task<HttpResponseMessage> Post(string startUrl, string endUrl, string encabezado, string ACCESS_TOKEN = "")
        {
            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri(startUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (ACCESS_TOKEN != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
            }
            HttpResponseMessage respuesta = new HttpResponseMessage();

            HttpContent httpContent = new StringContent(encabezado, Encoding.UTF8, "application/json");
            //using var responsex = await Http.PostAsJsonAsync(url, primerlogin);
            var response = await client.PostAsync(client.BaseAddress + endUrl, httpContent);
            return response;
        }
        public string Encriptar(string input)
        {
            byte[] iv = Encoding.ASCII.GetBytes("qualityi");
            byte[] encryptionKey = Convert.FromBase64String("rpadftlyhorfdertghyujki8765rgyhj");
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider des = new();
            des.Key = encryptionKey;
            des.IV = iv;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        public byte[] CreateBinaryData<T>(T TObject)
        {
            if (TObject == null)
                return null;

            byte[] binaryData;
            JsonSerializer serializer = new JsonSerializer();
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonDataWriter bsonWriter = new BsonDataWriter(ms))
                {
                    serializer.Serialize(bsonWriter, TObject);
                }
                binaryData = ms.ToArray();
            }

            return binaryData;
        }
        public string Conexion()
        {
            ConexionModel dt = new ConexionModel();

            byte[] binaryData = CreateBinaryData(dt);
            string b64 = Convert.ToBase64String(binaryData);

            return b64;
        }
        public string ListadoGet(string api)
        {
            string _CREDENCIALES = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("EPISODE:123"));

            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);

            var response = client.GetAsync(client.BaseAddress + api + Conexion()).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "";
            }
        }

    }
}
