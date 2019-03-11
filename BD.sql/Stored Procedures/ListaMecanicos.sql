CREATE PROCEDURE [dbo].[ListaMecanicos]
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select idMecanico, Nombre, Apellido from dbo.Mecanico
END