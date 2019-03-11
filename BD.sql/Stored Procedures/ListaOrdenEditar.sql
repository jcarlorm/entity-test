CREATE PROCEDURE [dbo].[ListaOrdenEditar]
@tipo as varchar(MAX)
	
AS
BEGIN
DECLARE @sqlText nvarchar(1000)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 

SET @sqlText = N'SELECT idOrden,' + @tipo + ' FROM dbo.Orden'
Exec (@sqlText)
END