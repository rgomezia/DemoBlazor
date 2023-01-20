namespace DemoBlazor.Models
{
    public class Recepcion
    {
        public string AbsEntry { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string WhsCode { get; set; }
        public string BatchNum { get; set; }
        public string BatchQuantity { get; set; }
        public string TotalStock { get; set; }
        public string AvgPrice { get; set; }
        public string InDate { get; set; } = DateTime.Now.ToString("yyy-MM-dd");
        public string ExpDate { get; set; } = DateTime.Now.ToString("yyy-MM-dd");
        public string Quantity { get; set; } 
        public string QuantOut { get; set; } 
        public string U_VD_EN_Planta { get; set; } 
        public string U_VD_EN_Cuartel { get; set; } 
        public string U_VD_EN_Zona { get; set; }
        public string U_VD_EN_Variedad { get; set; } 
        public string U_VD_EN_Produc { get; set; } 
        public string U_VD_EN_Brix { get; set; } 
        public string U_VD_EN_AT { get; set; } 
        public string U_VD_EN_pH { get; set; } 
        public string U_VD_EN_AP { get; set; } 
        public string U_VD_EN_Comentario { get; set; } 
        public string U_VD_EN_TipCosecha { get; set; } 
    }
    
}
