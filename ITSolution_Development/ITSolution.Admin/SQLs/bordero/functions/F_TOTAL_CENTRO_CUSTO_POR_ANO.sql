IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%F_TOTAL_CENTRO_POR_ANO%' 
 
) BEGIN

	DROP FUNCTION F_TOTAL_CENTRO_POR_ANO; 

END 
GO
--- ==================================
-- Author:		Filipe
-- Description:	Total de lançamentos de um centro de custo 
-- =============================================
CREATE FUNCTION F_TOTAL_CENTRO_POR_ANO (@IdCentroCusto INT, @Ano INT)
-- Add the parameters for the stored procedure here
RETURNS DECIMAL
BEGIN
  DECLARE @Total DECIMAL;

  SET @Total = (SELECT
    SUM(lf.ValorLancamento)
  FROM Lancamento lf

  JOIN CentroCusto cc
    ON cc.IdCentroCusto = lf.IdCentroCusto

  WHERE cc.IdCentroCusto = @IdCentroCusto
  AND DATEPART(YEAR, lf.DataLancamento) = @Ano)--Fim do calculo

  -- Return the result of the function
  IF (@Total IS NULL)
    SET @Total = 0;

  RETURN @Total

END