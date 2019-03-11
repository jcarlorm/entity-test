
CREATE PROCEDURE [dbo].[GuardarFacturaElectronica]
@id int,
@factura_id int,
@clave text,
@consecutivo text,
@xml text,
@xmlfirmado text,
@xmlrespuesta text,
@estado text,
@documento_id int,
@fecha text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @IDFACTURAE INT

	IF @id = 0
	BEGIN
	INSERT INTO [dbo].[Factura_Electronica]
           ([factura_id]
           ,[clave]
           ,[consecutivo]
           ,[xml]
           ,[xmlfirmado]
           ,[xmlrespuesta]
           ,[estado]
           ,[documento_id], [fecha])
     VALUES
           ( @factura_id
           ,@clave
           ,@consecutivo
           ,@xml
           ,@xmlfirmado
           ,@xmlrespuesta
           ,@estado
           ,@documento_id, @fecha)
	END
	ELSE 
	BEGIN
		update Factura_Electronica set 
			
			xmlrespuesta = @xmlrespuesta,
			estado = @estado

			where id = @id
	END

	select @IDFACTURAE = max(id) from Factura_Electronica

	return @IDFACTURAE

END