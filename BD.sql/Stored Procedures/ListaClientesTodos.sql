
CREATE PROCEDURE [dbo].[ListaClientesTodos]
      
      
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
  
   select idCliente, nombre, apellido, telefono1, tipoCedula, cedula,dirección, correo, estado from dbo.Cliente
END