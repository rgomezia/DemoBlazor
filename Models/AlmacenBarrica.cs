namespace DemoBlazor.Models
{
    public class AlmacenBarrica
    {
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BatchNum { get; set; }
        public string CantBarricas { get; set; }
        public string CantBarricasUtil { get; set; }
        public string CantBarricasDisp { get; set; }
    }

    public class ResultAlmacenBarrica
    {
        public List<AlmacenBarrica> Results { get; set; }
    }

}