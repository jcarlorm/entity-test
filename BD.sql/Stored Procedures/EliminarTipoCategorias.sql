
CREATE proc [dbo].[EliminarTipoCategorias]
@idTipoCategoria as integer
AS
BEGIN
UPDATE TIPOCATEGORIAS 
 set
[estado]=0
 where idTipoCategoria= @idTipoCategoria
END