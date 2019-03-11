CREATE TABLE [dbo].[Coches] (
    [idCoche]     INT           NOT NULL,
    [placa]       VARCHAR (20)  NOT NULL,
    [marca]       VARCHAR (20)  NOT NULL,
    [modelo]      VARCHAR (20)  NOT NULL,
    [cilindrada]  INT           NOT NULL,
    [año]         INT           NOT NULL,
    [combustible] INT           NOT NULL,
    [transmision] INT           NOT NULL,
    [capacidad]   INT           NOT NULL,
    [vin]         VARCHAR (50)  NOT NULL,
    [detalle]     VARCHAR (MAX) NOT NULL,
    [idCliente]   INT           NOT NULL,
    [estado]      INT           CONSTRAINT [DF_Coches_estado] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Coches] PRIMARY KEY CLUSTERED ([idCoche] ASC)
);

