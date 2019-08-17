IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ATUALIZAR_VENDAS%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_ATUALIZAR_VENDAS; 

END

GO


CREATE PROCEDURE dbo.P_ATUALIZAR_VENDAS
AS

  DECLARE @v_idVenda INT,
          @v_idParcela INT,
          @v_dtVencimentoVenda DATETIME,
          @v_dtVencNextParcela DATETIME,
          @v_numParcelas INT,
          @v_statusVenda INT

  DECLARE cVendas CURSOR FOR
  SELECT
    v.IdVenda,
    v.DataVencimento,
    v.NumeroParcelas,
    v.StatusVenda
  FROM Venda v
  WHERE v.NumeroParcelas != 0
  AND v.IdVenda >= 0
  ORDER BY v.DataVenda ASC


  OPEN cVendas
  FETCH NEXT FROM cVendas INTO @v_idVenda, @v_dtVencimentoVenda, @v_numParcelas, @v_statusVenda

  WHILE @@fetch_status = 0

  BEGIN
    --pegar a proxima data de vencimento
    SET @v_dtVencNextParcela = (SELECT
      MIN(p.DataVencimento)
    FROM LancamentoFinanceiro p
    WHERE p.IdVenda = @v_idVenda
    AND p.DataPagamento IS NULL)

    /*Vendas  vencidas ou que nao venceram
    Aberto = 1,
    
    //Parcela nunca poderá ser quitada parcialmente
    Parcial = 2,
    
    //Cancela e ou estornado
    Cancelada = 3,
    
    //Parcela Paga
    
    Paga = 4,
    
    //Vendas com parcela em atraso
    Vencida = 5,
  */
    IF (@v_statusVenda != 3 AND @v_statusVenda != 4)
    BEGIN
      --se tiver valor, atualize a dt vencimento da venda
      IF (@v_dtVencNextParcela IS NOT NULL)
      BEGIN
        UPDATE Venda
        SET DataVencimento = @v_dtVencNextParcela
        WHERE IdVenda = @v_idVenda

        -- se a proxima data de vencimento for menor que datatual, atualize o status pra vencido.
        IF (@v_dtVencNextParcela < GETDATE())
        BEGIN --inif
          UPDATE Venda
          SET StatusVenda = 5
          WHERE IdVenda = @v_idVenda
        END --fim if 
      END

      --se nao tiver valor, todas as parcelas foram pagas, entao atualize a venda com a ultima parcela paga
      IF (@v_dtVencNextParcela IS NULL)
      BEGIN

        IF (@v_numParcelas = (SELECT
            COUNT(1)
          FROM LancamentoFinanceiro p
          WHERE p.IdVenda = @v_idVenda
          AND p.StatusLancamento = 1)
          )
        BEGIN

          SET @v_dtVencNextParcela = (SELECT
            MAX(p.DataVencimento)
          FROM LancamentoFinanceiro p
          WHERE p.IdVenda = @v_idVenda)

          UPDATE Venda
          SET DataVencimento = @v_dtVencNextParcela,
              StatusVenda = 4
          WHERE IdVenda = @v_idVenda

        END
      END
    END
	FETCH NEXT FROM cVendas INTO @v_idVenda, @v_dtVencimentoVenda, @v_numParcelas, @v_statusVenda    
  END

  CLOSE cVendas
  DEALLOCATE cVendas
GO