CREATE PROCEDURE [dbo].[ListaTransPerfilRegla]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select IdPerfil,IdRegla from dbo.transPerfilRegla
END