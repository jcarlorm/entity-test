CREATE TABLE [dbo].[transPerfilRegla] (
    [IdPerfil] INT NOT NULL,
    [IdRegla]  INT NOT NULL,
    CONSTRAINT [PK_transPerfilRegla] PRIMARY KEY CLUSTERED ([IdPerfil] ASC, [IdRegla] ASC)
);

