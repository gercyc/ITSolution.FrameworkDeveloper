IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_DELETAR_LANCAMENTO%' 
 
) BEGIN

	DROP PROCEDURE P_DELETAR_LANCAMENTO;

END
GO

CREATE PROCEDURE dbo.P_DELETAR_LANCAMENTO (@p_idLancamento INT)
AS
  DELETE FROM AnexoLancamento
  WHERE IdLancamento = @p_idLancamento

  DELETE FROM ExtratoBancario
  WHERE IdLancamento = @p_idLancamento
  
  DELETE FROM Baixa 
  WHERE IdLancamento = @p_idLancamento
  
  DELETE FROM LancamentoFinanceiro
  WHERE IdLancamento = @p_idLancamento


  DECLARE @v_idVenda INT ;
  SET @v_idVenda = (SELECT TOP 1 lf.IdVenda  FROM LancamentoFinanceiro lf
                  WHERE lf.IdLancamento = @P_IDLANCAMENTO)

  --SE O LANÇAMENTO POSSUI VINCULO A UMA VENDA
  IF (@v_idVenda IS NOT NULL)
  BEGIN

    DELETE MovimentoCaixa WHERE IdVenda = @v_idVenda

  END
GO