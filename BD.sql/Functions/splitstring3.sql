
CREATE FUNCTION [dbo].[splitstring3] ( @stringToSplit VARCHAR(MAX),@stringToSplit2 VARCHAR(MAX) )
RETURNS
 VARCHAR(MAX)
AS
BEGIN

DECLARE @list varchar(MAX)
DECLARE @pos INT
DECLARE @len INT
DECLARE @value varchar(MAX)

DECLARE @list2 varchar(MAX)
DECLARE @pos2 INT
DECLARE @len2 INT
DECLARE @value2 varchar(MAX)

DECLARE @suma INT

SET @list = @stringToSplit
SET @list2 = @stringToSplit2
SET @suma =0

set @pos = 0
set @len = 0

set @pos2 = 0
set @len2 = 0

WHILE CHARINDEX(',', @list, @pos+1)>0
BEGIN
    set @len = CHARINDEX(',', @list, @pos+1) - @pos
    set @value = SUBSTRING(@list, @pos, @len)
    set @len2 = CHARINDEX(',', @list2, @pos2+1) - @pos2
    set @value2 = SUBSTRING(@list2, @pos2, @len2)
        
		if  @value NOT LIKE '%*'
		BEGIN
		set @suma= @suma+(cast(@value2 as int))  -- for debug porpose  
	
	END
    
    --DO YOUR MAGIC HERE

    set @pos = CHARINDEX(',', @list, @pos+@len) +1
    set @pos2 = CHARINDEX(',', @list2, @pos2+@len2) +1
END
RETURN @suma
END