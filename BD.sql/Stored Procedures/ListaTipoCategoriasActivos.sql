
CREATE PROCEDURE [dbo].[ListaTipoCategoriasActivos]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idTipoCategoria, descripcion, estado, tipoServicio from dbo.TIPOCATEGORIAS WHERE estado = 1
END