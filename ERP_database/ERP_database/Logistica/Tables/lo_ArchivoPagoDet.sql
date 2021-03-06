﻿CREATE TABLE [Logistica].[lo_ArchivoPagoDet] (
    [IdArchivoDet] INT             IDENTITY (1, 1) NOT NULL,
    [IdArchivo]    INT             NOT NULL,
    [IdNovedad]    INT             NOT NULL,
    [IdChofer]     INT             NOT NULL,
    [Valor]        NUMERIC (18, 2) NOT NULL,
    CONSTRAINT [PK_lo_ArchivoPagoDet] PRIMARY KEY CLUSTERED ([IdArchivoDet] ASC),
    CONSTRAINT [FK_lo_ArchivoPagoDet_lo_ArchivoPago] FOREIGN KEY ([IdArchivo]) REFERENCES [Logistica].[lo_ArchivoPago] ([IdArchivo]),
    CONSTRAINT [FK_lo_ArchivoPagoDet_lo_chofer] FOREIGN KEY ([IdChofer]) REFERENCES [Logistica].[lo_chofer] ([IdChofer]),
    CONSTRAINT [FK_lo_ArchivoPagoDet_lo_novedad] FOREIGN KEY ([IdNovedad]) REFERENCES [Logistica].[lo_novedad] ([IdNovedad])
);







