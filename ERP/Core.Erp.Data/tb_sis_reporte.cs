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
    
    public partial class tb_sis_reporte
    {
        public tb_sis_reporte()
        {
            this.tb_sis_reporte_x_formulario = new HashSet<tb_sis_reporte_x_formulario>();
        }
    
        public string CodReporte { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Modulo { get; set; }
        public string VistaRpt { get; set; }
        public string Formulario { get; set; }
        public string Class_NomReporte { get; set; }
        public string nom_Asembly { get; set; }
        public int Orden { get; set; }
        public string Observacion { get; set; }
        public byte[] imagen { get; set; }
        public Nullable<int> VersionActual { get; set; }
        public string Tipo_Balance { get; set; }
        public string SQuery { get; set; }
        public string Class_Info { get; set; }
        public string Class_Bus { get; set; }
        public string Class_Data { get; set; }
        public Nullable<int> IdGrupo_Reporte { get; set; }
        public Nullable<bool> se_Muestra_Admin_Reporte { get; set; }
        public string Estado { get; set; }
        public string Store_proce_rpt { get; set; }
        public byte[] Disenio_reporte { get; set; }
    
        public virtual tb_sis_reporte_Grupo tb_sis_reporte_Grupo { get; set; }
        public virtual tb_modulo tb_modulo { get; set; }
        public virtual ICollection<tb_sis_reporte_x_formulario> tb_sis_reporte_x_formulario { get; set; }
    }
}
