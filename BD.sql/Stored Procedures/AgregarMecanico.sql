CREATE proc [dbo].[AgregarMecanico]
@nombre as varchar(20),
@apellido as varchar(20)
AS 
BEGIN 
DECLARE @idMecanico as int
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
	set @idMecanico=( SELECT MAX(idMecanico) FROM Mecanico)+1

	if @idMecanico IS NULL
	BEGIN
	set @idMecanico = 0
	END

INSERT INTO Mecanico VALUES
(
@idMecanico,
@nombre,
@apellido
 )
END