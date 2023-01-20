namespace DemoBlazor.Models
{
    public class Insumos
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string InvntryUom { get; set; }
        public string StockValue { get; set; }
        public string OnHand { get; set; }
        public string U_Tipo { get; set; }
        public string WhsCode { get; set; }
        public string Disponible { get; set; }
    }

public class ListInsumos
    {
        public List<Insumos> lstInsumos { get; set; }
    }

}
