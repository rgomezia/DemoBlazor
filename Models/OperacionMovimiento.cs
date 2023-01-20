namespace DemoBlazor.Models
{
    public class OperacionMovimiento
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class ResultadoMovimiento
    {
        public List<OperacionMovimiento> Results { get; set; }
    }
}
