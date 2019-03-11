CREATE PROCEDURE [dbo].[ListaRevisionesPorIdCoche]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	   select idRevision, idCoche, 
   (select placa from Coches where idCoche =Ord.idCoche) as Placa
   
    from dbo.Revision  AS Ord
END