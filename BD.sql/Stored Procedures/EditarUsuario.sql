CREATE proc [dbo].[EditarUsuario]
@idUsuario as integer,
@nombre as varchar(50),
@apellido as varchar(50),
@contraseña as varchar(50),
@idPerfil as integer,
@idUsuarioLogueado as integer

AS 
BEGIN 
DECLARE @resultado as int,  @idPerfilLogueado as int, @regla as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @resultado = 0
	set @idPerfilLogueado = 0
	
	
IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuarioLogueado) 
 BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuarioLogueado)
		set @regla=(select idRegla from regla where Regla = 'Editar_Usuario')
					IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
					BEGIN	
							UPDATE Usuarios 
							 set
							 [nombre]=@nombre ,
							 [apellido]=@apellido,
							 [contraseña]=@contraseña, 
							 [idPerfil]=@idPerfil
							  where idUsuario= @idUsuario
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