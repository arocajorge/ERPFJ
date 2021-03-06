﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Info.General;
using Core.Erp.Data.General;
namespace Core.Erp.Data.Roles_Fj
{
  public  class ro_Parametro_calculo_Horas_Extras_Data
  {
      string MensajeError = "";
      tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
      public bool GuardarDB(ro_Parametro_calculo_Horas_Extras_Info info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {

                  var query = from q in db.ro_Parametro_calculo_Horas_Extras
                              where
                              q.IdEmpresa == info.IdEmpresa

                              select q;
                  if (query.Count() == 0)
                  {
                      ro_Parametro_calculo_Horas_Extras add = new ro_Parametro_calculo_Horas_Extras();
                      add.IdEmpresa = info.IdEmpresa;
                      add.Se_calcula_horas_Extras_al100 = info.Se_calcula_horas_Extras_al100;
                      add.Se_calcula_horas_Extras_al50 = info.Se_calcula_horas_Extras_al50;
                      add.Se_calcula_horas_Extras_al25 = info.Se_calcula_horas_Extras_al25;
                      add.Corte_Horas_extras = info.Corte_Horas_extras;
                      add.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo = info.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo;
                      add.IdRubro_rev_Horas = info.IdRubro_rev_Horas;
                      add.IdRubro_Rebaja_Desahucio = info.IdRubro_Rebaja_Desahucio;
                      add.MinutosLunch = info.MinutosLunch;
                      add.considera_fecha_corte_dias_efectivo = info.considera_fecha_corte_dias_efectivo;
                      add.solo_graba_dias_efectivos = info.solo_graba_dias_efectivos;
                      add.dias_integrales=info.dias_integrales;
                      db.ro_Parametro_calculo_Horas_Extras.Add(add);
                      db.SaveChanges();
                  }
                  else
                  {
                      ModificarDB(info);
                  }
                  return true;
              }
          }
          catch (Exception ex)
          {

              string arreglo = ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
              MensajeError = ex.ToString();
              throw new Exception(ex.ToString());
          }
      }


      public bool ModificarDB(ro_Parametro_calculo_Horas_Extras_Info info)
      {
          try
          {
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var modific = db.ro_Parametro_calculo_Horas_Extras.FirstOrDefault(v => v.IdEmpresa == info.IdEmpresa);
                  modific.Se_calcula_horas_Extras_al100 = info.Se_calcula_horas_Extras_al100;
                  modific.Se_calcula_horas_Extras_al50 = info.Se_calcula_horas_Extras_al50;
                  modific.Se_calcula_horas_Extras_al25 = info.Se_calcula_horas_Extras_al25;
                  modific.Corte_Horas_extras = info.Corte_Horas_extras;
                  modific.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo = info.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo;
                  modific.IdRubro_rev_Horas = info.IdRubro_rev_Horas;
                  modific.IdRubro_Rebaja_Desahucio = info.IdRubro_Rebaja_Desahucio;
                  modific.considera_fecha_corte_dias_efectivo = info.considera_fecha_corte_dias_efectivo;
                  modific.solo_graba_dias_efectivos = info.solo_graba_dias_efectivos;
                  modific.dias_integrales = info.dias_integrales;
                  modific.MinutosLunch = info.MinutosLunch;
                  db.SaveChanges();
                  return true;
              }
          }
          catch (Exception ex)
          {

              string arreglo = ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
              MensajeError = ex.ToString();
              throw new Exception(ex.ToString());
          }
      }

      public ro_Parametro_calculo_Horas_Extras_Info Get_info(int IdEmpresa)
      {
          try
          {
              ro_Parametro_calculo_Horas_Extras_Info info = new ro_Parametro_calculo_Horas_Extras_Info();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.ro_Parametro_calculo_Horas_Extras
                              where
                              q.IdEmpresa == IdEmpresa

                              select q;


                  foreach (var item in query)
                  {
                      info.IdEmpresa = item.IdEmpresa;
                      info.Se_calcula_horas_Extras_al100 = item.Se_calcula_horas_Extras_al100;
                      info.Se_calcula_horas_Extras_al25 = item.Se_calcula_horas_Extras_al25;
                      info.Se_calcula_horas_Extras_al50 = item.Se_calcula_horas_Extras_al50;
                      info.Corte_Horas_extras = item.Corte_Horas_extras;
                      info.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo = item.Se_Crea_reverso_h_extras_si_Emp_tiene_remplazo;
                      info.IdRubro_rev_Horas = item.IdRubro_rev_Horas;
                      info.IdRubro_Rebaja_Desahucio = item.IdRubro_Rebaja_Desahucio;
                      info.MinutosLunch = item.MinutosLunch;
                      info.considera_fecha_corte_dias_efectivo = item.considera_fecha_corte_dias_efectivo;
                      info.solo_graba_dias_efectivos = item.solo_graba_dias_efectivos;
                      info.dias_integrales = item.dias_integrales;
                  }

                  return info;
              }
          }
          catch (Exception ex)
          {

              string arreglo = ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
              MensajeError = ex.ToString();
              throw new Exception(ex.ToString());
          }

      }


      public bool Considera_fecha_corte_dias_efectivos(int IdEmpresa)
      {
          try
          {

              bool valo=false;
              ro_Parametro_calculo_Horas_Extras_Info info = new ro_Parametro_calculo_Horas_Extras_Info();
              using (EntityRoles_FJ db = new EntityRoles_FJ())
              {
                  var query = from q in db.ro_Parametro_calculo_Horas_Extras
                              where
                              q.IdEmpresa == IdEmpresa
                              select q;


                  foreach (var item in query)
                  {
                      if (item.considera_fecha_corte_dias_efectivo == true)
                          valo = true;
                      else
                          valo = false;

                  }

                  return valo;
              }
          }
          catch (Exception ex)
          {

              string arreglo = ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", arreglo, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref MensajeError);
              MensajeError = ex.ToString();
              throw new Exception(ex.ToString());
          }

      }
  


    }
}
