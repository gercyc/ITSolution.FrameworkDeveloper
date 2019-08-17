--A ORDEM DOS FATORES ALTERA O PRODUTO
--NAO ALTERE A SEQUENCIA DOS COMANDOS

--Base
DELETE FROM EnderecoCliFor ;
DELETE FROM CliFor ;

DBCC CHECKIDENT ('EnderecoCliFor', RESEED, 0)
DBCC CHECKIDENT ('CliFor', RESEED, 0)


--Vendas
DELETE FROM ItemVenda ;
DELETE FROM Venda ;
DELETE FROM Produto ;
DELETE FROM AlteracaoProduto ;
DELETE FROM TransacoesProduto ;
DELETE FROM CreditoCliente ;

DBCC CHECKIDENT ('Venda', RESEED, 0) 
DBCC CHECKIDENT ('Produto', RESEED, 0)
--DBCC CHECKIDENT ('ItemVenda', RESEED, 0)nao tem identity
DBCC CHECKIDENT ('TransacoesProduto', RESEED, 0)
DBCC CHECKIDENT ('AlteracaoProduto', RESEED, 0)
DBCC CHECKIDENT ('CreditoCliente', RESEED, 0)

--RH
DELETE FROM Departamento ;
DELETE FROM Funcao ;
DELETE FROM Funcionario ;
DELETE FROM FuncionarioCompetencia ;
DELETE FROM FichaFinanceiraFuncionario ;
DELETE FROM HistoricoDepartamento ;
DELETE FROM HistoricoFuncao ;
DELETE FROM HistoricoSalarial ;
DELETE FROM HistoricoSituacao ;
DELETE FROM CompetenciaFolha ;

DBCC CHECKIDENT ('Departamento', RESEED, 0)
DBCC CHECKIDENT ('Funcao', RESEED, 0)
DBCC CHECKIDENT ('Funcionario', RESEED, 0)
DBCC CHECKIDENT ('FuncionarioCompetencia', RESEED, 0)
DBCC CHECKIDENT ('HistoricoDepartamento', RESEED, 0)
DBCC CHECKIDENT ('HistoricoFuncao', RESEED, 0)
DBCC CHECKIDENT ('HistoricoSalarial', RESEED, 0)
DBCC CHECKIDENT ('HistoricoSituacao', RESEED, 0)
DBCC CHECKIDENT ('CompetenciaFolha', RESEED, 0)
DBCC CHECKIDENT ('FichaFinanceiraFuncionario', RESEED, 0)



--Financeiro
DELETE FROM LancamentoFinanceiro ;
DELETE FROM Baixa ;
DELETE FROM ContaBancaria ;
DELETE FROM ExtratoBancario ;
DELETE FROM MovimentoCaixa ;

DBCC CHECKIDENT ('LancamentoFinanceiro', RESEED, 0)
DBCC CHECKIDENT ('Baixa', RESEED, 0)
DBCC CHECKIDENT ('ContaBancaria', RESEED, 0)
DBCC CHECKIDENT ('ExtratoBancario', RESEED, 0)
DBCC CHECKIDENT ('MovimentoCaixa', RESEED, 0)


--Fiscal
DELETE FROM NotaFiscalItem ;
DELETE FROM NotaFiscalItemImposto ;
DELETE FROM NotaFiscalCapa ;
DELETE FROM RegrasFiscais ;
DELETE FROM SitTribut ;
DELETE FROM InscricaoStFilial ;

DBCC CHECKIDENT ('NotaFiscalItem', RESEED, 0)
DBCC CHECKIDENT ('NotaFiscalItemImposto', RESEED, 0)
DBCC CHECKIDENT ('NotaFiscalCapa', RESEED, 0)
DBCC CHECKIDENT ('RegrasFiscais', RESEED, 0)
DBCC CHECKIDENT ('SitTribut', RESEED, 0)
--DBCC CHECKIDENT ('InscricaoStFilial', RESEED, 0) nao tem identity






