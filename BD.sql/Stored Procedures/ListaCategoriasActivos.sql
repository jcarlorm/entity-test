
CREATE PROCEDURE [dbo].[ListaCategoriasActivos]
@tipoCategoria as integer
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idCategoría, tipoCategoría, descripción, costo, abreviación, estado from dbo.CATEGORIAS 
   WHERE estado = 1 AND tipoCategoría = @tipoCategoria
END