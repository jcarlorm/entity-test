CREATE PROCEDURE [dbo].[ListaCategorias]
@tipoCategoria as integer
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idCategoría, tipoCategoría, descripción,costo,abreviación,estado from dbo.CATEGORIAS
   where tipoCategoría = @tipoCategoria
END