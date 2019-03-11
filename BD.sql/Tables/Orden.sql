CREATE TABLE [dbo].[Orden] (
    [idOrden]       INT           NOT NULL,
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
    [descuento]     INT           NULL,
    CONSTRAINT [PK_Orden2] PRIMARY KEY CLUSTERED ([idOrden] ASC)
);

