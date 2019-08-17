IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_PRODUCAO_SERRA_PERIODO%' 
 
) BEGIN

	DROP PROCEDURE P_PRODUCAO_SERRA_PERIODO; 

END
GO
CREATE PROCEDURE dbo.P_PRODUCAO_SERRA_PERIODO (@P_IDSERRA INT, @P_DTINICIO DATETIME, @P_DTFIM DATETIME)
AS


  IF (@P_IDSERRA = 0)
  BEGIN
    SELECT
      SUM(ps.ValorUnitario) AS 'Total R$',
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'      
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
    GROUP BY s.IdSerra

  END

  ELSE

  BEGIN
    SELECT
      SUM(ps.ValorUnitario) AS 'Total R$',
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
      
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
    AND ps.IdSerra = @P_IDSERRA
    GROUP BY ps.DataProducao
    ORDER BY ps.DataProducao

  END

  
GO