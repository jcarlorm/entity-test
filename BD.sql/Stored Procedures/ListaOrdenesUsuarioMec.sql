CREATE PROCEDURE [dbo].[ListaOrdenesUsuarioMec]
@idUsuario as int
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 
    select idOrden, 
	(select (nombre + ' '+ apellido) from Cliente where idCliente = ord.idCliente), 
	(select placa from Coches where idCoche = ord.idCoche), 
	(cast( dbo.splitstring3(tipoCategoria,precio) as float)-ord.descuento),
	fechaInicio
	 from dbo.Orden ord where idUsuario = @idUsuario AND estado = 1
END