CREATE proc [dbo].[EditarCliente]
@idCliente as integer,
@nombre as varchar(MAX),
@apellido as varchar(MAX),
@telefono1 as varchar(20),
@tipoCedula as int,
@cedula as varchar(20),
@dirección as varchar(MAX),
@correo as varchar(MAX),
@estado as int
AS
BEGIN
UPDATE Cliente 
 set
[nombre]=@nombre ,
[apellido]=@apellido ,
[telefono1]=@telefono1 ,
[tipoCedula]=@tipoCedula ,
[cedula]=@cedula,
[dirección]=@dirección,
[correo]=@correo,
[estado]=@estado
 where idCliente= @idCliente
END