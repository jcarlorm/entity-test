CREATE TABLE [dbo].[Factura] (
    [idFactura]      INT           NOT NULL,
    [idRevisión]     INT           NOT NULL,
    [idOrden]        INT           NOT NULL,
    [idCliente]      INT           NOT NULL,
    [idUsuario]      INT           NOT NULL,
    [descripción]    VARCHAR (MAX) NOT NULL,
    [descuento]      INT           NOT NULL,
    [impuesto]       FLOAT (53)    NOT NULL,
    [subtotal]       FLOAT (53)    NOT NULL,
    [total]          FLOAT (53)    NOT NULL,
    [tipoPago]       VARCHAR (MAX) NOT NULL,
    [fecha]          DATETIME      NOT NULL,
    [estado]         INT           NOT NULL,
    [exonerado]      INT           CONSTRAINT [DF_Factura_condicionventa] DEFAULT ((1)) NOT NULL,
    [condicionVenta] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK__Factura__3CD5687E3A81B327] PRIMARY KEY CLUSTERED ([idFactura] ASC)
);

