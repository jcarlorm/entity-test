CREATE PROCEDURE [dbo].[ObtenerIdUsuario]	
@nombre as varchar(50),
@contraseña as varchar(50)
AS 
BEGIN 


DECLARE @resultado as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @resultado = -1
    -- Insert statements for procedure here
		IF EXISTS(SELECT (1) FROM Usuarios WHERE nombre=@nombre AND contraseña = @contraseña) 
		BEGIN
		set @resultado =(SELECT [idUsuario] FROM Usuarios WHERE nombre=@nombre AND contraseña = @contraseña)
		return @resultado
		END
		ELSE
		BEGIN
		set @resultado = -1
		return @resultado
		END
         
END