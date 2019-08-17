CREATE PROCEDURE dbo.RESET_PK_FROM_TABLE (@P_TB_NAME VARCHAR(100), @P_VALUE INT)
AS
  DECLARE @v_value INT;

  SET @v_value = @P_VALUE - 1;

  IF (@v_value < 0)
  BEGIN
    SET @v_value = 0;
  END

  DBCC CHECKIDENT (@P_TB_NAME, RESEED, @v_value)


  
GO