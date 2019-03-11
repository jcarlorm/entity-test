
CREATE PROCEDURE [dbo].[ListaTipoCategorias]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idTipoCategoria, descripcion, estado, tipoServicio from dbo.TIPOCATEGORIAS
END