﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cus.Erp.Reports.FJ.Roles
{
    public class XROLES_Rpt022_Data
    {
        public List<XROLES_Rpt022_Info> get_list(int IdEmpresa, int IdNomina_tipo)
        {
            try
            {
                List<XROLES_Rpt022_Info> Lista = new List<XROLES_Rpt022_Info>();

                using (Entities_Roles_Fj_Rpt Context = new Entities_Roles_Fj_Rpt())
                {
                    Lista = (from q in Context.vwROLES_Rpt022
                             where q.IdEmpresa == IdEmpresa
                             && q.IdTipoNomina == IdNomina_tipo
                             //&& q.IdEmpleado == IdEmpleado
                             //&& q.IdDescuento == IdDescuento
                             select new XROLES_Rpt022_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdEmpleado = q.IdEmpleado,
                                 IdTipoNomina = q.IdTipoNomina,
                                 pe_cedulaRuc = q.pe_cedulaRuc,
                                 pe_apellido = q.pe_apellido,
                                 pe_nombre = q.pe_nombre,
                                 ca_descripcion = q.ca_descripcion,
                                 de_descripcion = q.de_descripcion,
                                 Descripcion = q.Descripcion,
                                 em_codigo = q.em_codigo,
                                 em_fecha_ingreso = q.em_fecha_ingreso,
                                 em_fechaIngaRol = q.em_fechaIngaRol,
                                 em_foto = q.em_foto,
                                 pe_fechaNacimiento=q.pe_fechaNacimiento
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}