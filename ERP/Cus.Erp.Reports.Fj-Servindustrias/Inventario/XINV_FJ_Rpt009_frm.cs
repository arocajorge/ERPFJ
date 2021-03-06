﻿using Core.Erp.Business.General;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Erp.Reportes.Controles;
using Core.Erp.Reportes.Inventario;

namespace Cus.Erp.Reports.FJ.Inventario
{
    public partial class XINV_FJ_Rpt009_frm : Form
    {
        #region variables
        cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;
        tb_sis_Log_Error_Vzen_Bus Log_Error_bus = new tb_sis_Log_Error_Vzen_Bus();

        #endregion

        public XINV_FJ_Rpt009_frm()
        {
            InitializeComponent();
        }

        private void ucInv_MenuReportes2_event_tnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                bool Mostrar_valores_en_0 = ucInv_MenuReportes2.beiCheck1.EditValue == null ? false : Convert.ToBoolean(ucInv_MenuReportes2.beiCheck1.EditValue);
                bool Mostrar_detallado = ucInv_MenuReportes2.beiCheck2.EditValue == null ? false : Convert.ToBoolean(ucInv_MenuReportes2.beiCheck2.EditValue);

                if (Mostrar_detallado )
                {

                    XINV_FJ_Rpt009_Rpt rpt = new XINV_FJ_Rpt009_Rpt();

                    rpt.P_fecha_ini.Value = ucInv_MenuReportes2.dtpDesde.EditValue == null ? DateTime.Now : Convert.ToDateTime(ucInv_MenuReportes2.dtpDesde.EditValue);
                    rpt.P_fecha_fin.Value = ucInv_MenuReportes2.dtpHasta.EditValue == null ? DateTime.Now : Convert.ToDateTime(ucInv_MenuReportes2.dtpHasta.EditValue);
                    rpt.P_IdSucursal.Value = ucInv_MenuReportes2.Get_info_sucursal() == null ? 0 : ucInv_MenuReportes2.Get_info_sucursal().IdSucursal;
                    rpt.set_lst_bodega(ucInv_MenuReportes2.Get_list_bodega_chk());
                    rpt.P_IdProducto.Value = ucInv_MenuReportes2.Get_info_producto() == null ? 0 : ucInv_MenuReportes2.Get_info_producto().IdProducto;
                    rpt.P_mostrar_valores_en_0.Value = Mostrar_valores_en_0;
                    rpt.P_mostrar_agrupado.Value = Mostrar_detallado;
                    rpt.P_IdPuntoCargo.Value = ucInv_MenuReportes2.bei_punto_cargo.EditValue == null ? 0 : ucInv_MenuReportes2.bei_punto_cargo.EditValue;
                    rpt.RequestParameters = false;

                    ReportPrintTool pt = new ReportPrintTool(rpt);
                    printControl1.PrintingSystem = rpt.PrintingSystem;
                    splashScreenManager1.ShowWaitForm();
                    rpt.CreateDocument();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {

                    XINV_Rpt011_rpt rpt = new XINV_Rpt011_rpt();

                    rpt.p_fecha_ini.Value = ucInv_MenuReportes2.dtpDesde.EditValue == null ? DateTime.Now : Convert.ToDateTime(ucInv_MenuReportes2.dtpDesde.EditValue);
                    rpt.p_fecha_fin.Value = ucInv_MenuReportes2.dtpHasta.EditValue == null ? DateTime.Now : Convert.ToDateTime(ucInv_MenuReportes2.dtpHasta.EditValue);
                    rpt.p_IdSucursal.Value = ucInv_MenuReportes2.Get_info_sucursal() == null ? 0 : ucInv_MenuReportes2.Get_info_sucursal().IdSucursal;
                    rpt.set_lst_bodega(ucInv_MenuReportes2.Get_list_bodega_chk());
                    rpt.p_IdProducto.Value = ucInv_MenuReportes2.Get_info_producto() == null ? 0 : ucInv_MenuReportes2.Get_info_producto().IdProducto;
                    rpt.p_mostrar_valores_en_0.Value = Mostrar_valores_en_0;
                    rpt.p_mostrar_agrupado.Value = Mostrar_detallado;
                    rpt.RequestParameters = false;

                    ReportPrintTool pt = new ReportPrintTool(rpt);
                    printControl1.PrintingSystem = rpt.PrintingSystem;
                    splashScreenManager1.ShowWaitForm();
                    rpt.CreateDocument();
                    splashScreenManager1.CloseWaitForm();
                }
                
            }
             catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void ucInv_MenuReportes2_event_btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Log_Error_bus.Log_Error(ex.ToString());
                MessageBox.Show(ex.Message, param.Nombre_sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                splashScreenManager1.CloseWaitForm();
            }
        }

       
    }
}
