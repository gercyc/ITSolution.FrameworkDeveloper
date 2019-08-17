--https://msdn.microsoft.com/pt-br/library/ms188351.aspx
--http://www.devmedia.com.br/describe-e-comments-no-sql-server/19827
DECLARE @COMANDO VARCHAR(40);
DECLARE @PK VARCHAR(40);

--NAO FUNCIONA

SET @COMANDO = ' EXEC sp_rename ';
-- '''' apos a virgula eh igual ao apostrofe '
-- ''palavra concatena o apostrofe na palavra

--Gera o comando para renomear as propriedas da tabela
SELECT

  
    --o.name AS 'Table Name',   
    CONCAT(@COMANDO, '''', o.name, '''', ' , ', '''', REPLACE( o.name, 'tb', '' ), '''', ''' , X''', ';') AS 'New Table Name'  
    --o.type_desc  'Type'
  -- SCHEMA_NAME(schema_id) AS 'Schema Name',

FROM sys.objects  o
WHERE o.name NOT LIKE '%ITS%' AND type IN ('C','F', 'PK')
ORDER BY o.name

 