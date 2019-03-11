CREATE TABLE [dbo].[regla] (
    [IdRegla]     INT            NOT NULL,
    [Regla]       VARCHAR (150)  NOT NULL,
    [Descripción] VARCHAR (1500) NULL,
    CONSTRAINT [PK_tblRegla] PRIMARY KEY CLUSTERED ([IdRegla] ASC)
);

