namespace DemoBlazor.Models.LoginModels
{
    public class Usuario
    {
        public Usuario()
        {
            User = "";
            Pass = "";
            empresa = new Empresa() { id = 0, descripcion = "Selecciona una empresa" };
            empresas = new List<Empresa>();
        }
        public int id { get; set; }
        public string User { get; set; }
        public string email { get; set; }
        public string Pass { get; set; }
        public bool RememberMe { get; set; }
        public string Token { get; set; }
        public string TokenAplicacion { get; set; }
        public Empresa empresa { get; set; }
        public List<Empresa> empresas { get; set; }
    }
}
