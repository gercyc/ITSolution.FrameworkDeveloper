IF OBJECT_ID (N'P_TOTAIS_PRODUCAO_SERRA') IS NOT NULL
BEGIN

  DROP PROCEDURE P_TOTAIS_PRODUCAO_SERRA;

END
GO

CREATE PROCEDURE dbo.P_TOTAIS_PRODUCAO_SERRA (
--Periodo
@P_DTINICIO DATETIME, @P_DTFIM DATETIME, @P_IDSERRA VARCHAR(10))
AS

  SELECT
    (CASE
      WHEN ps.IdSerra > 0 THEN CONCAT('Serra ', ps.IdSerra)
    END) AS 'Serra',

    SUM(ps.QuantidadePeca) 'Total Peças',
    SUM(ps.MetrosQuadrado) AS 'Total M²',
    SUM(ps.MetrosCubico) AS 'Total M³',
    SUM(ps.TotalUnitario) AS 'Total Reais'
  FROM ProducaoSerra ps
  JOIN Serra s
    ON s.IdSerra = ps.IdSerra
  JOIN MaterialSerra ms
    ON ms.IdMaterial = ps.IdMaterial
  WHERE ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
  AND ps.IdSerra LIKE IIF(@P_IDSERRA = '0', '%', @P_IDSERRA)
  GROUP BY ps.IdSerra,
           s.StatusSerra


  
GO