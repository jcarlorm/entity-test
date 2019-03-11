CREATE PROCEDURE [dbo].[ObtenerFactura] 
@idFactura as int
AS
BEGIN
    SET NOCOUNT ON;
select idFactura, idRevisión, idOrden, idCliente, idUsuario, descripción, descuento, impuesto, 
   subtotal, total, tipoPago, fecha, estado, exonerado, condicionVenta from dbo.Factura where idFactura  = @idFactura
          
END