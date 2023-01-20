using Newtonsoft.Json;

namespace DemoBlazor.Models
{

    public class Entrada
    {
        public int? DocNum { get; set; }
        public int? DocEntry { get; set; }
        public string? U_TipoOP { get; set; }
        public string? U_FechaEmis { get; set; }
        public string? U_NumOT { get; set; }
        public string? U_UsuApp { get; set; }
        public string? U_Comentario { get; set; }
        public string? U_TipoPrensa { get; set; }
        public double? U_Rendimiento { get; set; }
        public string? U_Estado { get; set; }
        public int? U_TotPartidas { get; set; }
        public double? U_TotKilos { get; set; }
        public double? U_TotLitros { get; set; }
        public int? U_DocEntryOF { get; set; }
        public string? U_ErrorOF { get; set; }
        public string? U_ErrorENT { get; set; }
        public string? U_ErrorREC { get; set; }
        public List<VIDENENTRADDCollection>? VID_ENENTRADDCollection { get; set; }
        public List<VIDENENTRADHCollection>? VID_ENENTRADHCollection { get; set; }
    }

    public class VIDENENTRADDCollection
    {
        //public int? DocEntry { get; set; }
        //public int? LineId { get; set; }
        //public int? VisOrder { get; set; }
        public string? U_Cuba { get; set; }
        public string? U_Ubicacion { get; set; }
        public string? U_AbsEntryUbic { get; set; }
        public string? U_UbicCuba { get; set; }
        public string? U_TipoCuba { get; set; }
        public decimal? U_CapaciCuba { get; set; }
        public string? U_ItemCode { get; set; }
        public string? U_ItemName { get; set; }
        public string? U_Partida { get; set; }
        public string? U_Cuartel { get; set; } = " ";
        public string? U_Variedad { get; set; } = " ";
        public double? U_CantidadIni { get; set; }
        public double? U_Cantidad { get; set; }
        public string? U_Prensa { get; set; }
        public int? U_DocEntryEOF { get; set; }
        public int? U_LineNumCOF { get; set; }
        public string? U_WhsCode { get; set; }

    }

    public class VIDENENTRADHCollection
    {
        //public int? DocEntry { get; set; }
        //public int? LineId { get; set; }
        //public int? VisOrder { get; set; }
        public string? U_Cuba { get; set; }
        public string? U_Ubicacion { get; set; }
        public string? U_AbsEntryUbic { get; set; }
        public string? U_UbicCuba { get; set; }
        public string? U_TipoCuba { get; set; }
        public double? U_CapaciCuba { get; set; }
        public string? U_ItemCode { get; set; }
        public string? U_ItemName { get; set; }
        public string? U_Mezcla { get; set; }
        public double? U_CantidadIni { get; set; }
        public double? U_Cantidad { get; set; }
        public int? U_DocEntryROF { get; set; }
        public int? U_LineNumROF { get; set; }
    }
}
