CREATE PROCEDURE [dbo].[LoginUsuario]
@nombre as varchar(50),
@contraseña as varchar(50)
	
AS
BEGIN

DECLARE @resultado as int, @Reglas varchar(max), @idPerfilLogueado as int 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
IF EXISTS(SELECT * FROM Usuarios WHERE nombre=@nombre AND contraseña=@contraseña AND estado = 2) 
BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE nombre=@nombre AND contraseña = @contraseña)

		select @Reglas = coalesce (@Reglas+',','') + CONVERT(varchar,IdRegla)
		from transPerfilRegla
		where IdPerfil=@idPerfilLogueado

		SELECT idUsuario,@Reglas as Reglas,@idPerfilLogueado as idPerfil,nombre, apellido FROM Usuarios WHERE nombre=@nombre AND contraseña=@contraseña

END
END