using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models
{
    public class EntradasVino
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string WhsCode { get; set; }
        public string BatchNum { get; set; }
        public double? BatchQuantity { get; set; }
        public string TotalStock { get; set; }
        public string AvgPrice { get; set; }
        public string InDate { get; set; }
        public string ExpDate { get; set; }
        public string Quantity { get; set; }
        public decimal? QuantOut { get; set; }
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
        public bool Prensa { get; set; }

        public double? Proporcion { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Valor kilos no es valido")]
        [Required(ErrorMessage = "Ingrese la cantidad a usar")]
        public double? CantidadIndicada { get; set; } = 0;
    }
}
