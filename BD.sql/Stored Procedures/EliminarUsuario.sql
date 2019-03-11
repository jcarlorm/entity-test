CREATE proc [dbo].[EliminarUsuario]
@idUsuario as integer
AS 
BEGIN 

DECLARE @estado as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @estado =0
    -- Insert statements for procedure here


UPDATE Usuarios 
 set
[estado]=@estado 
 where idUsuario= idUsuario
END