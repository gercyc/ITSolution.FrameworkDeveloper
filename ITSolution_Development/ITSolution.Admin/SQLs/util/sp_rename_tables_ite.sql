--GERA O SCRIPT COM O ALTER TABLE PARA ALTERAÇÂO DO NOME DAS TABELAS
--REMOÇÂO DO PREFIXO TB DE TODAS AS TABELAS
/*DECLARE @COMANDO VARCHAR(40);
DECLARE @PK VARCHAR(40);

SET @COMANDO = ' EXEC sp_rename ';
-- '''' apos a virgula eh igual ao apostrofe '
-- ''palavra concatena o apostrofe na palavra

--Gera o comando para renomear as tabelas
SELECT

  
  t.name AS 'Table Name',  

    CONCAT(@COMANDO, '''', t.name, '''', ' , ', '''', REPLACE( t.name, 'tb', '' ), '''', ';') AS 'New Table Name'

FROM sys.tables t
WHERE t.name NOT LIKE 'ITS%' */

 EXEC sp_rename 'tbFaixaContribuicaoEncargos' , 'FaixaContribuicaoEncargos';
 EXEC sp_rename 'tbNcms' , 'Ncms';
 EXEC sp_rename 'tbMunicipios' , 'Municipios'; 
 EXEC sp_rename 'tbParametro' , 'Parametro';
 --EXEC sp_rename 'SkinDevExpress' , 'SkinDevExpress';//nao tinha tb mesmo
 EXEC sp_rename 'tbTipoLogradouro' , 'TipoLogradouro';
 EXEC sp_rename 'tbAtendimento' , 'Atendimento';
 EXEC sp_rename 'tbCliFor' , 'CliFor';
 EXEC sp_rename 'tbAtividadePrincipalCliFor' , 'AtividadePrincipalCliFor';
 EXEC sp_rename 'tbAtividadeSecundariaCliFor' , 'AtividadeSecundariaCliFor';
 EXEC sp_rename 'tbCreditoCliente' , 'CreditoCliente';
 EXEC sp_rename 'tbEnderecoCliFor' , 'EnderecoCliFor';
 EXEC sp_rename 'tbLancamentoFinanceiro' , 'LancamentoFinanceiro';
 EXEC sp_rename 'tbAnexoLancamento' , 'AnexoLancamento';
 EXEC sp_rename 'tbBaixa' , 'Baixa';
 --EXEC sp_rename '__MigrationHistory' , '__MigrationHistory';
 EXEC sp_rename 'tbCentroCusto' , 'CentroCusto';
 EXEC sp_rename 'tbExtratoBancario' , 'ExtratoBancario';
 EXEC sp_rename 'tbContaBancaria' , 'ContaBancaria';
 EXEC sp_rename 'tbEmpresaFilial' , 'EmpresaFilial';
 EXEC sp_rename 'tbAtividadePrincipalEmpresaFilial' , 'AtividadePrincipalEmpresaFilial';
 EXEC sp_rename 'tbAtividadeSecundariaEmpresaFilial' , 'AtividadeSecundariaEmpresaFilial';
 EXEC sp_rename 'tbFuncionario' , 'Funcionario';
 EXEC sp_rename 'tbDepartamento' , 'Departamento';
 EXEC sp_rename 'tbHistoricoDepartamento' , 'HistoricoDepartamento';
 EXEC sp_rename 'tbFuncao' , 'Funcao';
 EXEC sp_rename 'tbHistoricoFuncao' , 'HistoricoFuncao';
 EXEC sp_rename 'tbFuncionarioCompetencia' , 'FuncionarioCompetencia';
 EXEC sp_rename 'tbCompetenciaFolha' , 'CompetenciaFolha';
 EXEC sp_rename 'tbUsuario' , 'Usuario';
 EXEC sp_rename 'tbGrupoUsuario' , 'GrupoUsuario';
 EXEC sp_rename 'tbVenda' , 'Venda';
 EXEC sp_rename 'tbFormaPagamento' , 'FormaPagamento';
 EXEC sp_rename 'tbItemVenda' , 'ItemVenda';
 EXEC sp_rename 'tbProduto' , 'Produto';
 EXEC sp_rename 'tbAlteracaoProduto' , 'AlteracaoProduto';
 EXEC sp_rename 'tbCategoriaProduto' , 'CategoriaProduto';
 EXEC sp_rename 'tbItemManutencao' , 'ItemManutencao';
 EXEC sp_rename 'tbManutencao' , 'Manutencao';
 EXEC sp_rename 'tbTipoMovimento' , 'TipoMovimento';
 EXEC sp_rename 'tbComputador' , 'Computador';
 EXEC sp_rename 'tbSistemaOperacional' , 'SistemaOperacional';
 EXEC sp_rename 'tbNotaFiscalItem' , 'NotaFiscalItem';
 EXEC sp_rename 'tbCfops' , 'Cfops';
 EXEC sp_rename 'tbNotaFiscalCapa' , 'NotaFiscalCapa';
 EXEC sp_rename 'tbModeloDocumentoFiscal' , 'ModeloDocumentoFiscal';
 EXEC sp_rename 'tbSituacaoDocumentoFiscal' , 'SituacaoDocumentoFiscal';
 EXEC sp_rename 'tbContaContabil' , 'ContaContabil';
 EXEC sp_rename 'tbTransacoesProduto' , 'TransacoesProduto';
 EXEC sp_rename 'tbLocalEstoque' , 'LocalEstoque';
 EXEC sp_rename 'tbNotaFiscalItemImposto' , 'NotaFiscalItemImposto';
 EXEC sp_rename 'tbSitTribut' , 'SitTribut';
 EXEC sp_rename 'tbTipoImposto' , 'TipoImposto';
 EXEC sp_rename 'tbImpostosRegraFiscal' , 'ImpostosRegraFiscal';
 EXEC sp_rename 'tbRegrasFiscais' , 'RegrasFiscais';
 EXEC sp_rename 'tbUnidadeMedida' , 'UnidadeMedida';
 EXEC sp_rename 'tbMovimentoCaixa' , 'MovimentoCaixa';
 EXEC sp_rename 'tbFichaFinanceiraFuncionario' , 'FichaFinanceiraFuncionario';
 EXEC sp_rename 'tbEvento' , 'Evento';
 EXEC sp_rename 'tbEventosGrupo' , 'EventosGrupo';
 EXEC sp_rename 'tbGrupoEvento' , 'GrupoEvento';
 EXEC sp_rename 'tbHistoricoSalarial' , 'HistoricoSalarial';
 EXEC sp_rename 'tbHistoricoSituacao' , 'HistoricoSituacao';
 EXEC sp_rename 'tbInscricaoStFilial' , 'InscricaoStFilial';
 EXEC sp_rename 'tbUnidadeFederacao' , 'UnidadeFederacao';
 EXEC sp_rename 'tbEmpresaMatriz' , 'EmpresaMatriz';
 EXEC sp_rename 'tbAtividadePrincipalEmpresaMatriz' , 'AtividadePrincipalEmpresaMatriz';
 EXEC sp_rename 'tbAtividadeSecundariaEmpresaMatriz' , 'AtividadeSecundariaEmpresaMatriz';
 