CREATE TABLE [dbo].[Usuarios] (
    [idUsuario]  INT          NOT NULL,
    [nombre]     VARCHAR (50) NOT NULL,
    [apellido]   VARCHAR (50) NOT NULL,
    [estado]     INT          CONSTRAINT [DF_Usuarios_status] DEFAULT ((1)) NOT NULL,
    [contraseña] VARCHAR (50) NOT NULL,
    [IdPerfil]   INT          NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([idUsuario] ASC)
);

