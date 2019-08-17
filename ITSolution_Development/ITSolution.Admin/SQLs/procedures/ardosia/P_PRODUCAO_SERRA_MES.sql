IF OBJECT_ID (N'P_PRODUCAO_SERRA_MES') IS NOT NULL
BEGIN

  DROP PROCEDURE P_PRODUCAO_SERRA_MES;

END
GO
CREATE PROCEDURE P_PRODUCAO_SERRA_MES (@P_IDSERRA INT, @P_MES INT)
AS

  IF (@P_IDSERRA = 0)
  BEGIN
    SELECT
      s.IdSerra,
      ps.DataProducao,
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE DATEPART(MONTH, ps.DataProducao) = @P_MES
    --todas as serras
    GROUP BY s.IdSerra,
             ps.DataProducao

  END

  ELSE
  BEGIN
    SELECT
      s.IdSerra,
      ps.DataProducao,
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE DATEPART(MONTH, ps.DataProducao) = @P_MES

    AND ps.IdSerra = @P_IDSERRA
    GROUP BY s.IdSerra,
             ps.DataProducao


  END

  
GO