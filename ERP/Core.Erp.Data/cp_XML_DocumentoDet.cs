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
    
    public partial class cp_XML_DocumentoDet
    {
        public int IdEmpresa { get; set; }
        public decimal IdDocumento { get; set; }
        public int Secuencia { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> PorcentajeIVA { get; set; }
        public Nullable<double> ValorIva { get; set; }
        public Nullable<double> Total { get; set; }
    
        public virtual cp_XML_Documento cp_XML_Documento { get; set; }
    }
}
