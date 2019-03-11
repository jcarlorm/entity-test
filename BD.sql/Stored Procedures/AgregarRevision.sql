CREATE proc [dbo].[AgregarRevision]
@idCoche as int,
@idUsuario as int,
@idCliente as varchar(MAX),
@descripción as varchar(MAX),
@total as float,
@tipoCategoria as varchar(MAX),
@categoria as varchar(MAX),
@precio as varchar(MAX)

AS 
BEGIN 


DECLARE @fechaInicio as datetime,@estado as int, @idRevision as int,@idPerfilLogueado as int, @regla as int,
@resultado as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @fechaInicio= GETDATE() set @estado =1 	set @resultado = -1
		set @idRevision=( SELECT MAX(idRevision) FROM Revision)+1
    -- Insert statements for procedure here
    
	if @idRevision IS NULL
	BEGIN
	set @idRevision = 0
	END

		IF EXISTS(SELECT * FROM Usuarios WHERE idUsuario=@idUsuario) 
		BEGIN

		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE idUsuario=@idUsuario)
		set @regla=(select idRegla from regla where Regla = 'Crear_Revisión')
				IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
				BEGIN
			
				INSERT INTO Revision VALUES
				(@idRevision,@idCoche,@idUsuario,@idCliente,@descripción,@total,
				@tipoCategoria,@categoria,@precio,@fechaInicio,@estado)
						IF @@ROWCOUNT = 1
						BEGIN		
						set @resultado = @idRevision
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