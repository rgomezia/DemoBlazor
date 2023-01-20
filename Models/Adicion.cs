namespace DemoBlazor.Models
{
    public class Adicion
    {
        public Adicion()
        {
            VID_ENADICICDCollection = new List<VIDENADICICDCollection>();
            VID_ENADICICHCollection = new List<VIDENADICICHCollection>();
        }
        public int? DocNum { get; set; } = 0;
        public int? Period { get; set; } = 0;
        public int? Instance { get; set; } = 0;
        public int? Series { get; set; } = 0;
        public string? Handwrtten { get; set; } = "";
        public string? Status { get; set; } = "";
        public string? RequestStatus { get; set; } = "";
        public string? Creator { get; set; } = "";
        public string? Remark { get; set; } = "";
        public int DocEntry { get; set; } = 0;
        public string? Canceled { get; set; } = "";
        public string? Object { get; set; } = "";
        public int? UserSign { get; set; } = 0;
        public string? Transfered { get; set; } = "";
        public DateTime? CreateDate { get; set; }
        public string? CreateTime { get; set; } = "";
        public DateTime? UpdateDate { get; set; }
        public string? UpdateTime { get; set; } = "";
        public string? DataSource { get; set; } = "";
        public DateTime U_FechaEmis { get; set; } = DateTime.Now;
        public string? U_NumOT { get; set; } = "";
        public string? U_UsuApp { get; set; } = "";
        public string? U_Comentario { get; set; } = "";
        public string? U_Estado { get; set; } = "";
        public int? U_DocEntryOF { get; set; } = 0;
        public List<VIDENADICICDCollection> VID_ENADICICDCollection { get; set; }
        public List<VIDENADICICHCollection> VID_ENADICICHCollection { get; set; }
    }

    public class VIDENADICICDCollection
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public int? VisOrder { get; set; } = 0;
        public string? Object { get; set; } = "";
        public int? LogInst { get; set; } = 0;
        public string? U_ItemCode { get; set; } = "";
        public string? U_ItemName { get; set; } = "";
        public string? U_WhsCode { get; set; } = "";
        public string? U_Lote { get; set; } = "";
        public double U_Cantidad { get; set; } = 0;
        public int? U_Concentra { get; set; } = 0;
        public int U_Agua { get; set; } = 0;
        public int? U_PorcAdici { get; set; } = 0;
        public int? U_DocEntryEOF { get; set; } = 0;
        public int? U_LineNumCOF { get; set; } = 0;
        public string? InvntryUom { get; set; } = "";
        public string? StockValue { get; set; } = "";
    }
    public class VIDENADICICHCollection
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public int? VisOrder { get; set; } = 0;
        public string? Object { get; set; } = "";
        public int? LogInst { get; set; } = 0;
        public string? U_Cuba { get; set; } = "";//cod Almacen
        public string? U_Ubicacion { get; set; } = "";//cod cuba
        public string? U_AbsEntryUbic { get; set; } = "";//ABS entry cuba
        public string? U_ItemCode { get; set; } = "";
        public string? U_ItemName { get; set; } = "";
        public string? U_MezclaIni { get; set; } = "";
        public int U_CantidadIni { get; set; } = 0;
        public string? U_MezclaFin { get; set; } = "";
        public int U_CantidadFin { get; set; } = 0;
        public int? U_DocEntryROF { get; set; } = 0;
        public int? U_LineNumROF { get; set; } = 0;
        public string? InvntryUom { get; set; } = "";
        public string? U_UbicCuba { get; set; } = "";
        public string? U_TipoCuba { get; set; } = "";
        public string? U_VD_EN_Tipo { get; set; } = "";
        public string? U_VD_EN_Ubica { get; set; } = "";
        public string? U_VD_EN_Capacidad { get; set; } = "";
        public int? U_CapaciCuba { get; set; } = 0;
    }

    public class AdicionPost
    {
        public int DocEntry { get; set; } = 0;
        public int DocNum { get; set; } = 0;
        public string U_Comentario { get; set; } = "";
        public int U_DocEntryOF { get; set; } = 0;
        public string U_Estado { get; set; } = "";
        public DateTime U_FechaEmis { get; set; }
        public string U_NumOT { get; set; } = "";
        public string U_UsuApp { get; set; } = "";

        public List<VIDENADICICDCollectionPost> VID_ENADICICDCollection { get; set; }
        public List<VIDENADICICHCollectionPost> VID_ENADICICHCollection { get; set; }
    }

    public class VIDENADICICDCollectionPost
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public int U_Agua { get; set; } = 0;
        public double U_Cantidad { get; set; } = 0;
        public int? U_Concentra { get; set; } = 0;
        public int? U_DocEntryEOF { get; set; } = 0;
        public string? U_ItemCode { get; set; } = "";
        public string? U_ItemName { get; set; } = "";
        public int? U_LineNumCOF { get; set; } = 0;
        public string? U_Lote { get; set; } = "";
        public int? U_PorcAdici { get; set; } = 0;
        public string? U_WhsCode { get; set; } = "";
    }

    public class VIDENADICICHCollectionPost
    {
        public int? DocEntry { get; set; } = 0;
        public int? LineId { get; set; } = 0;
        public int U_CantidadFin { get; set; } = 0;
        public int U_CantidadIni { get; set; } = 0;
        public string? U_Cuba { get; set; } = "";//cod Almacen
        public string? U_Ubicacion { get; set; } = "";//cod cuba
        public string? U_AbsEntryUbic { get; set; } = "";//ABS entry cuba
        public int? U_DocEntryROF { get; set; } = 0;
        public string? U_ItemCode { get; set; } = "";
        public string? U_ItemName { get; set; } = "";
        public int? U_LineNumROF { get; set; } = 0;
        public string? U_MezclaFin { get; set; } = "";
        public string? U_MezclaIni { get; set; } = "";
        public string? U_UbicCuba { get; set; } = "";
        public string? U_TipoCuba { get; set; } = "";
        public string? U_VD_EN_Tipo { get; set; } = "";
        public string? U_VD_EN_Ubica { get; set; } = "";
        public string? U_VD_EN_Capacidad { get; set; } = "";
        public int? U_CapaciCuba { get; set; } = 0;

    }
    /*
    public class Adicion
    {
        public int DocEntry { get; set; }
        public string OT { get; set; } = "";
        public string UserSign { get; set; } = "";
        public string U_DocDate { get; set; } = DateTime.Now.ToString("yyy-MM-dd");
        public string U_Comments { get; set; } = "";
        public List<Insumos> insumos { get; set; } = new List<Insumos>();
        public Cuba cuba { get; set; } = new Cuba();

    }
    */
}
