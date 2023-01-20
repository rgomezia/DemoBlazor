namespace DemoBlazor.Models
{
    public class AjusteAtributos
    {
        public int? DocNum { get; set; } = 0;
        public int? DocEntry { get; set; } = 0;
        public string? U_TipoOP { get; set; }
        public DateTime? U_FechaEmis { get; set; } = null; 
        public string? U_NumOT { get; set; }
        public string? U_UsuApp { get; set; }
        public string? U_Comentario { get; set; }
        public string? U_Cuba { get; set; }
        public string? U_Ubicacion { get; set; }
        public string? U_AbsEntryUbic { get; set; }
        public string? U_UbicCuba { get; set; }
        public string? U_TipoCuba { get; set; }
        public decimal? U_CapaciCuba { get; set; }  
        public string? U_ItemCode { get; set; }
        public string? U_ItemName { get; set; }
        public string? U_MezclaIni { get; set; }
        public decimal? U_CantidadIni { get; set; }  
        public string? U_ItemCodeFin { get; set; }
        public string? U_ItemNameFin { get; set; }
        public string? U_MezclaFin { get; set; }
        public decimal? U_CantidadFin { get; set; }  
        public int? U_DocEntryOF { get; set; } = 0;
        public int? U_DocEntryEOF { get; set; } = 0;
        public int? U_DocEntryROF { get; set; } = 0;



        public int? U_AnioVend { get; set; } = 0;
        public string? U_TipoVino { get; set; }
        public string? U_UsoPensa { get; set; }
        public decimal? U_AtrCanti { get; set; }  
        public decimal? U_EstMicro { get; set; }  
        public string? U_AtrComent { get; set; }
        public int? U_DiasMacera { get; set; } = 0;
        public int? U_DiasFerment { get; set; } = 0;
        public int? U_DiasBarrica { get; set; } = 0;
        public decimal? U_PorcEnvBarr { get; set; }  
        public decimal? U_RdtoLtsKg { get; set; }
        public DateTime? U_FecLlenado { get; set; } = null;
        public DateTime? U_ProxLlenado { get; set; } = null;
        public string? U_GradoAlcohol { get; set; }
        public string? U_PresSorbato { get; set; }
        public string? U_NivAzucar { get; set; }
        public string? U_Edulcorante { get; set; }
    }
}
