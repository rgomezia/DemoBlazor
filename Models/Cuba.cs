namespace DemoBlazor.Models
{
    public class Cuba
    {
        public string WhsCode { get; set; }//Cod almacen
        public string WhsName { get; set; }//nombre almacen
        public string WhsCodeInsumo { get; set; }//Cod almacen de insumos
        public string BinCode { get; set; }//Cod cuba
        public string AbsEntry { get; set; }//Cod interno de la cuba
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BatchNum { get; set; }
        public string BatchQuantity { get; set; }
        public string TotalStockBin { get; set; }
        public string TotalStock { get; set; }
        public string AvgPrice { get; set; }
        public string InvntryUom { get; set; }
        public string InvntItem { get; set; }
        public string InDate { get; set; }
        public string ExpDate { get; set; }
        public string U_VD_EN_Tipo { get; set; }
        public string U_VD_EN_Ubica { get; set; }
        public string U_VD_EN_Capacidad { get; set; }
    }


    public class ListCubas
    {
        public List<Cuba> lstCubas { get; set; }
    }

}
