IF OBJECT_ID (N'P_PRODUCAO_SERRA_ANALITICO') IS NOT NULL
BEGIN

  DROP PROCEDURE P_PRODUCAO_SERRA_ANALITICO;

END
GO
CREATE PROCEDURE P_PRODUCAO_SERRA_ANALITICO (@P_MES INT, @P_DIA INT)
AS


  IF (@P_MES = 0
    AND @P_DIA = 0)
  BEGIN

    SELECT
      ps.IdSerra,
      ms.CodigoMaterial,
      ms.NomeMaterial,
      ps.DataProducao,
      ps.QuantidadePeca AS 'Peças',
      ps.MetrosQuadrado AS 'M²',
      ps.MetrosCubico AS 'M³',
      ps.MetrosQuadrado AS 'Reais'

    FROM ProducaoSerra ps
    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    JOIN MaterialSerra ms
      ON ms.IdMaterial = ps.IdMaterial
 
  END

  ELSE


  BEGIN
    SELECT
      ps.IdSerra,
      ms.CodigoMaterial,
      ms.NomeMaterial,
      ps.DataProducao,
      ps.QuantidadePeca AS 'Peças',
      ps.MetrosQuadrado AS 'M²',
      ps.MetrosCubico AS 'M³',
      ps.MetrosQuadrado AS 'Reais'

    FROM ProducaoSerra ps
    JOIN Serra s
      ON s.IdSerra = ps.IdSerra
    JOIN MaterialSerra ms
      ON ms.IdMaterial = ps.IdMaterial
    WHERE DATEPART(MONTH, ps.DataProducao) = @P_MES
    AND DATEPART(DAY, ps.DataProducao) = @P_DIA

  END
  
GO