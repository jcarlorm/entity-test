CREATE TABLE [dbo].[Categorias] (
    [idCategoría]   INT           NOT NULL,
    [tipoCategoría] INT           NOT NULL,
    [descripción]   VARCHAR (MAX) NOT NULL,
    [costo]         FLOAT (53)    NOT NULL,
    [abreviación]   VARCHAR (MAX) NOT NULL,
    [estado]        INT           NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([idCategoría] ASC)
);

