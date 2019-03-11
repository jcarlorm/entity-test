CREATE PROCEDURE [dbo].[ListaUsuarioPorEstado]
@estado as int
AS
	SELECT * FROM Usuarios where estado = @estado
	RETURN