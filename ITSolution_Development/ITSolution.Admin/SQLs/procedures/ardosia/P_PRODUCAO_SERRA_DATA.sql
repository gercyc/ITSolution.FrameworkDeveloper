IF OBJECT_ID (N'P_PRODUCAO_SERRA_DATA') IS NOT NULL
BEGIN

  DROP PROCEDURE P_PRODUCAO_SERRA_DATA;

END
GO
CREATE PROCEDURE P_PRODUCAO_SERRA_DATA (@P_IDSERRA INT, @P_DATA DATETIME)
AS


  IF (@P_IDSERRA = 0)
  BEGIN
    SELECT
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE ps.DataProducao = CONVERT(DATETIME, @P_DATA, 103)
    GROUP BY s.IdSerra

  END

  ELSE

  BEGIN
    SELECT
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE ps.DataProducao = CONVERT(DATETIME, @P_DATA, 103)
    AND ps.IdSerra = @P_IDSERRA
group BY ps.DataProducao
      ORDER BY ps.DataProducao

  END
  
GO