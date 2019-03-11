CREATE PROCEDURE [dbo].[ObtenerCoche]	
@idCoche as integer
AS
BEGIN
	SET NOCOUNT ON;
   select idCoche, placa, marca, modelo, cilindrada, año, combustible, transmision, capacidad, vin,
    detalle, idCliente, estado from dbo.Coches
   where idCoche  = @idCoche
         
END