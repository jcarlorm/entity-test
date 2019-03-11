CREATE TABLE [dbo].[Bitacora] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [evento] VARCHAR (MAX) NOT NULL,
    [metodo] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED ([id] ASC)
);

