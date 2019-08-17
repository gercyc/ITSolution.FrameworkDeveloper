CREATE FUNCTION dbo.F_DATAS (@ano SMALLINT, @mes TINYINT)

RETURNS @datas TABLE (
  data SMALLDATETIME
)

AS

BEGIN

  DECLARE @dia TINYINT,
          @data VARCHAR(10)

  SET @dia = 1

  WHILE @dia <= 31

  BEGIN

    SET @data = CAST(@ano AS CHAR(4)) + '-' +

    CAST(@mes AS VARCHAR(2)) + '-' +

    CAST(@dia AS VARCHAR(2))

    IF ISDATE(@data) = 1

      INSERT INTO @datas
        VALUES (@data)

    SET @dia = @dia + 1

  END

  RETURN

END

GO