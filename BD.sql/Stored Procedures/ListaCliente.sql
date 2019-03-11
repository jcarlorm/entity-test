CREATE PROCEDURE [dbo].[ListaCliente]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idCliente, nombre, apellido, telefono1, tipoCedula, cedula, correo from dbo.Cliente
END