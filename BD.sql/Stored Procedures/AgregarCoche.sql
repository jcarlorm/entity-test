CREATE proc [dbo].[AgregarCoche]
@placa as varchar(20),
@marca as varchar(20),
@modelo as varchar(20),
@cilindrada as integer,
@año as integer,
@combustible as integer,
@transmision as integer,
@capacidad as integer,
@vin as varchar(50),
@detalle as varchar(MAX),
@idCliente as integer
AS 
BEGIN 
DECLARE @idCoche as int
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
	set @idCoche=( SELECT MAX(idCoche) FROM Coches)+1
	
	if @idCoche IS NULL
	BEGIN
	set @idCoche = 1
	END

INSERT INTO  Coches VALUES
(
@idCoche,
@placa,
@marca,
@modelo,
@cilindrada,
@año,
@combustible,
@transmision,
@capacidad,
@vin,
@detalle,
@idCliente,
1
 )
return @idCoche
END