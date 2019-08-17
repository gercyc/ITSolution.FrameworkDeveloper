EXEC sp_rename 'Produto.ItentificacaoProduto'
              ,'IdentificacaoProduto'
              ,'COLUMN';
GO
UPDATE Produto
SET IdentificacaoProduto = '  '
WHERE IdentificacaoProduto IS NULL