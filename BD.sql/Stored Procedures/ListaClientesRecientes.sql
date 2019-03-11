CREATE PROCEDURE [dbo].[ListaClientesRecientes]
      
      
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
  
   select TOP(50) idCliente, nombre, apellido, telefono1, tipoCedula, cedula,dirección, correo, estado from dbo.Cliente
   order by idCliente DESC 
END