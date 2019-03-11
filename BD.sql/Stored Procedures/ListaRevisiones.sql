CREATE PROCEDURE [dbo].[ListaRevisiones]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idRevision, idCoche, idUsuario, idCliente, descripción, total, tipoCategoria, categoria,
   precio, fechaInicio,  estado from dbo.Revision
END