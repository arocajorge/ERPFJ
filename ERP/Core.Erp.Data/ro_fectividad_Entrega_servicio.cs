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
    
    public partial class ro_fectividad_Entrega_servicio
    {
        public ro_fectividad_Entrega_servicio()
        {
            this.ro_fectividad_Entrega_servicio_det = new HashSet<ro_fectividad_Entrega_servicio_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdNivelServicio { get; set; }
        public int IdServicioTipo { get; set; }
        public int IdNomina_Tipo { get; set; }
        public int IdNomina_tipo_Liq { get; set; }
        public int IdPeriodo { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioAnu { get; set; }
        public string MotivoAnu { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> FechaAnu { get; set; }
        public System.DateTime FechaTransac { get; set; }
        public Nullable<System.DateTime> FechaUltModi { get; set; }
    
        public virtual ICollection<ro_fectividad_Entrega_servicio_det> ro_fectividad_Entrega_servicio_det { get; set; }
    }
}
