﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.Roles_Fj;
using Core.Erp.Info.Roles_Fj;
using Core.Erp.Info.General;
using Core.Erp.Data.General;
using Core.Erp.Info.General;
using Core.Erp.Business.General;
using Core.Erp.Business.Roles;
using Core.Erp.Info.Roles;

namespace Core.Erp.Business.Roles_Fj
{
  public  class ro_fectividad_Entrega_x_Periodo_Empleado_Bus
  {
      cl_parametrosGenerales_Bus param = cl_parametrosGenerales_Bus.Instance;

      ro_fectividad_Entrega_x_Periodo_Empleado_Data data = new ro_fectividad_Entrega_x_Periodo_Empleado_Data();
      ro_fectividad_Entrega_x_Periodo_Empleado_Det_Data data_detalle = new ro_fectividad_Entrega_x_Periodo_Empleado_Det_Data();
      ro_Grupo_empleado_det_Bus bus_grupo_detalle = new ro_Grupo_empleado_det_Bus();
      List<ro_Grupo_empleado_det_Info> lista_detalle_grupos = new List<ro_Grupo_empleado_det_Info>();
      ro_Empleado_Novedad_Bus bus_novedad = new ro_Empleado_Novedad_Bus();
      ro_Empleado_Novedad_Det_Bus novedad_detalle_bus = new ro_Empleado_Novedad_Det_Bus();
      ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
      ro_fectividad_Entrega_tipoServicio_Data ro_fectividad_Entrega_tipoServicio_Data = new ro_fectividad_Entrega_tipoServicio_Data();
      string mensaje;
      public bool Guardar_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info)
      {

          lista_detalle_grupos = bus_grupo_detalle.Get_lista(param.IdEmpresa);
          bool ba=false;
          int idefectividad = 0;
          decimal id_nov = 0;
          var ro_fectividad_Entrega_tipoServicio_info=ro_fectividad_Entrega_tipoServicio_Data.Get_Info(info.IdEmpresa,(int)info.IdServicioTipo);
          try
          {
              if (data.Guardar_DB(info, ref idefectividad))
              {
                 if (ro_fectividad_Entrega_tipoServicio_info.Genera_novedad==true)
                 foreach (var item in Get_Novedades(info.lista,Convert.ToInt32( info.IdServicioTipo)))
                  {
                   ba=  bus_novedad.GrabarDB(item, ref id_nov);
                  }
              }

              return true;
          }
          catch (Exception ex)
          {

              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }

      public bool Modificar_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info)
      {
          bool ba = false;
          decimal id_nov = 0;
          try
          {
              if (data.Modificar_DB(info))
              {
                  var ro_fectividad_Entrega_tipoServicio_info = ro_fectividad_Entrega_tipoServicio_Data.Get_Info(info.IdEmpresa, (int)info.IdServicioTipo);
                  if (ro_fectividad_Entrega_tipoServicio_info.Genera_novedad == true)
                    foreach (var item in Get_Novedades(info.lista, Convert.ToInt32(info.IdServicioTipo)))
                     {
                         info_detalle = novedad_detalle_bus.get_si_existe_novedad(item.IdEmpresa, item.IdEmpleado, item.IdRubro, item.IdCalendario);
                         if (info_detalle != null)
                         {
                             item.IdNovedad = info_detalle.IdNovedad;
                             ba = bus_novedad.ModificarDB(item);
                         }
                         else
                         {
                             ba = bus_novedad.GrabarDB(item, ref id_nov);
                         }
                     }
              }

              return ba;
          }
          catch (Exception ex)
          {

              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }

      public bool Anular_DB(ro_fectividad_Entrega_x_Periodo_Empleado_Info info)
      {
          try
          {
              if (info.IdServicioTipo == 1)
                  info.IdCalendario = info.IdPeriodo.ToString() + "VB";
              else
                  info.IdCalendario = info.IdPeriodo.ToString() + "VA";

              return data.Anular_DB(info);
          }
          catch (Exception ex)
          {

              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }

      public List<ro_fectividad_Entrega_x_Periodo_Empleado_Info> listado_Grupos(int IdEmpresa, DateTime Fecha_Inicio, DateTime Fecha_fin)
      {
          try
          {
              return data.get_list(IdEmpresa, Fecha_Inicio, Fecha_fin);
          }
          catch (Exception ex)
          {

              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);
          }
      }
      private List<ro_Empleado_Novedad_Info> Get_Novedades(List<ro_fectividad_Entrega_x_Periodo_Empleado_Det_Info> lista, int TipoServicio)
      {

          try
          {
              ro_fectividad_Entrega_tipoServicio_Data odata_servicio = new ro_fectividad_Entrega_tipoServicio_Data();

              var info_servicio = odata_servicio.Get_Info(param.IdEmpresa,TipoServicio);

              List<ro_Empleado_Novedad_Info> listado_novedades = new List<ro_Empleado_Novedad_Info>();
              ero_parametro_x_pago_variable_tipo tipo_variable = new ero_parametro_x_pago_variable_tipo();
              ro_Grupo_empleado_det_Info info_grupo_detalle = new ro_Grupo_empleado_det_Info();


              foreach (var item in lista)
              {
                 
                  #region SI LA VARIABLE ES VEVIDAS

                  if (info_servicio.ts_codigo == etipoServicio.BEBIDAS.ToString())
                  {
                  #region EFEC_ENTRE
                  if (item.Efectividad_Entrega_aplica > 0)
                  {
                      tipo_variable = ero_parametro_x_pago_variable_tipo.EFEC_ENTRE;
                      ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                      info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                      info_novedad.IdEmpresa = item.IdEmpresa;
                      info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                      info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                      info_novedad.IdEmpleado = item.IdEmpleado;
                      info_novedad.Fecha = item.fecha_Pago;
                      info_novedad.TotalValor = item.Efectividad_Entrega_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo;
                      info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                      info_novedad.NumCoutas = 1;
                      info_novedad.IdUsuario = param.IdUsuario;
                      info_novedad.Fecha_Transac = DateTime.Now;
                      info_novedad.Estado = "A";
                      info_novedad.IdCalendario = item.IdPeriodo + "VB";

                      // detalle de la novedad 

                      ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                      info_detalle.IdEmpresa = item.IdEmpresa;
                      info_detalle.IdEmpleado = item.IdEmpleado;
                      info_detalle.Secuencia = 1;
                      info_detalle.IdRol = null;
                      info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                      info_detalle.FechaPago = item.fecha_Pago;
                      info_detalle.Valor = (item.Efectividad_Entrega_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                      info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                      info_detalle.EstadoCobro = "PEN";
                      info_detalle.Estado = "A";
                      info_detalle.IdCalendario = item.IdPeriodo + "VB";
                      info_novedad.InfoNovedadDet = info_detalle;
                      info_novedad.LstDetalle.Add(info_detalle);
                      listado_novedades.Add(info_novedad);
                  }

                  #endregion
                  #region EFEC_ENTRE
                  if (item.Recuperacion_cartera_aplica > 0)
                  {
                      tipo_variable = ero_parametro_x_pago_variable_tipo.REC_CAR;
                      ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                      info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                      info_novedad.IdEmpresa = item.IdEmpresa;
                      info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                      info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                      info_novedad.IdEmpleado = item.IdEmpleado;
                      info_novedad.Fecha = item.fecha_Pago;
                      info_novedad.TotalValor = item.Recuperacion_cartera_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo;
                      info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                      info_novedad.NumCoutas = 1;
                      info_novedad.IdUsuario = param.IdUsuario;
                      info_novedad.Fecha_Transac = DateTime.Now;
                      info_novedad.Estado = "A";
                      info_novedad.IdCalendario = item.IdPeriodo.ToString() + "VB";


                      // detalle de la novedad 

                      ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                      info_detalle.IdEmpresa = item.IdEmpresa;
                      info_detalle.IdEmpleado = item.IdEmpleado;
                      info_detalle.Secuencia = 1;
                      info_detalle.IdRol = null;
                      info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                      info_detalle.FechaPago = item.fecha_Pago;
                      info_detalle.Valor = (item.Recuperacion_cartera_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                      info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                      info_detalle.EstadoCobro = "PEN";
                      info_detalle.Estado = "A";
                      info_detalle.IdCalendario = item.IdPeriodo.ToString() + "VB";
                      info_novedad.InfoNovedadDet = info_detalle;
                      info_novedad.LstDetalle.Add(info_detalle); 
                      listado_novedades.Add(info_novedad);
                  }

                  #endregion
                  #region EFEC_VOL
                  if (item.Efectividad_Volumen_aplica > 0)
                  {
                      tipo_variable = ero_parametro_x_pago_variable_tipo.EFEC_VOL;
                      ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                      info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                      info_novedad.IdEmpresa = item.IdEmpresa;
                      info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                      info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                      info_novedad.IdEmpleado = item.IdEmpleado;
                      info_novedad.Fecha = item.fecha_Pago;
                      info_novedad.TotalValor = item.Efectividad_Volumen_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo; ;
                      info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                      info_novedad.NumCoutas = 1;
                      info_novedad.IdUsuario = param.IdUsuario;
                      info_novedad.Fecha_Transac = DateTime.Now;
                      info_novedad.Estado = "A";
                      info_novedad.IdCalendario = item.IdPeriodo.ToString() + "VB";


                      // detalle de la novedad 

                      ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                      info_detalle.IdEmpresa = item.IdEmpresa;
                      info_detalle.IdEmpleado = item.IdEmpleado;
                      info_detalle.Secuencia = 1;
                      info_detalle.IdRol = null;
                      info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                      info_detalle.FechaPago = item.fecha_Pago;
                      info_detalle.Valor = (item.Efectividad_Volumen_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                      info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                      info_detalle.EstadoCobro = "PEN";
                      info_detalle.Estado = "A";
                      info_detalle.IdCalendario = item.IdPeriodo.ToString() + "VB";
                      info_novedad.InfoNovedadDet = info_detalle;
                      info_novedad.LstDetalle.Add(info_detalle); 
                      listado_novedades.Add(info_novedad);
                  }

                  #endregion
                  }
                  
                  #endregion


                  #region SI LA VARIABLE ES ALIMENTOS

                  if (info_servicio.ts_codigo == etipoServicio.ALIMENTOS.ToString())
                  {
                      #region EFEC_ENTRE
                      if (item.Efectividad_Entrega_aplica > 0)
                      {
                          tipo_variable = ero_parametro_x_pago_variable_tipo.EFEC_ENTRE_ALIM;
                          ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                          info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                          info_novedad.IdEmpresa = item.IdEmpresa;
                          info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                          info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                          info_novedad.IdEmpleado = item.IdEmpleado;
                          info_novedad.Fecha = item.fecha_Pago;
                          if (item.Efectividad_Entrega_aplica <= 1)
                              info_novedad.TotalValor = (item.Efectividad_Entrega_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                          else
                              info_novedad.TotalValor = item.Efectividad_Entrega_aplica;
                          info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                          info_novedad.NumCoutas = 1;
                          info_novedad.IdUsuario = param.IdUsuario;
                          info_novedad.Fecha_Transac = DateTime.Now;
                          info_novedad.Estado = "A";
                          info_novedad.IdCalendario = item.IdPeriodo + "VA";

                          // detalle de la novedad 

                          ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                          info_detalle.IdEmpresa = item.IdEmpresa;
                          info_detalle.IdEmpleado = item.IdEmpleado;
                          info_detalle.Secuencia = 1;
                          info_detalle.IdRol = null;
                          info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                          info_detalle.FechaPago = item.fecha_Pago;
                          if (item.Efectividad_Entrega_aplica <= 1)
                          info_detalle.Valor = (item.Efectividad_Entrega_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                          else
                              info_detalle.Valor = item.Efectividad_Entrega_aplica;
                          info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                          info_detalle.EstadoCobro = "PEN";
                          info_detalle.Estado = "A";
                          info_detalle.IdCalendario = item.IdPeriodo + "VA";
                          info_novedad.InfoNovedadDet = info_detalle;
                          info_novedad.LstDetalle.Add(info_detalle);

                          listado_novedades.Add(info_novedad);
                      }

                      #endregion
                      #region EFEC_ENTRE
                      if (item.Recuperacion_cartera_aplica > 0)
                      {
                          tipo_variable = ero_parametro_x_pago_variable_tipo.REC_CAR_ALIM;
                          ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                          info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                          info_novedad.IdEmpresa = item.IdEmpresa;
                          info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                          info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                          info_novedad.IdEmpleado = item.IdEmpleado;
                          info_novedad.Fecha = item.fecha_Pago;
                          if (item.Recuperacion_cartera_aplica <= 1)
                              info_novedad.TotalValor = item.Recuperacion_cartera_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo;
                          else
                              info_novedad.TotalValor = item.Recuperacion_cartera_aplica;
                          info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                          info_novedad.NumCoutas = 1;
                          info_novedad.IdUsuario = param.IdUsuario;
                          info_novedad.Fecha_Transac = DateTime.Now;
                          info_novedad.Estado = "A";
                          info_novedad.IdCalendario = item.IdPeriodo.ToString() + "VA";


                          // detalle de la novedad 

                          ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                          info_detalle.IdEmpresa = item.IdEmpresa;
                          info_detalle.IdEmpleado = item.IdEmpleado;
                          info_detalle.Secuencia = 1;
                          info_detalle.IdRol = null;
                          info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                          info_detalle.FechaPago = item.fecha_Pago;
                          if (item.Recuperacion_cartera_aplica <= 1)
                              info_detalle.Valor = (item.Recuperacion_cartera_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                          else
                              info_detalle.Valor = item.Recuperacion_cartera_aplica;
                          info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                          info_detalle.EstadoCobro = "PEN";
                          info_detalle.Estado = "A";
                          info_detalle.IdCalendario = item.IdPeriodo.ToString() + "VA";
                          info_novedad.InfoNovedadDet = info_detalle;
                          info_novedad.LstDetalle.Add(info_detalle);
                          listado_novedades.Add(info_novedad);
                      }

                      #endregion
                      #region EFEC_VOL
                      if (item.Efectividad_Volumen > 0)
                      {
                          tipo_variable = ero_parametro_x_pago_variable_tipo.EFEC_VOL_ALIM;
                          ro_Empleado_Novedad_Info info_novedad = new ro_Empleado_Novedad_Info();
                          info_grupo_detalle = lista_detalle_grupos.Where(v => v.cod_Pago_Variable_enum == tipo_variable && v.IdGrupo == item.IdGrupo).FirstOrDefault();

                          info_novedad.IdEmpresa = item.IdEmpresa;
                          info_novedad.IdNomina_Tipo = item.IdNomina_Tipo;
                          info_novedad.IdNomina_TipoLiqui = item.IdNomina_tipo_Liq;
                          info_novedad.IdEmpleado = item.IdEmpleado;
                          info_novedad.Fecha = item.fecha_Pago;
                          if (item.Efectividad_Volumen_aplica <= 1)
                              info_novedad.TotalValor = (item.Efectividad_Volumen_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                          else
                              info_novedad.TotalValor = item.Efectividad_Volumen_aplica;
                          info_novedad.Fecha_PrimerPago = item.fecha_Pago;
                          info_novedad.NumCoutas = 1;
                          info_novedad.IdUsuario = param.IdUsuario;
                          info_novedad.Fecha_Transac = DateTime.Now;
                          info_novedad.Estado = "A";
                          info_novedad.IdCalendario = item.IdPeriodo.ToString() + "VA";


                          // detalle de la novedad 

                          ro_Empleado_Novedad_Det_Info info_detalle = new ro_Empleado_Novedad_Det_Info();
                          info_detalle.IdEmpresa = item.IdEmpresa;
                          info_detalle.IdEmpleado = item.IdEmpleado;
                          info_detalle.Secuencia = 1;
                          info_detalle.IdRol = null;
                          info_detalle.IdRubro = info_grupo_detalle.IdRubro;
                          info_detalle.FechaPago = item.fecha_Pago;
                          if (item.Efectividad_Volumen_aplica <= 1)
                              info_detalle.Valor = (item.Efectividad_Volumen_aplica * info_grupo_detalle.Valor_bono * info_grupo_detalle.Porcentaje_calculo) * info_servicio.Porcentaje;
                          else
                              info_detalle.Valor = item.Efectividad_Volumen_aplica;
                          info_detalle.Observacion = "Novedad generada por procesos del sistema del periodo " + item.IdPeriodo;
                          info_detalle.EstadoCobro = "PEN";
                          info_detalle.Estado = "A";
                          info_detalle.IdCalendario = item.IdPeriodo.ToString() + "VA";
                          info_novedad.InfoNovedadDet = info_detalle;
                          info_novedad.LstDetalle.Add(info_detalle); 
                          listado_novedades.Add(info_novedad);
                      }

                      #endregion
                  }

                  #endregion
                 
              }

              return listado_novedades;



          }
          catch (Exception ex)
          {
              mensaje = ex.ToString();
              tb_sis_Log_Error_Vzen_Data oDataLog = new tb_sis_Log_Error_Vzen_Data();
              tb_sis_Log_Error_Vzen_Info Log_Error_sis = new tb_sis_Log_Error_Vzen_Info(ex.ToString(), "", mensaje, "", "", "", "", "", DateTime.Now);
              oDataLog.Guardar_Log_Error(Log_Error_sis, ref mensaje);
              throw new Exception(mensaje);

          }
      }

    }
}
