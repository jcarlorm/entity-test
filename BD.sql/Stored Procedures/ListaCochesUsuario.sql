CREATE PROCEDURE [dbo].[ListaCochesUsuario]
     
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 
   select idCoche, placa, marca, modelo from dbo.Coches
END