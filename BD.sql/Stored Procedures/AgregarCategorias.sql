
CREATE proc [dbo].[AgregarCategorias]
@tipoCategoria as int,
@descripcion as varchar(MAX),
@costo as float,
@abreviacion as varchar(MAX)
  
AS
BEGIN
DECLARE @idCategoria as int,@resultado as int
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
	set @resultado = 1
    set @idCategoria=( SELECT MAX(idCategoría) FROM CATEGORIAS)+1
      
     if @idCategoria IS NULL
    BEGIN
    set @idCategoria = 1
    END
 IF NOT EXISTS(SELECT (1) FROM Categorias WHERE descripción=@descripcion) 
	BEGIN
INSERT INTO CATEGORIAS VALUES
(
@idCategoria,
@tipoCategoria,
@descripcion,
@costo,
@abreviacion,
1
 ) 
return @idCategoria
END
ELSE
	BEGIN
	set @resultado = 2
	return @resultado
END
END