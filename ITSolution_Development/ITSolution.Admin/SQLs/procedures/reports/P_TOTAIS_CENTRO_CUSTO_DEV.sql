IF OBJECT_ID (N'P_TOTAIS_CENTRO_CUSTO') IS NOT NULL
BEGIN

  DROP PROCEDURE P_TOTAIS_CENTRO_CUSTO;

END
GO
CREATE PROCEDURE P_TOTAIS_CENTRO_CUSTO (
--Periodo
@P_DTINICIO DATETIME, @P_DTFIM DATETIME)
AS
  SELECT
    ccpai.CodigoCentroCusto CodCentroSintetico,
    ccpai.NomeCentroCusto NomeCentroSintetico,
    cc.CodigoCentroCusto CodCentroAnalitico,
    cc.NomeCentroCusto NomeCentroAnalitico,
    (CASE lf.TipoLancamento
      WHEN 0 THEN 'Pagar'
      WHEN 1 THEN 'Receber'
    -- ELSE
    END) AS "tipo",
    (SUM(lf.ValorLancamento) + SUM(lf.ValorJuros)) AS 'Total Centro'
  FROM LancamentoFinanceiro lf
  JOIN CentroCusto cc
    ON lf.IdCentroCusto = cc.IdCentroCusto
  JOIN CentroCusto ccpai
    ON cc.ParentId = ccpai.IdCentroCusto

  WHERE lf.DataVencimento BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
  GROUP BY lf.TipoLancamento,
           cc.CodigoCentroCusto,
           cc.NomeCentroCusto,
           ccpai.CodigoCentroCusto,
           ccpai.NomeCentroCusto



  
GO