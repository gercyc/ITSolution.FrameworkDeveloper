IF EXISTS (SELECT
    ROUTINE_SCHEMA,
    ROUTINE_NAME
  FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_DEFINITION LIKE '%P_CENTRO_CUSTO_ANALITICO%')
BEGIN

  DROP PROCEDURE dbo.P_CENTRO_CUSTO_ANALITICO;

END

GO



CREATE PROCEDURE dbo.P_CENTRO_CUSTO_ANALITICO (
--Periodo
@P_DTINICIO DATETIME, @P_DTFIM DATETIME,
-- Tipo Lançamento
@P_TIPOLANCAMENTO VARCHAR(2),
--ID do Cliente
@P_IDCLIENTE VARCHAR(40),
-- Status do lançamento
@P_STATUS VARCHAR(2),
-- Codigo do centro de custo
@P_IDCENTROCUSTO VARCHAR(10))
AS
  -- IdCliente = 0 Todos os clientes

  -- Contas a Pagar = 0,
  -- Contas a Receber = 1,
  -- Pagar e Receber = 2 

  -- Aberto = 0,  
  -- Pago = 1, 
  -- Vencido = 2,  
  -- Cancelado = 3,  
  -- Pendentes => Aberto/Vencidos = 4
  -- Todos = 5

  IF (@P_STATUS != '4')
  BEGIN
    SELECT
      (CASE
        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento > GETDATE() THEN 'Aberto'

        WHEN lf.DataPagamento IS NOT NULL AND
          lf.StatusLancamento <> 3 AND
          lf.TipoLancamento = 0 THEN 'Pago'

        WHEN lf.DataPagamento IS NOT NULL AND
          lf.StatusLancamento <> 3 AND
          lf.TipoLancamento = 1 THEN 'Recebido'

        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento < GETDATE() THEN 'Vencido'
        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento = GETDATE() THEN 'Vencendo hoje'
        WHEN lf.StatusLancamento = 3 THEN 'Cancelado'
      -- ELSE
      END) AS Situação,

      (CASE lf.TipoLancamento
        WHEN 0 THEN 'Pagar'
        WHEN 1 THEN 'Receber'
      -- ELSE
      END) AS "Tipo",
      (CONVERT(VARCHAR, ISNULL(lf.IdVenda, lf.IdLancamento)) + '-' + CONVERT(VARCHAR, lf.SequencialParcela)) AS 'Numero',
      lf.IdVenda,
      lf.SequencialParcela,
      lf.DataLancamento,
      lf.DataVencimento,
      lf.DataPagamento,
      lf.Observacao,
      (lf.ValorLancamento + lf.ValorJuros) AS 'Total',
      cf.RazaoSocial,
      cc.NomeCentroCusto,
      cc.CodigoCentroCusto
    FROM LancamentoFinanceiro lf
    JOIN CliFor cf
      ON lf.IdCliFor = cf.IdCliFor
    JOIN EmpresaFilial ef
      ON lf.IdFilial = ef.IdFilial
    JOIN CentroCusto cc
      ON lf.IdCentroCusto = cc.IdCentroCusto

    WHERE lf.DataVencimento BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
    AND lf.TipoLancamento LIKE IIF(@P_TIPOLANCAMENTO = '2', '%', @P_TIPOLANCAMENTO)
    AND cf.IdCliFor LIKE IIF(@P_IDCLIENTE = '0', '%', @P_IDCLIENTE)
    AND lf.StatusLancamento LIKE IIF(@P_STATUS = '5', '%', @P_STATUS)
    AND cc.IdCentroCusto LIKE IIF(@P_IDCENTROCUSTO = '0', '%', @P_IDCENTROCUSTO)
    ORDER BY cf.RazaoSocial ASC

  END

  --LANÇAMENTOS ABERTOS E VENCIDOS
  ELSE
  BEGIN
    SELECT
      (CASE
        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento > GETDATE() THEN 'Aberto'

        WHEN lf.DataPagamento IS NOT NULL AND
          lf.StatusLancamento <> 3 AND
          lf.TipoLancamento = 0 THEN 'Pago'

        WHEN lf.DataPagamento IS NOT NULL AND
          lf.StatusLancamento <> 3 AND
          lf.TipoLancamento = 1 THEN 'Recebido'

        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento < GETDATE() THEN 'Vencido'
        WHEN lf.DataPagamento IS NULL AND
          lf.DataVencimento = GETDATE() THEN 'Vencendo hoje'
        WHEN lf.StatusLancamento = 3 THEN 'Cancelado'
      -- ELSE
      END) AS Situação,

      (CASE lf.TipoLancamento
        WHEN 0 THEN 'Pagar'
        WHEN 1 THEN 'Receber'
      -- ELSE
      END) AS "Tipo",
      (CONVERT(VARCHAR, ISNULL(lf.IdVenda, lf.IdLancamento)) + '-' + CONVERT(VARCHAR, lf.SequencialParcela)) AS 'Numero',
      lf.IdVenda,
      lf.SequencialParcela,
      lf.DataLancamento,
      lf.DataVencimento,
      lf.DataPagamento,
      lf.Observacao,
      (lf.ValorLancamento + lf.ValorJuros) AS 'Total',
      cf.RazaoSocial,
      cc.NomeCentroCusto,
      cc.CodigoCentroCusto
    FROM LancamentoFinanceiro lf
    JOIN CliFor cf
      ON lf.IdCliFor = cf.IdCliFor
    JOIN EmpresaFilial ef
      ON lf.IdFilial = ef.IdFilial
    JOIN CentroCusto cc
      ON lf.IdCentroCusto = cc.IdCentroCusto
    WHERE lf.DataVencimento BETWEEN CONVERT(DATETIME, @P_DTINICIO, 103) AND CONVERT(DATETIME, @P_DTFIM, 103)
    AND lf.DataPagamento IS NULL
    AND lf.TipoLancamento LIKE IIF(@P_TIPOLANCAMENTO = '2', '%', @P_TIPOLANCAMENTO)
    AND cf.IdCliFor LIKE IIF(@P_IDCLIENTE = '0', '%', @P_IDCLIENTE)
    AND cc.IdCentroCusto LIKE IIF(@P_IDCENTROCUSTO = '0', '%', @P_IDCENTROCUSTO)

    ORDER BY cf.RazaoSocial ASC
  END
  GO