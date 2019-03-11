
CREATE PROCEDURE [dbo].[ActualizaConsecutivoFacturaE]
AS
BEGIN

	Declare @id int

    update admin_factura_electronica set Consecutivo = Consecutivo + 1

	select top 1 @id=Consecutivo from admin_factura_electronica

	return @id
END