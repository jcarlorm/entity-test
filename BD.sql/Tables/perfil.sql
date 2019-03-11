CREATE TABLE [dbo].[perfil] (
    [IdPerfil]    INT           NOT NULL,
    [Perfil]      VARCHAR (50)  NOT NULL,
    [Descripción] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_tblPerfil] PRIMARY KEY CLUSTERED ([IdPerfil] ASC)
);

