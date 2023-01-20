namespace DemoBlazor.Models
{
    public class Movimiento
    {
        public Movimiento()
        {
            VID_ENMOVIDCollection = new List<CubaOrigenCollection>();
            VID_ENMOVIHCollection = new List<CubaDestinoCollection>();
        }
        public int DocNum { get; set; } = 0;
        public int DocEntry { get; set; } = 0;
        public string U_TipoOP { get; set; }
        public DateTime U_FechaEmis { get; set; } = DateTime.Now;
        public string U_NumOT { get; set; }
        public string U_UsuApp { get; set; }
        public string U_Comentario { get; set; }
        public string U_Estado { get; set; }
        public int U_TotCubasD { get; set; }
        public int U_TotLitrosD { get; set; }
        public int U_TotCubasH { get; set; }
        public int U_TotLitrosH { get; set; }
        public int U_TotDiferencia { get; set; }
        public int U_DocEntryOF { get; set; } = 0;
        public List<CubaOrigenCollection> VID_ENMOVIDCollection { get; set; }
        public List<CubaDestinoCollection> VID_ENMOVIHCollection { get; set; }
    }

    public class CubaOrigenCollection
    {
        public int DocEntry { get; set; } = 0;
        public int LineId { get; set; } = 0;
        public string U_Cuba { get; set; }//Almacen
        public string U_Ubicacion { get; set; }//Cuba
        public string U_AbsEntryUbic { get; set; }//AbsEntry Cuba
        public string U_UbicCuba { get; set; }
        public string U_TipoCuba { get; set; }
        public string U_ItemCode { get; set; }
        public string U_ItemName { get; set; }
        public string U_Mezcla { get; set; }
        public int U_CapaciCuba { get; set; }
        public int U_CantidadIni { get; set; }
        public int U_Cantidad { get; set; }
        public int U_CantidadRestada { get; set; }
        public int U_DocEntryROF { get; set; }
        public int U_LineNumROF { get; set; }
        public int U_CantBarricWhs { get; set; } = 0;
        public int U_CantBarricMov { get; set; } = 0;
        public bool Vaciar { get; set; } = false;

    }

    public class CubaDestinoCollection
    {
        public int DocEntry { get; set; } = 0;
        public int LineId { get; set; } = 0;
        public string U_Cuba { get; set; }//Almacen
        public string U_Ubicacion { get; set; }//Cuba
        public string U_AbsEntryUbic { get; set; }//AbsEntry Cuba
        public string U_UbicCuba { get; set; }
        public string U_TipoCuba { get; set; }
        public string U_ItemCode { get; set; }
        public string U_ItemName { get; set; }
        public string U_MezclaIni { get; set; }
        public int U_CantidadIni { get; set; }
        public string U_ItemCodeFin { get; set; }
        public string U_ItemNameFin { get; set; }
        public string U_MezclaFin { get; set; }
        public int U_CapaciCuba { get; set; }
        public int U_CantidadFin { get; set; }
        public int U_CantidadAgregada { get; set; }
        public int U_DocEntryROF { get; set; } = 0;
        public int U_LineNumROF { get; set; } = 0;
        public int U_CantBarricWhs { get; set; } = 0;
        public int U_CantBarricMov { get; set; } = 0;
    }
    public class GETMovimiento
    {
        public GETMovimiento()
        {
            VID_ENMOVIDCollection = new List<GETCubaOrigenCollection>();
            VID_ENMOVIHCollection = new List<GETCubaDestinoCollection>();
        }
        public int DocNum { get; set; } = 0;
        public int DocEntry { get; set; } = 0;
        public string U_TipoOP { get; set; }
        public DateTime U_FechaEmis { get; set; } = DateTime.Now;
        public string? U_NumOT { get; set; }
        public string? U_UsuApp { get; set; }
        public string? U_Comentario { get; set; }
        public string? U_Estado { get; set; }
        public int? U_TotCubasD { get; set; } = 0;
        public int? U_TotLitrosD { get; set; } = 0;
        public int? U_TotCubasH { get; set; } = 0;
        public int? U_TotLitrosH { get; set; } = 0;
        public int? U_TotDiferencia { get; set; } = 0;
        public int? U_DocEntryOF { get; set; } = 0;
        public List<GETCubaOrigenCollection> VID_ENMOVIDCollection { get; set; }
        public List<GETCubaDestinoCollection> VID_ENMOVIHCollection { get; set; }
    }

    public class GETCubaOrigenCollection
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public string? U_Cuba { get; set; }
        public string? U_Ubicacion { get; set; }
        public string? U_UbicCuba { get; set; }
        public string? U_TipoCuba { get; set; }
        public string? U_ItemCode { get; set; }
        public string? U_ItemName { get; set; }
        public string? U_Mezcla { get; set; }
        public int? U_CapaciCuba { get; set; } = 0;
        public int? U_CantidadIni { get; set; } = 0;
        public int? U_Cantidad { get; set; } = 0;
        public int? U_DocEntryROF { get; set; } = 0;
        public int? U_LineNumROF { get; set; } = 0;
        public int? U_CantBarricWhs { get; set; } = 0;
        public int? U_CantBarricMov { get; set; } = 0;
    }

    public class GETCubaDestinoCollection
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public string? U_Cuba { get; set; }
        public string? U_Ubicacion { get; set; }
        public string? U_UbicCuba { get; set; }
        public string? U_TipoCuba { get; set; }
        public string? U_ItemCode { get; set; }
        public string? U_ItemName { get; set; }
        public string? U_MezclaIni { get; set; }
        public int? U_CantidadIni { get; set; } = 0;
        public string? U_ItemCodeFin { get; set; }
        public string? U_ItemNameFin { get; set; }
        public string? U_MezclaFin { get; set; }
        public int? U_CapaciCuba { get; set; } = 0;
        public int? U_CantidadFin { get; set; } = 0;
        public int? U_DocEntryROF { get; set; } = 0;
        public int? U_LineNumROF { get; set; } = 0;
        public int? U_CantBarricWhs { get; set; } = 0;
        public int? U_CantBarricMov { get; set; } = 0;
    }
}
