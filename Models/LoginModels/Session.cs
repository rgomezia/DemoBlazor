using System;

namespace DemoBlazor.Models.LoginModels
{
    public class Session
    {
        public string tokenLogin { get; set; }
        public string tokenAplicacion { get; set; }
        public int idUsuario { get; set; }
        public int idEmpresa { get; set; }

        public int idAplicacion { get; set; }
        public string codigoAplicacion { get; set; }
        public DateTime fechaInicio { get; set; }

    }
}
