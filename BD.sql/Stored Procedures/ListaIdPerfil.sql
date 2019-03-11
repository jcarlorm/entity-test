CREATE PROCEDURE [dbo].[ListaIdPerfil]
@dato as varchar(25)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select IdPerfil from dbo.perfil where Perfil =@dato
END