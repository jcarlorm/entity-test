
CREATE proc [dbo].[EliminarCategorias]
@idCategoria as integer
AS
BEGIN
UPDATE CATEGORIAS 
 set
[estado]=0
 where idCategoría= @idCategoria
END