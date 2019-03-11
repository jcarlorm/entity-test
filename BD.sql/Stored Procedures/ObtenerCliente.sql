CREATE PROCEDURE [dbo].[ObtenerCliente]  
@idCliente as integer
AS
BEGIN
    SET NOCOUNT ON;
   select idCliente,nombre, apellido, telefono1,tipoCedula, cedula, dirección,correo, estado from dbo.Cliente
   where idCliente  = @idCliente
           
END