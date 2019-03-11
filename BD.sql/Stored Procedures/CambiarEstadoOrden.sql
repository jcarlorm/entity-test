CREATE proc [dbo].[CambiarEstadoOrden]
@estado as integer,
@idOrden as integer,
@idUsuarioLogueado as integer
AS 
BEGIN 
DECLARE @resultado as int, @idPerfilLogueado as int, @regla as int
set @resultado = 0
set @idPerfilLogueado = 0
 
IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuarioLogueado) 
BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuarioLogueado)
		set @regla=(select idRegla from regla where Regla = 'Cambiar_Estado_Orden')
		
			IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
					BEGIN						
					UPDATE Orden 
					set
					[estado]=@estado
					where idOrden= @idOrden
					IF @@ROWCOUNT = 1
					BEGIN
					set @resultado = 1
					return @resultado
					END
					ELSE
					BEGIN
					set @resultado = 0
					return @resultado
					END						
			END
			ELSE
			BEGIN
			set @resultado = 2
			return @resultado
			END
 
END
ELSE
BEGIN
set @resultado = 3
return @resultado
END
END