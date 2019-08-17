/**
* Gera um script para recuperar o ultimo valor da pk utilizada na tabela
* Isso foi criado para evitar problema de conflitos na geração da pk da tabela, 
* que é perdida durante o processo de restauração do backup da base de dados.
*
*/

--https://msdn.microsoft.com/pt-br/library/ms188351.aspx
--http://www.devmedia.com.br/describe-e-comments-no-sql-server/19827
DECLARE @COMANDO VARCHAR(40);
DECLARE @PK VARCHAR(40);

--Esse comando recupera o valor pk da tabela 
-- Acontece que o fdp do sql nao salva essa referencia quando um backup eh restaurado
--SELECT IDENT_CURRENT(tablename)

--Recuperar o valor atual da maior pk (identity) da tabela
SET @COMANDO = 'SELECT MAX($IDENTITY) FROM ';
-- '''' apos a virgula eh igual ao apostrofe '
-- ''palavra concatena o apostrofe na palavra
-- 'DECLARE @result INT;'

SELECT
  'DECLARE @result INT;'
UNION ALL

--Gera o comando para renomear as propriedas da tabela
SELECT

  CONCAT('SET @result = (', @COMANDO, t.name, ')',
  --quebra a linha
  CHAR(10),
  'DBCC CHECKIDENT (', '''', t.name, '''', ', RESEED, ', '@result)')
  AS 'New Table Name'


FROM sys.tables t
WHERE
--sem pk  
-- Nao tem identity
t.name <> 'ItemManutencao'
AND t.name <> 'ItemVenda'
AND t.name <> 'NotaFiscalItem'
AND t.name <> 'InscricaoStFilial'
AND t.name <> 'Parametro'
AND t.name <> 'ITS_SCHEDULER_TASK'
AND t.name <> 'ITS_SCHEDULER_LOG'
AND t.name <> 'ITS_PROCESS'
AND t.name <> '__MigrationHistory'

--ORDER BY t.name