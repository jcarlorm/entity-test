CREATE proc [dbo].[EditarCoche]
@idCoche as integer,
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
@idCliente as integer,
@estado as integer
AS 
BEGIN 
UPDATE Coches 
 set
[placa]=@placa ,
[marca]=@marca ,
[modelo]=@modelo ,
[cilindrada]=@cilindrada,
[año]=@año,
[combustible]=@combustible,
[transmision]=@transmision,
[capacidad]=@capacidad,
[vin]=@vin,
[detalle]=@detalle,
[idCliente]=@idCliente,
[estado]=@estado
 where idCoche= @idCoche
END