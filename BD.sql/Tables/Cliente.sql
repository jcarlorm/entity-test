CREATE TABLE [dbo].[Cliente] (
    [idCliente]  INT           NOT NULL,
    [nombre]     VARCHAR (MAX) NULL,
    [apellido]   VARCHAR (MAX) NULL,
    [telefono1]  VARCHAR (20)  NULL,
    [tipoCedula] INT           CONSTRAINT [DF_Cliente_tipoCedula] DEFAULT ((1)) NOT NULL,
    [cedula]     VARCHAR (20)  NULL,
    [dirección]  VARCHAR (MAX) NULL,
    [correo]     VARCHAR (MAX) NULL,
    [estado]     INT           CONSTRAINT [DF_Cliente_estado_1] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([idCliente] ASC)
);

