DECLARE @COMANDO VARCHAR(40) ;

SET @COMANDO = 'DELETE FROM ';

SELECT

  CONCAT(@COMANDO, t.name, ' ;') AS 'RESULT'

FROM sys.tables t
WHERE t.name NOT LIKE 'ITS%'

AND t.name <> 'Cfops'
AND t.name <> 'TipoImposto'
AND t.name <> 'TipoLogradouro'
AND t.name <> 'UnidadeFederacao'
AND t.name <> 'Municipios' 
AND t.name <> 'ModeloDocumentoFiscal'
AND t.name <> 'ImpostosRegraFiscal'
AND t.name <> 'FaixaContribuicaoEncargos'
AND t.name <> 'SituacaoDocumentoFiscal'

AND t.name <> 'EmpresaMatriz'
AND t.name <> 'EmpresaFilial'
AND t.name <> 'CentroCusto'
AND t.name <> 'UnidadeMedida'
AND t.name <> 'LocaisEstoque'
AND t.name <> 'Usuario'
AND t.name <> 'GrupoUsuario'
AND t.name <> 'FormaPagamento'
AND t.name <> 'Parametro'
AND t.name <> 'GrupoEvento'
AND t.name <> 'SitTribut'
AND t.name <> 'CategoriaProduto' --ordenar as sequencia
AND t.name <> 'EventosGrupo' --ordenar sequencia
AND t.name <> 'Evento' --ordenar sequencia
AND t.name <> 'GrupoEvento' --ordenar sequencia
AND t.name <> 'sysdiagrams' ORDER BY t.name
