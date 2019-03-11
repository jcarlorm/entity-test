
CREATE PROCEDURE [dbo].[ListaFacturasElectronicasFechas]
@fechaDesde as DateTime,
@fechaHasta as DateTime
      
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
   
   SELECT consecutivo,
		  fecha,
		  (SELECT (nombre+' '+ apellido) FROM Cliente WHERE idCliente = (SELECT (idCliente) 
		  FROM Orden WHERE idOrden = (SELECT (idOrden) FROM Factura WHERE idFactura = factura_id)))  AS NOMBRE,
		  (SELECT (cedula) FROM Cliente WHERE idCliente = (SELECT (idCliente) FROM Orden WHERE idOrden = (SELECT (idOrden) FROM Factura WHERE idFactura = factura_id))) AS CEDULA,
		  (SELECT (subtotal) FROM Factura WHERE idFactura = factura_id) AS MONTO,
		  '13.00' AS '%IV',
		  (SELECT impuesto FROM Factura WHERE idFactura = factura_id) AS 'IV',
		  (SELECT total FROM Factura WHERE idFactura = factura_id) AS TOTAL,
		  estado 
		  FROM
  Factura_Electronica WHERE datediff(day,convert(datetime, convert(varchar(30), fecha), 101),@fechaDesde)<=0 AND datediff(day,convert(datetime, convert(varchar(30), fecha), 101),@fechaHasta)>=0


END