﻿CREATE TABLE [dbo].[ro_rubros_calculados] (
    [IdEmpresa]                 INT          NOT NULL,
    [IdRubro_dias_trabajados]   VARCHAR (50) NOT NULL,
    [IdRubro_tot_ing]           VARCHAR (50) NOT NULL,
    [IdRubro_tot_egr]           VARCHAR (50) NOT NULL,
    [IdRubro_iess_perso]        VARCHAR (50) NOT NULL,
    [IdRubro_sueldo]            VARCHAR (50) NOT NULL,
    [IdRubro_tot_pagar]         VARCHAR (50) NOT NULL,
    [IdRubro_aporte_patronal]   VARCHAR (50) NOT NULL,
    [IdRubro_fondo_reserva]     VARCHAR (50) NOT NULL,
    [IdRubro_prov_vac]          VARCHAR (50) NOT NULL,
    [IdRubro_prov_DIII]         VARCHAR (50) NOT NULL,
    [IdRubro_prov_DIV]          VARCHAR (50) NOT NULL,
    [IdRubro_prov_FR]           VARCHAR (50) NOT NULL,
    [IdRubro_DIII]              VARCHAR (50) NOT NULL,
    [IdRubro_DIV]               VARCHAR (50) NOT NULL,
    [IdRubro_IR]                VARCHAR (50) NULL,
    [IdRubro_anticipo]          VARCHAR (50) NULL,
    [IdRubro_alimentacion]      VARCHAR (50) NULL,
    [IdRubro_transporte]        VARCHAR (50) NULL,
    [IdRubro_otros_ingresos]    VARCHAR (50) NULL,
    [IdRubro_horas_extras]      VARCHAR (50) NULL,
    [IdRubro_otros_descuentos]  VARCHAR (50) NULL,
    [IdRubro_dias_efectivos]    VARCHAR (50) NULL,
    [IdRubro_subtotal_variable] VARCHAR (50) NULL,
    [IdRubro_descuento_permiso] VARCHAR (50) NULL,
    [IdRubro_alm_car]           VARCHAR (50) NULL,
    [IdRubro_alm_vol]           VARCHAR (50) NULL,
    [IdRubro_alm_ent]           VARCHAR (50) NULL,
    [IdRubro_beb_car]           VARCHAR (50) NULL,
    [IdRubro_beb_vol]           VARCHAR (50) NULL,
    [IdRubro_beb_ent]           VARCHAR (50) NULL,
    [IdRubro_servicio]          VARCHAR (50) NULL,
    CONSTRAINT [PK_ro_rubros_calculados] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC)
);



