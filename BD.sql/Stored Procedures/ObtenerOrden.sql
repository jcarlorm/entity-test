CREATE PROCEDURE [dbo].[ObtenerOrden]    
@idOrden as integer
AS
BEGIN
    SET NOCOUNT ON;
   select  idOrden, idRevision,idCoche, idUsuario, idCliente, descripción, 
   total, tipoCategoria, categoria, precio, fechaInicio, estado, descuento from dbo.Orden where idOrden  = @idOrden
          
END