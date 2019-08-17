IF OBJECT_ID (N'P_PRODUCAO_MEDIA_SERRA_PERIODO') IS NOT NULL
BEGIN

  DROP PROCEDURE P_PRODUCAO_MEDIA_SERRA_PERIODO;

END
GO
CREATE PROCEDURE P_PRODUCAO_MEDIA_SERRA_PERIODO (@P_IDSERRA INT, @P_DTINICIO DATETIME, @P_DTFIM DATETIME)
AS
   --http://netcoders.com.br/inserindo-retorno-stored-procedure-tabela-sql-server/
  DECLARE @v_dia INT;
  DECLARE @SerraLocal TABLE
  (
  	    Serra VARCHAR(10),
    QuantidadePeca INT,
    MetrosQuadrados DECIMAL(18, 2),
    MetrosCubicos DECIMAL(18, 2),
    TotalUnitario DECIMAL(18, 2)

  );
  

  SET @v_dia = (SELECT
    COUNT(DISTINCT ps.DataProducao)
  FROM ProducaoSerra ps
  WHERE ps.DataProducao BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103))

 
  INSERT INTO @SerraLocal EXEC P_TOTAIS_PRODUCAO_SERRA @P_DTINICIO,
                                                       @P_DTFIM,
                                                       @P_IDSERRA

  SELECT
    m.Serra,
   ROUND(CAST ( (m.TotalUnitario / @v_dia) AS decimal (18,2)),2) AS 'Média Serra'
  FROM @SerraLocal m


  --DROP TABLE @SerraLocal

  
GO

 
 