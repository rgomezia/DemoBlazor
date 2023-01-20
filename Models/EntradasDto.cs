namespace DemoBlazor.Models
{
    public class EntradasDto
    {
        public int DocNum { get; set; }
        public int Period { get; set; }
        public int Instance { get; set; }
        public int Series { get; set; }
        public string Handwrtten { get; set; }
        public string Status { get; set; }
        public string RequestStatus { get; set; }
        public string Creator { get; set; }
        public string Remark { get; set; }
        public int DocEntry { get; set; }
        public string Canceled { get; set; }
        public string Object { get; set; }
        public object LogInst { get; set; }
        public int UserSign { get; set; }
        public string Transfered { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateTime { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public string DataSource { get; set; }
        public string U_TipoOP { get; set; }
        public DateTime U_FechaEmis { get; set; }
        public string U_NumOT { get; set; }
        public string U_UsuApp { get; set; }
        public string U_Comentario { get; set; }
        public string U_TipoPrensa { get; set; }
        public int U_Rendimiento { get; set; }
        public string U_Estado { get; set; }
        public int U_TotPartidas { get; set; }
        public int U_TotKilos { get; set; }
        public object U_DocEntryOF { get; set; }
        public object U_TotLitros { get; set; }
        public object U_ErrorOF { get; set; }
        public object U_ErrorENT { get; set; }
        public object U_ErrorREC { get; set; }
        public List<VIDENENTRADDCollections> VID_ENENTRADDCollection { get; set; }
        public List<VIDENENTRADHCollections> VID_ENENTRADHCollection { get; set; }
    }

    public class VIDENENTRADDCollections
    {
        public int DocEntry { get; set; }
        public int LineId { get; set; }
        public int VisOrder { get; set; }
        public string Object { get; set; }
        public object LogInst { get; set; }
        public string U_ItemCode { get; set; }
        public string U_ItemName { get; set; }
        public string U_Partida { get; set; }
        public int U_Cantidad { get; set; }
        public object U_DocEntryEOF { get; set; }
        public object U_LineNumCOF { get; set; }
        public object U_CantidadIni { get; set; }
        public object U_WhsCode { get; set; }
        public object U_Cuartel { get; set; }
        public object U_Variedad { get; set; }
        public object U_Prensa { get; set; }
    }

    public class VIDENENTRADHCollections
    {
        public int DocEntry { get; set; }
        public int LineId { get; set; }
        public int VisOrder { get; set; }
        public string Object { get; set; }
        public object LogInst { get; set; }
        public string U_Cuba { get; set; }
        public string U_ItemCode { get; set; }
        public string U_ItemName { get; set; }
        public string U_Mezcla { get; set; }
        public int U_Cantidad { get; set; }
        public object U_DocEntryROF { get; set; }
        public object U_LineNumROF { get; set; }
        public object U_UbicCuba { get; set; }
        public object U_TipoCuba { get; set; }
        public object U_Ubicacion { get; set; }
        public object U_CapaciCuba { get; set; }
        public object U_AbsEntryUbic { get; set; }
    }

}
