namespace DemoBlazor.Models
{
    public class Usuario
    {
        public int? id { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public int activo { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public DateTime? fecha_ult_clave { get; set; }
        public DateTime? fecha_ult_login { get; set; }
        public int? id_aplicacion { get; set; }
        public int? idPerfil { get; set; }
        public string? nombrePerfil { get; set; }
        public string? idusuarioSAP { get; set; }
        public string? usuarioSAP { get; set; }

    }
}
