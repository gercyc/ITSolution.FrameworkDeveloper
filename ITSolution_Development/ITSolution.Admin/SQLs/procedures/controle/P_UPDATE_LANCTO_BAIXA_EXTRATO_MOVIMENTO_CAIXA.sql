IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_UPDATE_LANCTO_BAIXA_EXTRATO_MOVIMENTO_CAIXA%' 
 
) BEGIN

	DROP PROCEDURE P_UPDATE_LANCTO_BAIXA_EXTRATO_MOVIMENTO_CAIXA; 

END
GO
CREATE PROCEDURE dbo.P_UPDATE_LANCTO_BAIXA_EXTRATO_MOVIMENTO_CAIXA (@P_IDLANCAMENTO INT, @P_VALOR DECIMAL(18, 2))
AS

  DECLARE @v_idVenda INT;
  SET @v_idVenda = (SELECT TOP 1
    lf.IdVenda
  FROM LancamentoFinanceiro lf
  WHERE lf.IdLancamento = @P_IDLANCAMENTO)

  --ESSE EH O CARRO CHEFE DA PROCEDURE
  UPDATE LancamentoFinanceiro
  SET ValorLancamento = @P_VALOR
  WHERE IdLancamento = @P_IDLANCAMENTO;

  --BAIXA
  UPDATE Baixa
  SET DataBaixa = lf.DataPagamento,
      ValorBaixa = (lf.ValorLancamento + lf.ValorJuros)

  FROM LancamentoFinanceiro lf
  JOIN Baixa b
    ON b.IdLancamento = lf.IdLancamento
  WHERE b.IdLancamento = @P_IDLANCAMENTO;

  --EXTRATO

  UPDATE ExtratoBancario
  SET IdCentroCusto = lf.IdCentroCusto,
      ValorExtrato = (lf.ValorLancamento + lf.ValorJuros) * -1
  FROM LancamentoFinanceiro lf
  JOIN ExtratoBancario eb
    ON eb.IdLancamento = lf.IdLancamento


  --SE O LANÇAMENTO POSSUI VINCULO A UMA VENDA
  IF (@v_idVenda IS NOT NULL)
  BEGIN

    UPDATE MovimentoCaixa
    SET MovimentoCaixa.ValorMovimento = (SELECT
      SUM(lf.ValorLancamento + lf.ValorJuros)
    FROM LancamentoFinanceiro lf
    WHERE lf.IdVenda = @v_idVenda)
    WHERE IdVenda = @v_idVenda

  END


  
GO