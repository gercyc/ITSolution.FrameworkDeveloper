IF OBJECT_ID (N'P_PRODUCAO_SERRA_MES_DIA') IS NOT NULL
BEGIN

  DROP PROCEDURE P_PRODUCAO_SERRA_MES_DIA;

END
GO
CREATE PROCEDURE P_PRODUCAO_SERRA_MES_DIA (@P_IDSERRA INT, @P_MES INT, @P_DIA INT)
AS

  IF (@P_IDSERRA = 0)
  BEGIN
    SELECT
      SUM(ps.MetrosQuadrado) AS 'Metros Quadrados',
      SUM(ps.MetrosCubico) AS 'Metros Cúbicos'
    FROM ProducaoSerra ps

    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    WHERE DATEPART(MONTH, ps.DataProducao) = @P_MES
    AND DATEPART(DAY, ps.DataProducao) = @P_DIA

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
    WHERE DATEPART(MONTH, ps.DataProducao) = @P_MES
    AND DATEPART(DAY, ps.DataProducao) = @P_DIA
    AND ps.IdSerra = @P_IDSERRA
    GROUP BY s.IdSerra


  END
  
GO