CREATE PROCEDURE [dbo].[ObtenerPlacaCoche]	
@placa as varchar(20)
AS
BEGIN
	SET NOCOUNT ON;
   select idCoche, placa, marca, modelo, cilindrada, año, combustible, transmision, capacidad, vin,
    detalle, idCliente, estado from dbo.Coches
   where placa  = @placa
         
END