CREATE proc [dbo].[AgregarOrden]
@idRevision as int,
@idCoche as int,
@idUsuario as int,
@idCliente as int,
@descripción as varchar(MAX),
@total as float,
@tipoCategoria as varchar(MAX),
@categoria as varchar(MAX),
@precio as varchar(MAX),
@descuento as int

AS 
BEGIN 
DECLARE @idPerfilLogueado as int, @regla as int, @fechaInicio as datetime,
@resultado as int,@idOrden as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @fechaInicio= GETDATE()
	set @resultado = -1
	set @idOrden=( SELECT MAX(idOrden) FROM Orden)+1

	if @idOrden IS NULL
	BEGIN
	set @idOrden = 1
	END

		IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuario) 
		BEGIN

		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuario)
		set @regla=(select idRegla from regla where Regla = 'Crear_Orden')
				IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
				BEGIN				
				INSERT INTO Orden VALUES(@idOrden,@idRevision,@idCoche,@idUsuario,@idCliente,@descripción,
				@total,@tipoCategoria, @categoria, @precio ,@fechaInicio,1, @descuento)
						IF @@ROWCOUNT = 1
						BEGIN		
						set @resultado = @idOrden
						return @resultado
						END
						ELSE
						BEGIN
						set @resultado = -2
						return @resultado
						END
				END
				ELSE
				BEGIN
				set @resultado = -3
				return @resultado
				END
			
		END
		
		ELSE
		BEGIN
		set @resultado = -1
		return @resultado
		END

END