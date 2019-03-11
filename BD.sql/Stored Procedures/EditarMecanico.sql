CREATE proc [dbo].[EditarMecanico]
@idMecanico as integer,
@nombre as varchar(50),
@apellido as varchar(50)
AS 
BEGIN 
UPDATE Mecanico 
 set
[nombre]=@nombre ,
[apellido]=@apellido 
 where idMecanico= @idMecanico
END