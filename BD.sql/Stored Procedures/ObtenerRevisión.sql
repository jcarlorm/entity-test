CREATE PROCEDURE [dbo].[ObtenerRevisión]	
@idRevisión as integer
AS
BEGIN
	SET NOCOUNT ON;
   select idRevision, idCoche, idUsuario, idCliente, descripción, total,
   tipoCategoria, categoria, precio, fechaInicio, estado from dbo.Revision where idRevision  = @idRevisión
         
END