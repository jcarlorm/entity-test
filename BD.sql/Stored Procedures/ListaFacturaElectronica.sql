
CREATE PROCEDURE [dbo].[ListaFacturaElectronica]

@id as int 
      
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
  
   select * from Factura_Electronica where factura_id = @id


END