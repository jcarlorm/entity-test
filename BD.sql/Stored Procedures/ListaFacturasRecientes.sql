
CREATE PROCEDURE [dbo].[ListaFacturasRecientes]
     
     
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
 SELECT Fac.idFactura, Fac.idRevisión, Fac.idOrden, Fac.idCliente, Fac.idUsuario, Fac.descripción, Fac.descuento, 
   Fac.impuesto, Fac.subtotal, Fac.total, Fac.tipoPago, Fac.fecha, Fac.estado, Fac.exonerado, Fac.condicionVenta,
   Cli.nombre, Cli.apellido, Cli.cedula,
   Coc.placa,
   Usu.nombre, Usu.apellido
FROM Factura Fac, Cliente  Cli, Coches Coc, Usuarios Usu
WHERE Fac.estado =1 AND 
Cli.idCliente = Fac.idCliente AND 
Coc.idCoche = (select idCoche from Revision where idRevision = Fac.idRevisión) AND 
Usu.idUsuario = Fac.idUsuario order by idFactura DESC
 
END