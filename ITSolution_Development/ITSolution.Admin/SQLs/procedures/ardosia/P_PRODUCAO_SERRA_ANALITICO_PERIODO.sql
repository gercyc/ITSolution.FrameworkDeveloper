IF EXISTS (SELECT
    ROUTINE_SCHEMA,
    ROUTINE_NAME
  FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_DEFINITION LIKE '%P_PRODUCAO_SERRA_ANALITICO_PERIODO%')
BEGIN

  DROP PROCEDURE P_PRODUCAO_SERRA_ANALITICO_PERIODO;

END
GO
CREATE PROCEDURE P_PRODUCAO_SERRA_ANALITICO_PERIODO (@P_IDSERRA INT, @P_DTINICIO DATETIME, @P_DTFIM DATETIME)
AS


  IF (@P_IDSERRA = 0 )
  BEGIN

    SELECT
         (CASE
      WHEN ps.IdSerra > 0 THEN CONCAT('Serra ', ps.IdSerra)
    END) AS 'IdSerra',
      ms.CodigoMaterial,
      ms.NomeMaterial,
      ps.DataProducao,
      ps.QuantidadePeca AS 'Peças',
      ps.MetrosQuadrado AS 'M²',
      ps.MetrosCubico AS 'M³',
      ps.TotalUnitario AS 'Reais'

    FROM ProducaoSerra ps
    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    JOIN MaterialSerra ms
      ON ms.IdMaterial = ps.IdMaterial
    WHERE ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
 
  END

  ELSE


  BEGIN
    SELECT
           (CASE
      WHEN ps.IdSerra > 0 THEN CONCAT('Serra ', ps.IdSerra)
    END) AS 'IdSerra',
      ms.CodigoMaterial,
      ms.NomeMaterial,
      ps.DataProducao,
      ps.QuantidadePeca AS 'Peças',
      ps.MetrosQuadrado AS 'M²',
      ps.MetrosCubico AS 'M³',
      ps.TotalUnitario AS 'Reais'

    FROM ProducaoSerra ps
    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    JOIN MaterialSerra ms
      ON ms.IdMaterial = ps.IdMaterial
    WHERE ps.IdSerra = @P_IDSERRA
      AND  ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)

  END
  
GO