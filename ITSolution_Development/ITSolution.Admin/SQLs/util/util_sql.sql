DBCC CHECKIDENT ('Baixa', RESEED, 405);
--update com select
  SELECT * FROM Baixa b
UPDATE Baixa
SET

DataBaixa = lf.DataPagamento,
  ValorBaixa = (lf.ValorLancamento  + lf.ValorJuros)

FROM LancamentoFinanceiro lf 
JOIN Baixa b ON b.IdLancamento = lf.IdLancamento
  


UPDATE ExtratoBancario
SET

IdCentroCusto = lf.IdCentroCusto,
  
  ValorExtrato = (lf.ValorLancamento  + lf.ValorJuros)

FROM LancamentoFinanceiro lf 
JOIN ExtratoBancario eb ON eb.IdLancamento = lf.IdLancamento

  SELECT * FROM LancamentoFinanceiro lf WHERE lf.IdLancamento = 1
SELECT * FROM LancamentoFinanceiro lf WHERE  DATEPART(MONTH, lf.DataLancamento) > 0 and lf.IdCliFor = 3 and lf.TipoLancamento = 1

UPDATE LancamentoFinanceiro SET Observacao = CONCAT('ROMANEIO ', convert(VARCHAR,DataLancamento ,103)) 
  WHERE  DATEPART(MONTH, DataLancamento) = 12 and IdCliFor = 3 and TipoLancamento = 1


 
 --Insere na tabela com PK

 SET IDENTITY_INSERT Produto ON
GO
SET DATEFORMAT ymd
INSERT INTO Produto (IdProduto, CodigoBarras, DescricaoProduto, PrecoCompra, PrecoVenda, QuantidadeProduto, MargemLucro, DataCadastro, StatusProduto, TipoItemProduto, FotoProduto, Observacao, IdCategoriaProduto, IdUnidadeMedidaProduto, IdentificacaoProduto, Comprimento, Largura, Espessura1, Espessura2, Cor, Acabamento, Peso, CodigoNCM)
  VALUES (999, N'999', N'LAJINHA', 0.00, 3000.00, 10000.000, 100.00, '2017-07-13 00:00:00.000', 0, 0, NULL, NULL, 1, 6, N'  ', 0.00, 0.00, 0.00, 0.00, NULL, NULL, 0.00, NULL)
GO
SET IDENTITY_INSERT Produto OFF
GO