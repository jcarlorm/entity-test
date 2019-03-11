CREATE PROCEDURE [dbo].[ObtenerUsuario]	
@idUsuario as integer
AS
BEGIN

DECLARE @resultado as int, @Reglas varchar(max), @idPerfilLogueado as int 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario = @idUsuario) 
BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario= @idUsuario)

		select @Reglas = coalesce (@Reglas+',','') + CONVERT(varchar,IdRegla)
		from transPerfilRegla
		where IdPerfil=@idPerfilLogueado

		SELECT idUsuario,@Reglas as Reglas, nombre, apellido, estado,contraseña, @idPerfilLogueado as idPerfil FROM Usuarios WHERE idUsuario= @idUsuario

END
END