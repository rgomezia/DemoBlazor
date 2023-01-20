using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models
{
    public class CubaEntradaVino
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? WhsCode { get; set; }
        public string? WhsName { get; set; }
        public string? BinCode { get; set; }
        public string? AbsEntry { get; set; }
        public string? BatchNum { get; set; }
        public string? BatchQuantity { get; set; } = "0";
        public string? TotalStock { get; set; }
        public string? AvgPrice { get; set; }
        public string? InDate { get; set; }
        public string? ExpDate { get; set; }
        public string? InvntryUom { get; set; }
        public string? InvntItem { get; set; }
        public string? U_VD_EN_Tipo { get; set; }
        public string? U_VD_EN_Ubica { get; set; }
        public string? U_VD_EN_Capacidad { get; set; }
        public string? TotalStockBin { get; set; }

        public bool Prensa { get; set; }

        //AÑADIDOS
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Valor litros no es valido")]
        [Required(ErrorMessage = "Ingrese la cantidad de litros")]
        public double? CantidadLitros { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "No se permite el ingreso de caracteres especiales")]
        [Required(ErrorMessage = "Ingrese un valor valido para mezcla")]
        public string? Mezcla { get; set; } = "";
        public decimal? Rendimiento { get; set; } = 0;
        public double? U_CantidadFin { get; set; }
        public double CantRestada { get; set; } = 0;
    }
}
