CREATE PROCEDURE [dbo].[ListaUsuarioMecanico]
	
@idPerfil as int,
@estado1 as int,
@estado2 as int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idUsuario, nombre, apellido, estado, contraseña, IdPerfil from dbo.Usuarios where IdPerfil = @idPerfil AND (estado = @estado1 OR estado =@estado2)
END