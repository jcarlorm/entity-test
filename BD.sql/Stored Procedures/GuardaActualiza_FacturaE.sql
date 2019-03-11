
CREATE proc [dbo].[GuardaActualiza_FacturaE]
@id int,
@TipoIdentificacion varchar(50),
@Identificacion varchar(50),
@NombreComercial varchar(50),
@CodigoPais varchar(50),
@Provincia varchar(2),
@Canton varchar(2),
@Distrito varchar(2),
@Barrio varchar(2),
@OtrasSenas varchar(300),
@UsuarioATV varchar(300),
@ClaveATV varchar(300),
@ClaveCertificado varchar(300),
@Normativa varchar(150),
@FechaResolucion varchar(50),
@Surcusal varchar(10),
@Consecutivo int,
@UrlBase varchar(350),
@UrlEnvio varchar(350),
@UrlComprobantes varchar(350),
@NombreCompleto varchar(350),
@Telefono varchar(350),
@Correo varchar(150),
@Aplica int,
@Impresora varchar(300),
@Nota int,
@Terminal varchar(10),
@CorreoEnvio varchar(150)
  
AS
BEGIN

IF @id = 0 
begin
INSERT INTO [dbo].[admin_factura_electronica]
           ([TipoIdentificacion]
           ,[Identificacion]
           ,[NombreComercial]
           ,[CodigoPais]
           ,[Provincia]
           ,[Canton]
           ,[Distrito]
           ,[Barrio]
           ,[OtrasSenas]
           ,[UsuarioATV]
           ,[ClaveATV]
           ,[ClaveCertificado]
           ,[Normativa]
           ,[FechaResolucion]
           ,[Surcusal]
           ,[Consecutivo]
           ,[UrlBase]
           ,[UrlEnvio]
           ,[UrlComprobantes]
           ,[NombreCompleto]
           ,[Telefono]
           ,[Correo]
           ,[Aplica]
           ,[Impresora], [Nota], [Terminal] , [CorreoEnvio])
     VALUES
           (
			@TipoIdentificacion ,
		    @Identificacion ,
			@NombreComercial ,
			@CodigoPais ,
			@Provincia ,
			@Canton ,
			@Distrito ,
			@Barrio ,
			@OtrasSenas ,
			@UsuarioATV ,
			@ClaveATV ,
			@ClaveCertificado ,
			@Normativa ,
			@FechaResolucion ,
			@Surcusal ,
			@Consecutivo ,
			@UrlBase ,
			@UrlEnvio ,
			@UrlComprobantes ,
			@NombreCompleto ,
			@Telefono ,
			@Correo ,
			@Aplica ,
			@Impresora, @Nota , @Terminal, @CorreoEnvio) 


			select top 1 @id = id from admin_factura_electronica 
end
ELSE
begin
UPDATE admin_factura_electronica SET

			Identificacion = @Identificacion ,
			NombreComercial = @NombreComercial ,
			CodigoPais = @CodigoPais ,
			Provincia = @Provincia ,
			Canton = @Canton ,
			Distrito = @Distrito ,
			TipoIdentificacion = @TipoIdentificacion ,
			Barrio = @Barrio ,
			OtrasSenas = @OtrasSenas ,
			UsuarioATV = @UsuarioATV ,
			ClaveATV = @ClaveATV ,
			ClaveCertificado = @ClaveCertificado ,
			Normativa = @Normativa ,
			FechaResolucion = @FechaResolucion ,
			Surcusal = @Surcusal ,
			Consecutivo = @Consecutivo ,
			UrlBase = @UrlBase ,
			UrlEnvio = @UrlEnvio ,
			UrlComprobantes = @UrlComprobantes ,
			NombreCompleto = @NombreCompleto ,
			Telefono = @Telefono ,
			Correo = @Correo ,
			Aplica =  @Aplica ,
			Impresora = @Impresora,
			Nota = @Nota,
			Terminal = @Terminal,
			CorreoEnvio = @CorreoEnvio

			WHERE  id = @id
end

return @id
END