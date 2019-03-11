CREATE PROCEDURE [dbo].[ListaRegla]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select IdRegla, regla, Descripción from dbo.regla
END