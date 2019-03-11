CREATE PROCEDURE [dbo].[ListaOrdenesRecientes]
     
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 
 SELECT Ord.idOrden, Ord.idRevision, Ord.idCoche, Ord.idUsuario, Ord.idCliente, Ord.descripción, 
   Ord.total, Ord.tipoCategoria, Ord.categoria, Ord.precio, Ord.fechaInicio, Ord.estado, Ord.descuento,
   Re.total, Re.fechaInicio, 
   Cli.nombre, Cli.apellido, 
   Coc.placa
FROM Orden Ord, Revision Re, Cliente  Cli, Coches Coc
where Ord.estado =1 AND 
Re.idRevision = Ord.idRevision AND 
Cli.idCliente = Ord.idCliente AND 
Coc.idCoche = Ord.idCoche order by idOrden DESC
END