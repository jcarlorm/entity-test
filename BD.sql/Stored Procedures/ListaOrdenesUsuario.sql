CREATE PROCEDURE [dbo].[ListaOrdenesUsuario]
@idUsuario as int
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 
    select idOrden, idCoche, idUsuario, total,fechaInicio, estado from dbo.Orden where idUsuario = @idUsuario
END