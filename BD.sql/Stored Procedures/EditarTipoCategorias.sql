
CREATE proc [dbo].[EditarTipoCategorias]
@idTipoCategoria as integer,
@descripcion as varchar(MAX),
@estado as int,
@tipoServicio as int
AS
BEGIN
UPDATE TIPOCATEGORIAS 
 set
[descripcion]=@descripcion,
[estado]=@estado,
[tipoServicio]=@tipoServicio
 where idTipoCategoria= @idTipoCategoria
END