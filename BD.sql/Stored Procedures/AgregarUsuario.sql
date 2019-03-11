CREATE proc [dbo].[AgregarUsuario]
@nombre as varchar(50),
@apellido as varchar(50),
@contraseña as varchar(50),
@idPerfil as integer,
@idUsuarioLogueado as integer
AS 
BEGIN 
DECLARE @resultado as int,  @estado as int,  @idPerfilLogueado as int, @regla as int,
@idUsuario as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @estado =2
	set @resultado = 0
	set @idPerfilLogueado = 0
		set @idUsuario=( SELECT MAX(idUsuario) FROM Usuarios)+1
    -- Insert statements for procedure here

	if @idUsuario IS NULL
	BEGIN
	set @idUsuario = 0
	END

IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuarioLogueado) 
 BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuarioLogueado)
		set @regla=(select idRegla from regla where Regla = 'Crear_Usuario')
					IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
					BEGIN						
						INSERT INTO  Usuarios VALUES (@idUsuario,@nombre,@apellido,@estado,@contraseña,@idPerfil)
						set @resultado = 1
						return @resultado							
					END
					ELSE
					BEGIN
					set @resultado = 2
					return @resultado
					END
END
ELSE
BEGIN
set @resultado = 0
return @resultado
END
END