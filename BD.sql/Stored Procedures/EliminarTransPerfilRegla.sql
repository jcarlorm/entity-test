CREATE proc [dbo].[EliminarTransPerfilRegla]
@IdPerfil as integer,
@IdRegla as integer,
@idUsuarioLogueado as integer

AS 
BEGIN
DECLARE @resultado as int, @idPerfilLogueado as int, @regla as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @resultado = 0
	set @idPerfilLogueado = 0

IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuarioLogueado) 
 BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuarioLogueado)
		set @regla=(select idRegla from regla where Regla = 'Eliminar_Regla')
				IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
					BEGIN
					DELETE FROM transPerfilRegla WHERE IdPerfil=@IdPerfil AND IdRegla =@IdRegla
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