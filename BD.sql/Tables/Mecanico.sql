CREATE TABLE [dbo].[Mecanico] (
    [idMecanico] INT          NOT NULL,
    [nombre]     VARCHAR (20) NOT NULL,
    [apellido]   VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Mecanico] PRIMARY KEY CLUSTERED ([idMecanico] ASC)
);

