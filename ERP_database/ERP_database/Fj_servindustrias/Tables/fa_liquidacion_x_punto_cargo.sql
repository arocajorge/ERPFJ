﻿CREATE TABLE [Fj_servindustrias].[fa_liquidacion_x_punto_cargo] (
    [IdEmpresa]                      INT           NOT NULL,
    [IdSucursal]                     INT           NOT NULL,
    [IdCentroCosto]                  VARCHAR (20)  NOT NULL,
    [IdLiquidacion]                  NUMERIC (18)  NOT NULL,
    [IdPunto_cargo]                  INT           NOT NULL,
    [li_fecha]                       DATETIME      NOT NULL,
    [IdTerminoPago]                  VARCHAR (20)  NOT NULL,
    [IdCentroCosto_sub_centro_costo] VARCHAR (20)  NOT NULL,
    [li_reporte_mantenimiento]       VARCHAR (500) NULL,
    [li_num_orden]                   VARCHAR (50)  NULL,
    [li_num_horas]                   VARCHAR (50)  NULL,
    [li_atencion_a]                  VARCHAR (500) NULL,
    [IdBodega]                       INT           NULL,
    [li_tipo_pedido]                 VARCHAR (200) NULL,
    [estado]                         BIT           NOT NULL,
    [lo_IdProducto]                  NUMERIC (18)  NULL,
    [in_IdProducto]                  NUMERIC (18)  NULL,
    [eg_IdProducto]                  NUMERIC (18)  NULL,
    [li_por_iva]                     FLOAT (53)    NOT NULL,
    [li_subtotal]                    FLOAT (53)    NOT NULL,
    [li_valor_iva]                   FLOAT (53)    NOT NULL,
    [li_total]                       FLOAT (53)    NOT NULL,
    [IdCod_Impuesto]                 VARCHAR (25)  NULL,
    [li_observacion]                 VARCHAR (500) NULL,
    [li_fecha_orden_mantenimiento]   DATETIME      NULL,
    [li_fecha_reporte_mantenimiento] DATETIME      NULL,
    [li_referencia_facturas]         VARCHAR (500) NULL,
    CONSTRAINT [PK_fa_liquidacion_x_punto_cargo] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdSucursal] ASC, [IdCentroCosto] ASC, [IdLiquidacion] ASC),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_ct_centro_costo] FOREIGN KEY ([IdEmpresa], [IdCentroCosto]) REFERENCES [dbo].[ct_centro_costo] ([IdEmpresa], [IdCentroCosto]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_ct_centro_costo_sub_centro_costo] FOREIGN KEY ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]) REFERENCES [dbo].[ct_centro_costo_sub_centro_costo] ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_ct_punto_cargo] FOREIGN KEY ([IdEmpresa], [IdPunto_cargo]) REFERENCES [dbo].[ct_punto_cargo] ([IdEmpresa], [IdPunto_cargo]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_fa_TerminoPago] FOREIGN KEY ([IdTerminoPago]) REFERENCES [dbo].[fa_TerminoPago] ([IdTerminoPago]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_in_Producto1] FOREIGN KEY ([IdEmpresa], [lo_IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_tb_bodega] FOREIGN KEY ([IdEmpresa], [IdSucursal], [IdBodega]) REFERENCES [dbo].[tb_bodega] ([IdEmpresa], [IdSucursal], [IdBodega]),
    CONSTRAINT [FK_fa_liquidacion_x_punto_cargo_tb_sis_Impuesto] FOREIGN KEY ([IdCod_Impuesto]) REFERENCES [dbo].[tb_sis_Impuesto] ([IdCod_Impuesto])
);















