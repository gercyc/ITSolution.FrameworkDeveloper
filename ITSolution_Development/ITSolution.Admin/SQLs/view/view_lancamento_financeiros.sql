
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
  cf.RazaoSocial
FROM LancamentoFinanceiro lf
JOIN CliFor cf
  ON lf.IdCliFor = cf.IdCliFor
JOIN EmpresaFilial ef
  ON lf.IdFilial = ef.IdFilial
JOIN CentroCusto cc
  ON lf.IdCentroCusto = cc.IdCentroCusto

WHERE DATEPART(YEAR, lf.DataLancamento) = 2016