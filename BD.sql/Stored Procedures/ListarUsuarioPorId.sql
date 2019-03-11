CREATE PROCEDURE [dbo].[ListarUsuarioPorId]
 
AS
    select idUsuario, nombre, apellido from dbo.Usuarios
    RETURN