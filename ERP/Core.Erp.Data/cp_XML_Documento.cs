//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cp_XML_Documento
    {
        public cp_XML_Documento()
        {
            this.cp_XML_Documento_Retencion = new HashSet<cp_XML_Documento_Retencion>();
            this.cp_XML_DocumentoDet = new HashSet<cp_XML_DocumentoDet>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public string Comprobante { get; set; }
        public string XML { get; set; }
        public string Tipo { get; set; }
        public string emi_RazonSocial { get; set; }
        public string emi_NombreComercial { get; set; }
        public string emi_Ruc { get; set; }
        public string emi_DireccionMatriz { get; set; }
        public string emi_ContribuyenteEspecial { get; set; }
        public string ClaveAcceso { get; set; }
        public string CodDocumento { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string NumeroDocumento { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public string rec_RazonSocial { get; set; }
        public string rec_Identificacion { get; set; }
        public double Subtotal0 { get; set; }
        public double SubtotalIVA { get; set; }
        public double Porcentaje { get; set; }
        public double ValorIVA { get; set; }
        public double Total { get; set; }
        public string FormaPago { get; set; }
        public int Plazo { get; set; }
        public string ret_CodDocumentoTipo { get; set; }
        public string ret_Establecimiento { get; set; }
        public string ret_PuntoEmision { get; set; }
        public string ret_NumeroDocumento { get; set; }
        public Nullable<System.DateTime> ret_Fecha { get; set; }
        public Nullable<System.DateTime> ret_FechaAutorizacion { get; set; }
        public string ret_NumeroAutorizacion { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> IdTipoCbte { get; set; }
        public Nullable<decimal> IdCbteCble { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
    
        public virtual ICollection<cp_XML_Documento_Retencion> cp_XML_Documento_Retencion { get; set; }
        public virtual ICollection<cp_XML_DocumentoDet> cp_XML_DocumentoDet { get; set; }
    }
}