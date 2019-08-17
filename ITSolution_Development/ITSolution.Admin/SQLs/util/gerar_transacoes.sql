/*
Data: 18/01/2017
Desenvolvedor: Gercy Campos
Objetivo: Gerar as transações dos produtos para movimentação de estoque
*/

DECLARE
  @v_idVenda INT,
  @v_idProduto INT,
  @v_dtVenda datetime,
  @v_tipo INT,
  @v_vlrUnitario DECIMAL(18,2),
  @v_quantidade DECIMAL(18,3),
  @v_vlrTotal DECIMAL(18,2),
  @v_idLocalEstoque INT;


DECLARE cNotas CURSOR FOR

--selecionar somente notas que não possuem movimentação
--e tambem selecionar somente quando o flag 'MovimentaEstoque' da regra fiscal estiver marcado
SELECT 
  nfc.IdCapa, 
  nfi.IdProduto,
  nfc.DataEntrada,
  IIF(nfc.TipoNf = 'E', 1, 2) "TipoTRA. 1 = Entrada, 2 = Saida",
  nfi.ValorUnitario,
  nfi.Quantidade,
  1 "LocalEstoque",
  nfi.TotalItem
  FROM NotaFiscalCapa nfc
  JOIN NotaFiscalItem nfi ON nfc.IdCapa = nfi.IdCapa
  JOIN RegrasFiscais rf ON nfi.IdRegraFiscal = rf.IdRegraFiscal
  WHERE NOT EXISTS (SELECT 1 FROM TransacoesProduto tp WHERE tp.IdNotaFiscal = nfc.IdCapa)
  AND rf.MovimentaEstoque = 1


DECLARE cVendas CURSOR FOR
--selecionar somente vendas que não possuem movimentação
--e tambem selecionar somente quando o flag 'TipoItemProduto' do Produto for igual a 0 (Produto)
SELECT 
  v.IdVenda,
  iv.IdProdutoItem,
  v.DataVenda, 
  2 "TipoTRA. 1 = Entrada, 2 = Saida",
  iv.ValorUnitario, 
  iv.Quantidade, 
  1 "LocalEstoque",
  iv.TotalItem
  FROM Venda v
  JOIN ItemVenda iv ON v.IdVenda = iv.IdVendaItem
  JOIN Produto p ON iv.IdProdutoItem = p.IdProduto
  WHERE NOT EXISTS (SELECT 1 FROM TransacoesProduto tp WHERE tp.IdVenda = v.IdVenda)
  AND p.TipoItemProduto = 0 --somente 'Produto'
ORDER BY v.DataVenda ASC;

OPEN cNotas;
FETCH NEXT FROM cNotas INTO @v_idVenda, @v_idProduto, @v_dtVenda, @v_tipo, @v_vlrUnitario, @v_quantidade, @v_idLocalEstoque, @v_vlrTotal;

WHILE @@fetch_status = 0
  BEGIN
    INSERT
       INTO TransacoesProduto 
          (
          DataTransacao, 
          TipoTransacao, 
          ValorUnitario, 
          ValorTotal, 
          Quantidade, 
          Observacao, 
          IdProduto, 
          IdNotaFiscal, 
          IdVenda, 
          IdUsuario, 
          IdLocalEstoque
          )
       VALUES 
          (
          @v_dtVenda, 
          @v_tipo, 
          @v_vlrUnitario, 
          @v_vlrTotal,
          @v_quantidade, 
          'Transalçao T-SQL | NF: ' + CONVERT(VARCHAR(MAX), @v_idVenda), 
          @v_idProduto, 
          @v_idVenda, 
          NULL, 
          null, 
          @v_idLocalEstoque);
    FETCH NEXT FROM cNotas INTO @v_idVenda, @v_idProduto, @v_dtVenda, @v_tipo, @v_vlrUnitario, @v_quantidade, @v_idLocalEstoque, @v_vlrTotal;
  END
CLOSE cNotas;
DEALLOCATE cNotas;


OPEN cVendas;

FETCH NEXT FROM cVendas INTO @v_idVenda, @v_idProduto, @v_dtVenda, @v_tipo, @v_vlrUnitario, @v_quantidade, @v_idLocalEstoque, @v_vlrTotal

WHILE @@fetch_status = 0
  BEGIN
    
    INSERT
       INTO TransacoesProduto 
          (
          DataTransacao, 
          TipoTransacao, 
          ValorUnitario, 
          ValorTotal, 
          Quantidade, 
          Observacao, 
          IdProduto, 
          IdNotaFiscal, 
          IdVenda, 
          IdUsuario, 
          IdLocalEstoque
          )
       VALUES 
          (
          @v_dtVenda, 
          @v_tipo, 
          @v_vlrUnitario, 
          @v_vlrUnitario * @v_quantidade,
          @v_quantidade, 
          'Transalçao T-SQL | Venda: ' + CONVERT(VARCHAR(MAX), @v_idVenda), 
          @v_idProduto, 
          NULL, 
          @v_idVenda, 
          null, 
          @v_idLocalEstoque);

    FETCH NEXT FROM cVendas INTO @v_idVenda, @v_idProduto, @v_dtVenda, @v_tipo, @v_vlrUnitario, @v_quantidade, @v_idLocalEstoque, @v_vlrTotal;
  END


CLOSE cVendas;
DEALLOCATE cVendas;

