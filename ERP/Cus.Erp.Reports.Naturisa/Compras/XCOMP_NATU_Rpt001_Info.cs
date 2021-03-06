﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cus.Erp.Reports.Naturisa.Compras
{
    public class XCOMP_NATU_Rpt001_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdOrdenCompra { get; set; }
        public decimal IdProveedor { get; set; }
        public System.DateTime Fecha_OC { get; set; }
        public string Observacion_OC { get; set; }
        public string Estado_OC { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public double cantidad_det { get; set; }
        public double Precio_det { get; set; }
        public double Subtotal_det { get; set; }
        public double Iva_det { get; set; }
        public double Total_det { get; set; }
        public string cod_proveedor { get; set; }
        public string nom_proveedor { get; set; }
        public string cod_producto { get; set; }
        public string nom_producto { get; set; }
        public string nom_sucursal { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string nom_punto_cargo { get; set; }
        public decimal IdComprador { get; set; }
        public string nom_comprador { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public string nom_punto_cargo_grupo { get; set; }
        public string cod_Punto_cargo_grupo { get; set; }
        public string codPunto_cargo { get; set; }
        public string IdUnidadMedida { get; set; }
        public double Por_Iva { get; set; }
        public string do_observacion { get; set; }
        public double do_precioFinal { get; set; }
        public double do_porc_des { get; set; }
        public string IdEstadoAprobacion_cat { get; set; }
        public string nom_estado_aprobacion { get; set; }
        public int oc_plazo { get; set; }
                                                               
            
        public XCOMP_NATU_Rpt001_Info()

        {

       }
    }
}
