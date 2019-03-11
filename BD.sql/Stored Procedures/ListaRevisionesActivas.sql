CREATE PROCEDURE [dbo].[ListaRevisionesActivas]
     
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 SELECT Re.idRevision, Re.idCoche, Re.idUsuario, Re.idCliente, Re.descripción, Re.total, Re.tipoCategoria, Re.categoria,
   Re.precio, Re.fechaInicio, Re.estado, 
   Cli.idCliente, Cli.nombre, Cli.apellido, 
   Coc.idCliente, Coc.idCoche, Coc.placa
FROM Revision Re, Cliente  Cli, Coches Coc
WHERE RE.estado=1 AND 
Cli.idCliente = Re.idCliente AND 
Coc.idCoche = Re.idCoche
END