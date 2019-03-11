CREATE PROCEDURE [dbo].[ListaNumeroFactura]
	
	
AS
BEGIN
DECLARE
@idFactura as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		set @idFactura=(SELECT MAX(idFactura) FROM Factura)
    -- Insert statements for procedure here
    
	if @idFactura IS NOT NULL
	BEGIN
	(SELECT MAX(idFactura) FROM Factura)
	END
END