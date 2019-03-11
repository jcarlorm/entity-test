
CREATE PROCEDURE [dbo].[ListaFacturas]
     
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 
select idFactura, idRevisión, idOrden, idCliente, idUsuario, descripción, descuento, impuesto, 
   subtotal, total, tipoPago, fecha, estado, exonerado, condicionVenta from dbo.Factura 
END