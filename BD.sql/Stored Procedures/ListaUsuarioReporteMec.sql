CREATE PROCEDURE [dbo].[ListaUsuarioReporteMec]
@estado as int
AS
	SELECT idUsuario, nombre, apellido, estado, 
	( select perfil from perfil where IdPerfil = u.IdPerfil ) FROM Usuarios u where estado = @estado
	RETURN