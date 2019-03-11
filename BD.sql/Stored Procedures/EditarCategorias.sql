
CREATE proc [dbo].[EditarCategorias]
@idCategoria as integer,
@tipoCategoria as integer,
@descripcion as varchar(MAX),
@costo as float,
@abreviacion as varchar(MAX),
@estado as int
AS
BEGIN
UPDATE Categorias 
 set
[tipoCategoría]=@tipoCategoria,
[descripción]=@descripcion,
[costo]=@costo,
[abreviación]=@abreviacion,
[estado]=@estado
 where idCategoría= @idCategoria
END