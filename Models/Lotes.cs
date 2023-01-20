namespace DemoBlazor.Models
{
    public class Lotes
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string WhsCode { get; set; }
        public string BatchNum { get; set; }
        public string BatchQuantity { get; set; }
        public double Seleccionado { get; set; }
        public string TotalStock { get; set; }
        public string InDate { get; set; }
        public string ExpDate { get; set; }
    }

    public class ResultLotes
    {
        public List<Lotes> resultLotes { get; set; }
    }

}
