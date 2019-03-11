CREATE TABLE [dbo].[Revision] (
    [idRevision]    INT           NOT NULL,
    [idCoche]       INT           NOT NULL,
    [idUsuario]     INT           NOT NULL,
    [idCliente]     INT           NOT NULL,
    [descripción]   VARCHAR (MAX) NULL,
    [total]         FLOAT (53)    NOT NULL,
    [tipoCategoria] VARCHAR (MAX) NULL,
    [categoria]     VARCHAR (MAX) NULL,
    [precio]        VARCHAR (MAX) NULL,
    [fechaInicio]   DATETIME      NOT NULL,
    [estado]        INT           NOT NULL,
    CONSTRAINT [PK_Revision2] PRIMARY KEY CLUSTERED ([idRevision] ASC)
);

