CREATE proc [dbo].[EditarRevision]
@idRevision as integer,
@idCoche as integer,
@idUsuario as integer,
@idCliente as varchar(MAX),
@descripción as varchar(MAX),
@total as float,
@tipoCategoria as varchar(MAX),
@categoria as varchar(MAX),
@precio as varchar(MAX)
AS 
BEGIN 
UPDATE Revision 
 set
[idCoche]=@idCoche ,
[idUsuario]=@idUsuario ,
[idCliente]=@idCliente,
[descripción]=@descripción ,
[total]=@total,
[tipoCategoria]=@tipoCategoria,
categoria=@categoria,
precio=@precio
 where idRevision= @idRevision
END