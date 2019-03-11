CREATE TABLE [dbo].[Factura_Electronica] (
    [id]           INT  IDENTITY (1, 1) NOT NULL,
    [factura_id]   INT  NOT NULL,
    [clave]        TEXT NULL,
    [consecutivo]  TEXT NULL,
    [xml]          TEXT NULL,
    [xmlfirmado]   TEXT NULL,
    [xmlrespuesta] TEXT NULL,
    [estado]       TEXT NULL,
    [documento_id] INT  NOT NULL,
    [fecha]        TEXT NULL,
    CONSTRAINT [PK_Factura_Electronica] PRIMARY KEY CLUSTERED ([id] ASC)
);

