CREATE proc [dbo].[AgregarCliente]
@nombre as varchar(MAX),
@apellido as varchar(MAX),
@telefono1 as varchar(20),
@tipoCedula as int,
@cedula as varchar(20),
@dirección as varchar(MAX),
@correo as varchar(MAX)
  
AS
BEGIN
DECLARE @idCliente as int
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    set @idCliente=( SELECT MAX(idCliente) FROM Cliente)+1
      
     if @idCliente IS NULL
    BEGIN
    set @idCliente = 1
    END
 
INSERT INTO  Cliente VALUES
(
@idCliente,
@nombre,
@apellido,
@telefono1,
@tipoCedula,
@cedula,
@dirección,
@correo,
1
 ) 
return @idCliente
END