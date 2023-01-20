namespace DemoBlazor.Models
{
    public class Barrica
    {
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
        public string BinCode { get; set; }
        public string AbsEntry { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BatchNum { get; set; }
        public string BatchQuantity { get; set; }
        public string TotalStockBin { get; set; }
        public string TotalStock { get; set; }
        public string AvgPrice { get; set; }
        public string InvntryUom { get; set; }
        public string InvntItem { get; set; }
        public string U_VD_EN_Tipo { get; set; }
        public string U_VD_EN_Ubica { get; set; }
        public string U_VD_EN_Capacidad { get; set; }
    }

    public class ResultBarrica
    {
        public List<Barrica> Results { get; set; }
    }



}