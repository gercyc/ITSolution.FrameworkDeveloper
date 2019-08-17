IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%F_TOTAL_CENTRO_CUSTO_PERIODO%' 
 
) BEGIN

	DROP FUNCTION F_TOTAL_CENTRO_CUSTO_PERIODO; 

END 
GO
-- =============================================
-- Author:		Filipe
-- Description:	Total de lançamentos de um centro de custo 
-- =============================================
CREATE FUNCTION F_TOTAL_CENTRO_CUSTO_PERIODO (@DataInicial DATETIME, @DataFinal DATETIME, @IdCentroCusto INT)
-- Add the parameters for the stored procedure here
RETURNS DECIMAL
BEGIN
  DECLARE @Total DECIMAL;

  SET @Total = (SELECT
    SUM(lf.ValorLancamento)
  FROM LancamentoFinanceiro lf

  JOIN CentroCusto cc
    ON cc.IdCentroCusto = lf.IdCentroCusto

  WHERE cc.IdCentroCusto = @IdCentroCusto
  AND CAST(lf.DataLancamento AS DATE) >= @DataInicial
  AND CAST(lf.DataLancamento AS DATE) <= @DataFinal)

  -- Return the result of the function
  IF (@Total IS NULL)
    SET @Total = 0;

  RETURN @Total

END