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
    
    public partial class ro_periodo
    {
        public ro_periodo()
        {
            this.ro_Ing_Egre_x_Empleado = new HashSet<ro_Ing_Egre_x_Empleado>();
            this.ro_nomina_x_horas_extras = new HashSet<ro_nomina_x_horas_extras>();
            this.ro_rol = new HashSet<ro_rol>();
            this.ro_salario_digno = new HashSet<ro_salario_digno>();
            this.ro_periodo_x_ro_Nomina_TipoLiqui = new HashSet<ro_periodo_x_ro_Nomina_TipoLiqui>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdPeriodo { get; set; }
        public Nullable<int> pe_anio { get; set; }
        public Nullable<int> pe_mes { get; set; }
        public System.DateTime pe_FechaIni { get; set; }
        public System.DateTime pe_FechaFin { get; set; }
        public string pe_estado { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaHoraAnul { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public string Cod_region { get; set; }
        public Nullable<bool> Carga_Todos_Empleados { get; set; }
    
        public virtual ICollection<ro_Ing_Egre_x_Empleado> ro_Ing_Egre_x_Empleado { get; set; }
        public virtual ICollection<ro_nomina_x_horas_extras> ro_nomina_x_horas_extras { get; set; }
        public virtual ICollection<ro_rol> ro_rol { get; set; }
        public virtual ICollection<ro_salario_digno> ro_salario_digno { get; set; }
        public virtual ICollection<ro_periodo_x_ro_Nomina_TipoLiqui> ro_periodo_x_ro_Nomina_TipoLiqui { get; set; }
    }
}
