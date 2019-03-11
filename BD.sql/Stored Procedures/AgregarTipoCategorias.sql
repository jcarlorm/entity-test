
CREATE proc [dbo].[AgregarTipoCategorias]
@descripcion as varchar(MAX),
@tipoServicio as int
  
AS
BEGIN
DECLARE @idTipoCategoria as int
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
    set @idTipoCategoria=( SELECT MAX(idTipoCategoria) FROM TIPOCATEGORIAS)+1
      
     if @idTipoCategoria IS NULL
    BEGIN
    set @idTipoCategoria = 1
    END
 
INSERT INTO TIPOCATEGORIAS VALUES
(
@idTipoCategoria,
@descripcion,
1,
@tipoServicio
 ) 
return @idTipoCategoria
END