﻿CREATE TABLE [dbo].[caj_Caja_Movimiento_Tipo] (
    [IdTipoMovi]       INT           NOT NULL,
    [tm_descripcion]   VARCHAR (200) NOT NULL,
    [Estado]           CHAR (1)      NOT NULL,
    [tm_Signo]         NCHAR (1)     NOT NULL,
    [IdUsuario]        VARCHAR (20)  NULL,
    [Fecha_Transac]    DATETIME      NULL,
    [IdUsuarioUltMod]  VARCHAR (20)  NULL,
    [Fecha_UltMod]     DATETIME      NULL,
    [IdUsuarioUltAnu]  VARCHAR (20)  NULL,
    [Fecha_UltAnu]     DATETIME      NULL,
    [nom_pc]           VARCHAR (50)  NULL,
    [ip]               VARCHAR (25)  NULL,
    [MotivoAnulacion]  VARCHAR (200) NULL,
    [SeDeposita]       BIT           NOT NULL,
    [IdEmpresa]        INT           NULL,
    [IdTipoMovi_grupo] INT           NULL,
    CONSTRAINT [PK_ba_Caja_TipoMovimiento] PRIMARY KEY CLUSTERED ([IdTipoMovi] ASC),
    CONSTRAINT [FK_caj_Caja_Movimiento_Tipo_caj_Caja_Movimiento_Tipo_grupo] FOREIGN KEY ([IdTipoMovi_grupo]) REFERENCES [dbo].[caj_Caja_Movimiento_Tipo_grupo] ([IdTipoMovi_grupo])
);

