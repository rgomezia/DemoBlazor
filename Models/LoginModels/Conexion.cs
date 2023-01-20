using RestSharp;

namespace DemoBlazor.Models.LoginModels
{
    public class Settings
    {
        public string host { get; set; }
    }
    public class Conexion
    {
        public string startUrl { get; set; }
        public string endUrl { get; set; }
        public string body { get; set; }
        public string Token { get; set; }
        public Method method { get; set; }

    }
}
