CREATE PROCEDURE [dbo].[ListaPerfil]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select IdPerfil, perfil, Descripción from dbo.perfil
END