IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ATUALIZAR_LANCAMENTOS%' 
 
) BEGIN

	DROP PROCEDURE P_ATUALIZAR_LANCAMENTOS;

END

GO

CREATE PROCEDURE dbo.P_ATUALIZAR_LANCAMENTOS
AS

  DECLARE @lf_idLancto INT,
          @lf_dtVencimentoLancto DATETIME,
          @lf_dtPagamento DATETIME,
          @lf_status INT


  DECLARE cLancamentos CURSOR FOR
  SELECT
    lf.IdLancamento,
    lf.DataVencimento,
    lf.DataPagamento,
    lf.StatusLancamento
  FROM LancamentoFinanceiro lf
  WHERE lf.DataPagamento IS NULL
  ORDER BY lf.DataVencimento ASC

  OPEN cLancamentos
  FETCH NEXT FROM cLancamentos INTO @lf_idLancto, @lf_dtVencimentoLancto, @lf_dtPagamento, @lf_status

  WHILE @@fetch_status = 0
  BEGIN --inicia o cursor
    --    Aberto = 0,
    --    Pago = 1,
    --    Vencido = 2,
    --    Cancelado = 3,
    --    Parcial = 4,
    --    Atraso = 5,

    --se a data de pagamento eh nula nao foi paga cancelada
    --e o status tem q ser diferente de cancelado
    IF (@lf_dtPagamento IS NULL
      AND @lf_status != 3)
    BEGIN

      --se tiver valor, atualize a dt vencimento da venda
      IF (@lf_dtVencimentoLancto > GETDATE())
      BEGIN
        UPDATE LancamentoFinanceiro
        SET StatusLancamento = 0
        WHERE IdLancamento = @lf_idLancto
      END

      -- se a proxima data de vencimento for menor que datatual, atualize o status pra vencido.
      ELSE
      IF (@lf_dtVencimentoLancto < GETDATE())
      BEGIN --inif
        UPDATE LancamentoFinanceiro
        SET StatusLancamento = 2
        WHERE IdLancamento = @lf_idLancto
      END --fim if 

    END--FIM DA CONDIÇÃO - O Next deve ser fechado por ultimo (AMEM)

    FETCH NEXT FROM cLancamentos INTO @lf_idLancto, @lf_dtVencimentoLancto, @lf_dtPagamento, @lf_status

  END
  CLOSE cLancamentos
  DEALLOCATE cLancamentos
GO