CREATE PROCEDURE [dbo].[ListaCochesRecientes]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select TOP(50) idCoche, placa, marca, modelo, cilindrada, año, combustible, transmision, capacidad, vin,
    detalle, idCliente, estado from dbo.Coches order by idCoche DESC
END