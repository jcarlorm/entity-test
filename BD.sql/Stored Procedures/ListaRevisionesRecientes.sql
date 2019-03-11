CREATE PROCEDURE [dbo].[ListaRevisionesRecientes]
     
     
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
where Re.estado =1 AND 
Cli.idCliente = Re.idCliente AND 
Coc.idCoche = Re.idCoche order by Re.idRevision DESC
END