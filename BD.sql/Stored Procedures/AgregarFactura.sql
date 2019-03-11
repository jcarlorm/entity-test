CREATE proc [dbo].[AgregarFactura]
@idRevisión as int,
@idOrden as int,
@idCliente as int,
@descripción as varchar(MAX),
@descuento as int,
@impuesto as float,
@subtotal as float,
@total as float,
@tipoPago as varchar(MAX),
@condicionVenta as varchar(MAX),
@exonerado as int,
@nombreUsuario as varchar(MAX),
@contraseña as varchar(MAX)

AS 
BEGIN 


DECLARE @fecha as datetime,@estado as int,@idPerfilLogueado as int, @regla as int,
@resultado as int, @idFactura as int, @idUsuario as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @fecha= GETDATE() set @estado =1 set @resultado = -1
		set @idFactura=(SELECT MAX(idFactura) FROM Factura)+1
    -- Insert statements for procedure here
    
	if @idFactura IS NULL
	BEGIN
	set @idFactura = 0
	END

    IF EXISTS(SELECT * FROM Usuarios WHERE nombre=@nombreUsuario AND contraseña = @contraseña) 
	BEGIN
	
		set @idUsuario=(SELECT idUsuario FROM Usuarios WHERE nombre=@nombreUsuario AND contraseña = @contraseña)
		set @idPerfilLogueado = (SELECT [IdPerfil] FROM Usuarios WHERE nombre=@nombreUsuario AND contraseña = @contraseña)
		set @regla=(select idRegla from regla where Regla = 'Crear_Factura')
			
				IF EXISTS(select IdPerfil from transPerfilRegla WHERE IdRegla =@regla AND IdPerfil= @idPerfilLogueado)
				BEGIN				
				INSERT INTO Factura VALUES(@idFactura,@idRevisión,@idOrden,@idCliente, @idUsuario,
				@descripción,@descuento,@impuesto,@subtotal,@total,@tipoPago,@fecha,@estado,@exonerado,@condicionVenta)
						IF @@ROWCOUNT = 1
						BEGIN		
						set @resultado = @idFactura
						return @resultado
						END
						ELSE
						BEGIN
						set @resultado = -3
						return @resultado
						END
				END
				ELSE
				BEGIN
				set @resultado = -2
				return @resultado
				END
 
	END	
	ELSE
	BEGIN
	set @resultado = -1
	return @resultado
	END
 
END