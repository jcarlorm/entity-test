CREATE PROCEDURE [dbo].[IniciarSesion]
	@NombreUsuario AS VARCHAR(20),
	@Password AS VARCHAR(20) 
AS
	SELECT * FROM Usuarios 
	WHERE nombre = @NombreUsuario AND contraseña = @Password
	RETURN