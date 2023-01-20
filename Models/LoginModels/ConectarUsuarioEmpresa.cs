using System.Collections.Generic;

namespace DemoBlazor.Models.LoginModels
{
    public class ConectarUsuarioEmpresa
    {
        public int id_usuario { get; set; } 
        public List<Empresa> enpresas { get; set; }
        public string token { get; set; }

    }

}
