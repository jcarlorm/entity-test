CREATE TABLE [dbo].[tipoCategorias] (
    [idTipoCategoria] INT           NOT NULL,
    [descripcion]     VARCHAR (MAX) NOT NULL,
    [estado]          INT           NOT NULL,
    [tipoServicio]    INT           NOT NULL,
    CONSTRAINT [PK_TipoCategorias] PRIMARY KEY CLUSTERED ([idTipoCategoria] ASC)
);

