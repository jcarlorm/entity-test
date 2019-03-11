CREATE PROCEDURE [dbo].[ObtenerRevisionCompleta]	
@idRevision as integer
AS
BEGIN
	SET NOCOUNT ON;
SELECT Re.*, Cli.*, Coc.*, Usu.*
FROM Revision Re, Cliente  Cli, Coches Coc, Usuarios Usu
WHERE RE.idRevision =@idRevision AND 
Cli.idCliente = Re.idCliente AND 
Coc.idCoche = Re.idCoche AND 
Usu.idUsuario = Re.idUsuario
         
END