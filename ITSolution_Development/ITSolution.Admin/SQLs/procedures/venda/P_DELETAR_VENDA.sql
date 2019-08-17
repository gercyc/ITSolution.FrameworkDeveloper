IF EXISTS (SELECT
    ROUTINE_SCHEMA,
    ROUTINE_NAME
  FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_DEFINITION LIKE '%P_DELETAR_VENDA%')
BEGIN

  DROP PROCEDURE dbo.P_DELETAR_VENDA;

END

GO

CREATE PROCEDURE dbo.P_DELETAR_VENDA (@p_idVenda INT)
AS
  DELETE FROM TransacoesProduto
  WHERE IdVenda = @p_idVenda

  DELETE FROM MovimentoCaixa
  WHERE IdVenda = @p_idVenda

  DELETE AnexoLancamento
  WHERE IdLancamento IN (SELECT
        IdLancamento
      FROM LancamentoFinanceiro
      WHERE IdVenda = @p_idVenda)

  DELETE FROM ExtratoBancario
  WHERE IdLancamento IN (SELECT
        IdLancamento
      FROM LancamentoFinanceiro
      WHERE IdVenda = @p_idVenda)
  
  DELETE FROM Baixa 
  WHERE IdLancamento IN (SELECT
        IdLancamento
      FROM LancamentoFinanceiro
      WHERE IdVenda = @p_idVenda)  

  DELETE FROM LancamentoFinanceiro
  WHERE IdVenda = @p_idVenda

  
  DELETE FROM ItemVenda
  WHERE IdVenda = @p_idVenda

  --agora sim o cabeça
  DELETE FROM Venda
  WHERE IdVenda = @p_idVenda

GO