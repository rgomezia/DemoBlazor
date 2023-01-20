namespace DemoBlazor.Models.LoginModels
{
    public class LoginEnvioMailRecuperacion
    {
        public string idAplicacion { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string tipoLogin { get; set; }
        public string urlRecuparacion { get; set; }
    }
}
