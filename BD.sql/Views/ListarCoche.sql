CREATE VIEW [dbo].[ListarCoche]
AS SELECT idCoche,placa, marca,modelo,cilindrada,  año,combustible,transmision,capacidad,vin, detalle, idCliente
FROM Coches;