IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_TOTAIS_CENTRO_CUSTO%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_TOTAIS_CENTRO_CUSTO; 

END
GO
CREATE PROCEDURE dbo.P_TOTAIS_CENTRO_CUSTO (
--Periodo
@P_DTINICIO DATETIME, @P_DTFIM DATETIME)
AS
  SELECT
    (CASE lf.TipoLancamento
      WHEN 0 THEN 'Pagar'
      WHEN 1 THEN 'Receber'
    -- ELSE
    END) AS "Tipo",
    cc.CodigoCentroCusto,
    cc.NomeCentroCusto,
    (SUM(lf.ValorLancamento) + SUM(lf.ValorJuros)) AS 'Total Centro'
  FROM LancamentoFinanceiro lf
  JOIN CentroCusto cc
    ON lf.IdCentroCusto = cc.IdCentroCusto

  WHERE lf.DataVencimento BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
  GROUP BY lf.TipoLancamento,
           cc.CodigoCentroCusto,
           cc.NomeCentroCusto
GO