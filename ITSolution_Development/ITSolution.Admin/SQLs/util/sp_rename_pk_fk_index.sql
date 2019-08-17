 --https://msdn.microsoft.com/pt-br/library/ms188351.aspx
--http://www.devmedia.com.br/describe-e-comments-no-sql-server/19827
DECLARE @COMANDO VARCHAR(40);
DECLARE @PK VARCHAR(40);

SET @COMANDO = ' EXEC sp_rename ';
-- '''' apos a virgula eh igual ao apostrofe '
-- ''palavra concatena o apostrofe na palavra
-- Lista as pk da tabela
--Ae eu teria q fazer um cursor com todos nomes das tabelas etc...
-- select * from sys.foreign_keys where referenced_object_id=OBJECT_ID('myTable') 
--Gera o comando para renomear as propriedas da tabela
SELECT

  --o.name AS 'Table Name',   

  CONCAT(@COMANDO, '@objname = ','''','[', o.name, ']' , '''', ' , ', '', 
  
  CONCAT('@newname = ', '''', REPLACE(o.name, 'tb', '')), 
  '''', ' , ',  '@objtype = ','''', 'object', '''', ';') AS 'New Table Name'
--o.type_desc  'Type'
--SCHEMA_NAME(schema_id) AS 'Schema Name',

FROM sys.objects o
WHERE o.name NOT LIKE '%ITS%'
AND type IN ('C', 'F', 'PK')
ORDER BY o.name 


EXEC sp_rename @objname = '[FK_dbo.tbAlteracaoProduto_dbo.tbProduto_IdProduto]' , @newname = '[FK_dbo.AlteracaoProduto_dbo.Produto_IdProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAnexoLancamento_dbo.tbLancamentoFinanceiro_IdLancamento]' , @newname = '[FK_dbo.AnexoLancamento_dbo.LancamentoFinanceiro_IdLancamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtendimento_dbo.tbCliFor_IdCliente]' , @newname = '[FK_dbo.Atendimento_dbo.CliFor_IdCliente]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadePrincipalCliFor_dbo.tbCliFor_IdCliFor]' , @newname = '[FK_dbo.AtividadePrincipalCliFor_dbo.CliFor_IdCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadePrincipalEmpresaFilial_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.AtividadePrincipalEmpresaFilial_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadePrincipalEmpresaMatriz_dbo.tbEmpresaMatriz_IdMatriz]' , @newname = '[FK_dbo.AtividadePrincipalEmpresaMatriz_dbo.EmpresaMatriz_IdMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadeSecundariaCliFor_dbo.tbCliFor_IdCliFor]' , @newname = '[FK_dbo.AtividadeSecundariaCliFor_dbo.CliFor_IdCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadeSecundariaEmpresaFilial_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.AtividadeSecundariaEmpresaFilial_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbAtividadeSecundariaEmpresaMatriz_dbo.tbEmpresaMatriz_IdMatriz]' , @newname = '[FK_dbo.AtividadeSecundariaEmpresaMatriz_dbo.EmpresaMatriz_IdMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbBaixa_dbo.tbLancamentoFinanceiro_IdLancamento]' , @newname = '[FK_dbo.Baixa_dbo.LancamentoFinanceiro_IdLancamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbCentroCusto_dbo.tbEmpresaMatriz_IdMatriz]' , @newname = '[FK_dbo.CentroCusto_dbo.EmpresaMatriz_IdMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbCompetenciaFolha_dbo.tbUsuario_IdUsuario]' , @newname = '[FK_dbo.CompetenciaFolha_dbo.Usuario_IdUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbComputador_dbo.tbManutencao_IdManutencao]' , @newname = '[FK_dbo.Computador_dbo.Manutencao_IdManutencao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbComputador_dbo.tbSistemaOperacional_IdSistemaOperacional]' , @newname = '[FK_dbo.Computador_dbo.SistemaOperacional_IdSistemaOperacional]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbContaBancaria_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.ContaBancaria_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbCreditoCliente_dbo.tbCliFor_IdCliFor]' , @newname = '[FK_dbo.CreditoCliente_dbo.CliFor_IdCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbEmpresaFilial_dbo.tbEmpresaMatriz_IdEmpresaMatriz]' , @newname = '[FK_dbo.EmpresaFilial_dbo.EmpresaMatriz_IdEmpresaMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbEnderecoCliFor_dbo.tbCliFor_IdCliForEndereco]' , @newname = '[FK_dbo.EnderecoCliFor_dbo.CliFor_IdCliForEndereco]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbEventosGrupo_dbo.tbEvento_IdEvento]' , @newname = '[FK_dbo.EventosGrupo_dbo.Evento_IdEvento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbEventosGrupo_dbo.tbGrupoEvento_IdGrupoEvento]' , @newname = '[FK_dbo.EventosGrupo_dbo.GrupoEvento_IdGrupoEvento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbExtratoBancario_dbo.tbCentroCusto_IdCentroCusto]' , @newname = '[FK_dbo.ExtratoBancario_dbo.CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbExtratoBancario_dbo.tbContaBancaria_IdContaBancaria]' , @newname = '[FK_dbo.ExtratoBancario_dbo.ContaBancaria_IdContaBancaria]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbExtratoBancario_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.ExtratoBancario_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbExtratoBancario_dbo.tbLancamentoFinanceiro_IdLancamento]' , @newname = '[FK_dbo.ExtratoBancario_dbo.LancamentoFinanceiro_IdLancamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFichaFinanceiraFuncionario_dbo.tbEvento_IdEvento]' , @newname = '[FK_dbo.FichaFinanceiraFuncionario_dbo.Evento_IdEvento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFichaFinanceiraFuncionario_dbo.tbFuncionarioCompetencia_IdFuncionarioCompetencia]' , @newname = '[FK_dbo.FichaFinanceiraFuncionario_dbo.FuncionarioCompetencia_IdFuncionarioCompetencia]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFuncionario_dbo.tbDepartamento_IdDepartamento]' , @newname = '[FK_dbo.Funcionario_dbo.Departamento_IdDepartamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFuncionario_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.Funcionario_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFuncionario_dbo.tbFuncao_IdFuncao]' , @newname = '[FK_dbo.Funcionario_dbo.Funcao_IdFuncao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFuncionarioCompetencia_dbo.tbCompetenciaFolha_IdCompetencia]' , @newname = '[FK_dbo.FuncionarioCompetencia_dbo.CompetenciaFolha_IdCompetencia]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbFuncionarioCompetencia_dbo.tbFuncionario_IdFuncionario]' , @newname = '[FK_dbo.FuncionarioCompetencia_dbo.Funcionario_IdFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoDepartamento_dbo.tbDepartamento_IdDepartamento]' , @newname = '[FK_dbo.HistoricoDepartamento_dbo.Departamento_IdDepartamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoDepartamento_dbo.tbFuncionario_IdFuncionario]' , @newname = '[FK_dbo.HistoricoDepartamento_dbo.Funcionario_IdFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoFuncao_dbo.tbFuncao_IdFuncao]' , @newname = '[FK_dbo.HistoricoFuncao_dbo.Funcao_IdFuncao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoFuncao_dbo.tbFuncionario_IdFuncionario]' , @newname = '[FK_dbo.HistoricoFuncao_dbo.Funcionario_IdFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoSalarial_dbo.tbFuncionario_IdFuncionario]' , @newname = '[FK_dbo.HistoricoSalarial_dbo.Funcionario_IdFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoSituacao_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.HistoricoSituacao_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbHistoricoSituacao_dbo.tbFuncionario_IdFuncionario]' , @newname = '[FK_dbo.HistoricoSituacao_dbo.Funcionario_IdFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbImpostosRegraFiscal_dbo.tbRegrasFiscais_IdRegraFiscal]' , @newname = '[FK_dbo.ImpostosRegraFiscal_dbo.RegrasFiscais_IdRegraFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbImpostosRegraFiscal_dbo.tbSitTribut_IdCst]' , @newname = '[FK_dbo.ImpostosRegraFiscal_dbo.SitTribut_IdCst]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbImpostosRegraFiscal_dbo.tbTipoImposto_IdImposto]' , @newname = '[FK_dbo.ImpostosRegraFiscal_dbo.TipoImposto_IdImposto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbInscricaoStFilial_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.InscricaoStFilial_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbInscricaoStFilial_dbo.tbUnidadeFederacao_IdUf]' , @newname = '[FK_dbo.InscricaoStFilial_dbo.UnidadeFederacao_IdUf]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbItemManutencao_dbo.tbManutencao_IdManutencao]' , @newname = '[FK_dbo.ItemManutencao_dbo.Manutencao_IdManutencao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbItemManutencao_dbo.tbProduto_IdProdutoManutencao]' , @newname = '[FK_dbo.ItemManutencao_dbo.Produto_IdProdutoManutencao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbItemVenda_dbo.tbProduto_IdProdutoItem]' , @newname = '[FK_dbo.ItemVenda_dbo.Produto_IdProdutoItem]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbItemVenda_dbo.tbVenda_IdVendaItem]' , @newname = '[FK_dbo.ItemVenda_dbo.Venda_IdVendaItem]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbCentroCusto_IdCentroCusto]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbCliFor_IdCliFor]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.CliFor_IdCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbFormaPagamento_IdFormaPagamento]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.FormaPagamento_IdFormaPagamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbNotaFiscalCapa_IdNotaFiscal]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.NotaFiscalCapa_IdNotaFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbUsuario_RecCreatedBy]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.Usuario_RecCreatedBy]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbUsuario_RecModifyBy]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.Usuario_RecModifyBy]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLancamentoFinanceiro_dbo.tbVenda_IdVenda]' , @newname = '[FK_dbo.LancamentoFinanceiro_dbo.Venda_IdVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbLocalEstoque_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.LocalEstoque_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbManutencao_dbo.tbAtendimento_IdAtendimento]' , @newname = '[FK_dbo.Manutencao_dbo.Atendimento_IdAtendimento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbManutencao_dbo.tbCentroCusto_IdCentroCusto]' , @newname = '[FK_dbo.Manutencao_dbo.CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbManutencao_dbo.tbCliFor_IdCliente]' , @newname = '[FK_dbo.Manutencao_dbo.CliFor_IdCliente]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbManutencao_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.Manutencao_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbMovimentoCaixa_dbo.tbUsuario_IdUsuario]' , @newname = '[FK_dbo.MovimentoCaixa_dbo.Usuario_IdUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbMovimentoCaixa_dbo.tbVenda_IdVendaCaixa]' , @newname = '[FK_dbo.MovimentoCaixa_dbo.Venda_IdVendaCaixa]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbMunicipios_dbo.tbUnidadeFederacao_IdUF]' , @newname = '[FK_dbo.Municipios_dbo.UnidadeFederacao_IdUF]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbCentroCusto_IdCentroCusto]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbCliFor_IdCliFor]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.CliFor_IdCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbFormaPagamento_IdFormaPagamento]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.FormaPagamento_IdFormaPagamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbModeloDocumentoFiscal_IdModelo]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.ModeloDocumentoFiscal_IdModelo]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbSituacaoDocumentoFiscal_IdSituacao]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.SituacaoDocumentoFiscal_IdSituacao]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalCapa_dbo.tbUsuario_IdUsuario]' , @newname = '[FK_dbo.NotaFiscalCapa_dbo.Usuario_IdUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItem_dbo.tbCfops_IdCfop]' , @newname = '[FK_dbo.NotaFiscalItem_dbo.Cfops_IdCfop]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItem_dbo.tbNotaFiscalCapa_IdCapa]' , @newname = '[FK_dbo.NotaFiscalItem_dbo.NotaFiscalCapa_IdCapa]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItem_dbo.tbProduto_IdProduto]' , @newname = '[FK_dbo.NotaFiscalItem_dbo.Produto_IdProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItem_dbo.tbRegrasFiscais_IdRegraFiscal]' , @newname = '[FK_dbo.NotaFiscalItem_dbo.RegrasFiscais_IdRegraFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItemImposto_dbo.tbNotaFiscalItem_IdItem]' , @newname = '[FK_dbo.NotaFiscalItemImposto_dbo.NotaFiscalItem_IdItem]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItemImposto_dbo.tbSitTribut_IdCst]' , @newname = '[FK_dbo.NotaFiscalItemImposto_dbo.SitTribut_IdCst]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbNotaFiscalItemImposto_dbo.tbTipoImposto_IdImposto]' , @newname = '[FK_dbo.NotaFiscalItemImposto_dbo.TipoImposto_IdImposto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbProduto_dbo.tbCategoriaProduto_IdCategoriaProduto]' , @newname = '[FK_dbo.Produto_dbo.CategoriaProduto_IdCategoriaProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbProduto_dbo.tbUnidadeMedida_IdUnidadeMedidaProduto]' , @newname = '[FK_dbo.Produto_dbo.UnidadeMedida_IdUnidadeMedidaProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbSitTribut_dbo.tbTipoImposto_IdImposto]' , @newname = '[FK_dbo.SitTribut_dbo.TipoImposto_IdImposto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbTransacoesProduto_dbo.tbLocalEstoque_IdLocalEstoque]' , @newname = '[FK_dbo.TransacoesProduto_dbo.LocalEstoque_IdLocalEstoque]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbTransacoesProduto_dbo.tbNotaFiscalCapa_IdNotaFiscal]' , @newname = '[FK_dbo.TransacoesProduto_dbo.NotaFiscalCapa_IdNotaFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbTransacoesProduto_dbo.tbProduto_IdProduto]' , @newname = '[FK_dbo.TransacoesProduto_dbo.Produto_IdProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbTransacoesProduto_dbo.tbUsuario_IdUsuario]' , @newname = '[FK_dbo.TransacoesProduto_dbo.Usuario_IdUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbTransacoesProduto_dbo.tbVenda_IdVenda]' , @newname = '[FK_dbo.TransacoesProduto_dbo.Venda_IdVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbUsuario_dbo.tbGrupoUsuario_IdGrupoUsuario]' , @newname = '[FK_dbo.Usuario_dbo.GrupoUsuario_IdGrupoUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbVenda_dbo.tbCentroCusto_IdCentroCusto]' , @newname = '[FK_dbo.Venda_dbo.CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbVenda_dbo.tbCliFor_IdCliForVenda]' , @newname = '[FK_dbo.Venda_dbo.CliFor_IdCliForVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbVenda_dbo.tbEmpresaFilial_IdFilial]' , @newname = '[FK_dbo.Venda_dbo.EmpresaFilial_IdFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbVenda_dbo.tbFormaPagamento_IdFormaPagamentoVenda]' , @newname = '[FK_dbo.Venda_dbo.FormaPagamento_IdFormaPagamentoVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_dbo.tbVenda_dbo.tbUsuario_IdUsuarioVenda]' , @newname = '[FK_dbo.Venda_dbo.Usuario_IdUsuarioVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbContaContabil_tbEmpresaMatriz_IdEmpresaMatriz]' , @newname = '[FK_ContaContabil_EmpresaMatriz_IdEmpresaMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbGrupoUsuarioRelationRules_tbGrupoUsuario_IdGrupoUsuario]' , @newname = '[FK_GrupoUsuarioRelationRules_GrupoUsuario_IdGrupoUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbGrupoUsuarioRelationRules_tbRegras_IdRegra]' , @newname = '[FK_GrupoUsuarioRelationRules_Regras_IdRegra]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbTipoMovimento_tbCentroCusto_IdCentroCusto]' , @newname = '[FK_TipoMovimento_CentroCusto_IdCentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbTipoMovimento_tbFormaPagamento_IdFormaPagamento]' , @newname = '[FK_TipoMovimento_FormaPagamento_IdFormaPagamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[FK_tbTipoMovimento_tbLocalEstoque_IdLocalEstoque]' , @newname = '[FK_TipoMovimento_LocalEstoque_IdLocalEstoque]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.__MigrationHistory]' , @newname = '[PK_dbo.__MigrationHistory]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.SkinDevExpress]' , @newname = '[PK_dbo.SkinDevExpress]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAlteracaoProduto]' , @newname = '[PK_dbo.AlteracaoProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAnexoLancamento]' , @newname = '[PK_dbo.AnexoLancamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtendimento]' , @newname = '[PK_dbo.Atendimento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadePrincipalCliFor]' , @newname = '[PK_dbo.AtividadePrincipalCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadePrincipalEmpresaFilial]' , @newname = '[PK_dbo.AtividadePrincipalEmpresaFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadePrincipalEmpresaMatriz]' , @newname = '[PK_dbo.AtividadePrincipalEmpresaMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadeSecundariaCliFor]' , @newname = '[PK_dbo.AtividadeSecundariaCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadeSecundariaEmpresaFilial]' , @newname = '[PK_dbo.AtividadeSecundariaEmpresaFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbAtividadeSecundariaEmpresaMatriz]' , @newname = '[PK_dbo.AtividadeSecundariaEmpresaMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbBaixa]' , @newname = '[PK_dbo.Baixa]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCategoriaProduto]' , @newname = '[PK_dbo.CategoriaProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCentroCusto]' , @newname = '[PK_dbo.CentroCusto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCfops]' , @newname = '[PK_dbo.Cfops]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCliFor]' , @newname = '[PK_dbo.CliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCompetenciaFolha]' , @newname = '[PK_dbo.CompetenciaFolha]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbComputador]' , @newname = '[PK_dbo.Computador]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbContaBancaria]' , @newname = '[PK_dbo.ContaBancaria]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbContaContabil]' , @newname = '[PK_dbo.ContaContabil]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbCreditoCliente]' , @newname = '[PK_dbo.CreditoCliente]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbDepartamento]' , @newname = '[PK_dbo.Departamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbEmpresaFilial]' , @newname = '[PK_dbo.EmpresaFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbEmpresaMatriz]' , @newname = '[PK_dbo.EmpresaMatriz]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbEnderecoCliFor]' , @newname = '[PK_dbo.EnderecoCliFor]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbEvento]' , @newname = '[PK_dbo.Evento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbEventosGrupo]' , @newname = '[PK_dbo.EventosGrupo]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbExtratoBancario]' , @newname = '[PK_dbo.ExtratoBancario]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFaixaContribuicaoEncargos]' , @newname = '[PK_dbo.FaixaContribuicaoEncargos]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFichaFinanceiraFuncionario]' , @newname = '[PK_dbo.FichaFinanceiraFuncionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFormaPagamento]' , @newname = '[PK_dbo.FormaPagamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFuncao]' , @newname = '[PK_dbo.Funcao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFuncionario]' , @newname = '[PK_dbo.Funcionario]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbFuncionarioCompetencia]' , @newname = '[PK_dbo.FuncionarioCompetencia]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbGrupoEvento]' , @newname = '[PK_dbo.GrupoEvento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbGrupoUsuario]' , @newname = '[PK_dbo.GrupoUsuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbHistoricoDepartamento]' , @newname = '[PK_dbo.HistoricoDepartamento]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbHistoricoFuncao]' , @newname = '[PK_dbo.HistoricoFuncao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbHistoricoSalarial]' , @newname = '[PK_dbo.HistoricoSalarial]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbHistoricoSituacao]' , @newname = '[PK_dbo.HistoricoSituacao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbImpostosRegraFiscal]' , @newname = '[PK_dbo.ImpostosRegraFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbInscricaoStFilial]' , @newname = '[PK_dbo.InscricaoStFilial]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbItemManutencao]' , @newname = '[PK_dbo.ItemManutencao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbItemVenda]' , @newname = '[PK_dbo.ItemVenda]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbLancamentoFinanceiro]' , @newname = '[PK_dbo.LancamentoFinanceiro]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbLocalEstoque]' , @newname = '[PK_dbo.LocalEstoque]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbManutencao]' , @newname = '[PK_dbo.Manutencao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbModeloDocumentoFiscal]' , @newname = '[PK_dbo.ModeloDocumentoFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbMovimentoCaixa]' , @newname = '[PK_dbo.MovimentoCaixa]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbMunicipios]' , @newname = '[PK_dbo.Municipios]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbNcms]' , @newname = '[PK_dbo.Ncms]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbNotaFiscalCapa]' , @newname = '[PK_dbo.NotaFiscalCapa]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbNotaFiscalItem]' , @newname = '[PK_dbo.NotaFiscalItem]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbNotaFiscalItemImposto]' , @newname = '[PK_dbo.NotaFiscalItemImposto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbParametro]' , @newname = '[PK_dbo.Parametro]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbProduto]' , @newname = '[PK_dbo.Produto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbRegrasFiscais]' , @newname = '[PK_dbo.RegrasFiscais]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbSistemaOperacional]' , @newname = '[PK_dbo.SistemaOperacional]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbSitTribut]' , @newname = '[PK_dbo.SitTribut]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbSituacaoDocumentoFiscal]' , @newname = '[PK_dbo.SituacaoDocumentoFiscal]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbTipoImposto]' , @newname = '[PK_dbo.TipoImposto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbTipoLogradouro]' , @newname = '[PK_dbo.TipoLogradouro]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbTransacoesProduto]' , @newname = '[PK_dbo.TransacoesProduto]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbUnidadeFederacao]' , @newname = '[PK_dbo.UnidadeFederacao]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbUnidadeMedida]' , @newname = '[PK_dbo.UnidadeMedida]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbUsuario]' , @newname = '[PK_dbo.Usuario]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_dbo.tbVenda]' , @newname = '[PK_dbo.Venda]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_tbGrupoUsuarioRelationRules]' , @newname = '[PK_GrupoUsuarioRelationRules]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_tbRegras]' , @newname = '[PK_Regras]' , @objtype = 'object';
EXEC sp_rename @objname = '[PK_tbTipoMovimento]' , @newname = '[PK_TipoMovimento]' , @objtype = 'object';
