--https://avila.net.br/2015/02/12/sql-como-adicionar-uma-quebra-de-linha-em-uma-query/
SELECT 'Primeira Linha' + CHAR(13)+CHAR(10) + 'Segunda Linha';

SELECT 'Primeira Linha' + CHAR(10) + 'Segunda Linha';

--CHAR(13) é o equivalente ao CR. Para seguir o estilo CRLF do DOS/Windows, é necessário o CHAR(13)+CHAR(10).