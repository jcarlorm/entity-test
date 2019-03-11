CREATE proc [dbo].[AgregarPerfil]
@perfil as varchar(50),
@descripción as varchar(MAX),
@idUsuario as integer

AS 
BEGIN
DECLARE @resultado as int, @idPerfilLogueado as int, @regla as int, @idPerfil as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @resultado = 0
	set @idPerfilLogueado = 0
	set @idPerfil=( SELECT MAX(IdPerfil) FROM perfil)+1

	if @idPerfil IS NULL
	BEGIN
	set @idPerfil = 0
	END

IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuario) 
BEGIN
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuario)
		set @regla=(select idRegla from regla where Regla = 'Agregar_Perfil')
			IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
			BEGIN	
			INSERT INTO  perfil VALUES(@idPerfil,@perfil,@descripción)
				IF @@ROWCOUNT = 1
				BEGIN
				set @resultado = 1
				return @resultado
				END
				ELSE
				BEGIN
				set @resultado = 3
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
set @resultado = 0
return @resultado
END
END