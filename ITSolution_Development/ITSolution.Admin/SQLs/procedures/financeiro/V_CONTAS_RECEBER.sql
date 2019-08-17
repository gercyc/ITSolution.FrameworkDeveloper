SELECT
  (CASE
    WHEN lf.DataPagamento IS NULL AND
      lf.DataVencimento < GETDATE() THEN 'Atrasada'       --
    WHEN lf.DataPagamento IS NULL AND
      lf.DataVencimento > GETDATE() THEN 'A Vencer'       -- Status calculados em tempo de 
    WHEN lf.DataPagamento IS NULL AND
      lf.DataVencimento = GETDATE() THEN 'Vencendo hoje'   -- execucao da consulta
    WHEN lf.StatusLancamento = 1 THEN 'Paga'
    WHEN lf.StatusLancamento = 2 THEN 'Vencida'
    WHEN lf.StatusLancamento = 3 THEN 'Parcialmente Paga'
  -- ELSE
  END) AS 'Situação',

  (CASE lf.TipoLancamento
    WHEN 0 THEN 'Pagar'
    WHEN 1 THEN 'Receber'
  -- ELSE
  END) AS 'Tipo',
  (CONVERT(VARCHAR, ISNULL(lf.IdVenda, lf.IdLancamento)) + '-' + CONVERT(VARCHAR, lf.SequencialParcela)) AS "Numero",
  lf.IdVenda,
  lf.SequencialParcela,
  lf.DataLancamento,
  lf.DataVencimento,
  lf.DataPagamento,
  (lf.ValorLancamento + lf.ValorJuros) AS 'Valor Lancamento',
  lf.Observacao,
  cf.RazaoSocial AS 'Cliente'
FROM LancamentoFinanceiro lf
JOIN CliFor cf
  ON lf.IdCliFor = cf.IdCliFor
JOIN EmpresaFilial ef
  ON lf.IdFilial = ef.IdFilial
JOIN CentroCusto cc
  ON lf.IdCentroCusto = cc.IdCentroCusto
--0 pagar
--1 receber 
--Status aberto
WHERE lf.TipoLancamento = 1
-- Status Aberto
AND lf.StatusLancamento = 0
-- Status Vencido
AND lf.DataPagamento IS NULL
OR lf.TipoLancamento = 1
AND lf.StatusLancamento = 2
AND lf.DataPagamento IS NULL
ORDER BY lf.DataLancamento DESC