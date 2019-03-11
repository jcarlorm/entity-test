CREATE PROCEDURE [dbo].[ListaUsuario]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idUsuario, nombre, apellido, estado, contraseña, IdPerfil from dbo.Usuarios
END