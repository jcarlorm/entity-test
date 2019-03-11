CREATE proc [dbo].[EliminarFactura]
@idFactura as int
AS
BEGIN
DELETE Factura 
 where idFactura= @idFactura
END