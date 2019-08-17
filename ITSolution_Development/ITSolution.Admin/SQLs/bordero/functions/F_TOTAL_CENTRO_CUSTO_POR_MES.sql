IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%F_TOTAL_CENTRO_CUSTO_POR_MES%' 
 
) BEGIN

	DROP FUNCTION F_TOTAL_CENTRO_CUSTO_POR_MES; 

END 
GO
-- =============================================
-- Author:		Filipe
-- Description:	Total de lançamentos de um centro de custo 
-- =============================================
CREATE FUNCTION F_TOTAL_CENTRO_CUSTO_POR_MES (
-- Add the parameters for the function here	
@Mes INT, @Ano INT, @IdCentroCusto INT)
RETURNS DECIMAL
BEGIN
  DECLARE @Total DECIMAL;

  SET @Total = (SELECT
    SUM(lf.ValorLancamento)
  FROM LancamentoFinanceiro lf
  JOIN CentroCusto cc
    ON cc.IdCentroCusto = lf.IdCentroCusto

  WHERE cc.IdCentroCusto = @IdCentroCusto
  AND DATEPART(MONTH, lf.DataLancamento) = @Mes
  AND DATEPART(YEAR, lf.DataLancamento) = @Ano)

  -- Return the result of the function
  IF (@Total IS NULL)
    SET @Total = 0;

  RETURN @Total

END