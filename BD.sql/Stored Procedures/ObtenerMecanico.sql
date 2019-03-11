CREATE PROCEDURE [dbo].[ObtenerMecanico]	
@idMecanico as integer
AS
BEGIN
	SET NOCOUNT ON;
   select idMecanico, Nombre, Apellido from dbo.Mecanico
   where idMecanico  = @idMecanico
         
END