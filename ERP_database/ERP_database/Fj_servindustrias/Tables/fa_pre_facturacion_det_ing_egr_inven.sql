﻿CREATE TABLE [Fj_servindustrias].[fa_pre_facturacion_det_ing_egr_inven] (
    [IdEmpresa]                      INT          NOT NULL,
    [IdPreFacturacion]               NUMERIC (18) NOT NULL,
    [Secuencia]                      INT          NOT NULL,
    [eg_IdEmpresa]                   INT          NULL,
    [eg_IdSucursal]                  INT          NULL,
    [eg_IdMovi_inven_tipo]           INT          NULL,
    [eg_IdNumMovi]                   NUMERIC (18) NULL,
    [eg_Secuencia]                   INT          NULL,
    [eg_cantidad]                    FLOAT (53)   NULL,
    [eg_fecha]                       DATETIME     NULL,
    [eg_codigo]                      VARCHAR (50) NULL,
    [in_IdEmpresa]                   INT          NULL,
    [in_IdSucursal]                  INT          NULL,
    [in_IdMovi_inven_tipo]           INT          NULL,
    [in_IdNumMovi]                   NUMERIC (18) NULL,
    [in_Secuencia]                   INT          NULL,
    [in_cantidad]                    FLOAT (53)   NULL,
    [IdProveedor]                    NUMERIC (18) NULL,
    [cp_fecha]                       DATETIME     NULL,
    [cp_numero]                      VARCHAR (40) NULL,
    [IdActivoFijo]                   INT          NOT NULL,
    [costo_uni]                      FLOAT (53)   NOT NULL,
    [subtotal]                       FLOAT (53)   NOT NULL,
    [IdProducto]                     NUMERIC (18) NOT NULL,
    [IdCentroCosto]                  VARCHAR (20) NULL,
    [IdCentroCosto_sub_centro_costo] VARCHAR (20) NULL,
    CONSTRAINT [PK_fa_pre_facturacion_det_ing_egr_inven] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdPreFacturacion] ASC, [Secuencia] ASC),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_Af_Activo_fijo] FOREIGN KEY ([IdEmpresa], [IdActivoFijo]) REFERENCES [dbo].[Af_Activo_fijo] ([IdEmpresa], [IdActivoFijo]),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_cp_proveedor] FOREIGN KEY ([IdEmpresa], [IdProveedor]) REFERENCES [dbo].[cp_proveedor] ([IdEmpresa], [IdProveedor]),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_ct_centro_costo] FOREIGN KEY ([IdEmpresa], [IdCentroCosto]) REFERENCES [dbo].[ct_centro_costo] ([IdEmpresa], [IdCentroCosto]),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_ct_centro_costo_sub_centro_costo] FOREIGN KEY ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]) REFERENCES [dbo].[ct_centro_costo_sub_centro_costo] ([IdEmpresa], [IdCentroCosto], [IdCentroCosto_sub_centro_costo]),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_fa_pre_facturacion] FOREIGN KEY ([IdEmpresa], [IdPreFacturacion]) REFERENCES [Fj_servindustrias].[fa_pre_facturacion] ([IdEmpresa], [IdPreFacturacion]),
    CONSTRAINT [FK_fa_pre_facturacion_det_ing_egr_inven_in_Producto] FOREIGN KEY ([IdEmpresa], [IdProducto]) REFERENCES [dbo].[in_Producto] ([IdEmpresa], [IdProducto])
);













