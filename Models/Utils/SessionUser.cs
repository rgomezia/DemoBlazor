using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazor.Models.Utils
{
    public class SessionUser
    {
        public int idEmpresa { get; set; }
        public string Token { get; set; }
        public string TokenAplicacion { get; set; }
        public string Usuario { get; set; }
        public DateTime HoraInicio { get; set; }
        public int idUser { get; set; }
    }
}
