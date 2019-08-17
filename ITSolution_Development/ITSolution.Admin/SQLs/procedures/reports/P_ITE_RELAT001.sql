IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ITE_RELAT001%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_ITE_RELAT001; 

END

GO
CREATE PROCEDURE dbo.P_ITE_RELAT001
  (@DT_INICIO DATETIME, 
  @DT_FIM DATETIME, 
  @P_IDCLIENTE VARCHAR(4),
  @P_STATUSLANCAMENTO VARCHAR(4)
  )
AS 
  
  select 
StatusParcela = (CASE
  WHEN (LancamentoFinanceiro.DataVencimento <= GETDATE() AND LancamentoFinanceiro.DataPagamento is null) THEN 'Vencido'
  WHEN StatusLancamento = 0 THEN 'Em Aberto'
  WHEN StatusLancamento = 1 THEN 'Recebido'
  WHEN StatusLancamento = 2 THEN 'Parcialmente Quitada'
  ELSE Convert(VARCHAR, StatusLancamento)
  END),
  ValorRecebidoExec = (CASE
  WHEN StatusLancamento = 0 THEN 0.00
  WHEN StatusLancamento = 1 THEN LancamentoFinanceiro.ValorLancamento
  WHEN StatusLancamento = 2 THEN LancamentoFinanceiro.ValorLancamento
  WHEN StatusLancamento = 3 THEN 0.00
  ELSE 0
  END),
  ValorEmAbertoExec = (CASE
  WHEN StatusLancamento = 0 THEN LancamentoFinanceiro.ValorLancamento --se emAberto, exibe valor
  WHEN StatusLancamento = 3 THEN LancamentoFinanceiro.ValorLancamento --se Vencida, exibe valor
  ELSE 0                                       --se nenhum StatusLancamento acima, exibe 0,00
  END),       
  LancamentoFinanceiro.IdLancamento, 
  datepart(MONTH, LancamentoFinanceiro.DataVencimento) as "Mês vencimento",
  LancamentoFinanceiro.DataVencimento, 
  LancamentoFinanceiro.DataPagamento, 
  LancamentoFinanceiro.ValorLancamento, 
  LancamentoFinanceiro.ValorJuros, 
  CliFor.RazaoSocial
  from LancamentoFinanceiro LancamentoFinanceiro
  join CliFor CliFor ON LancamentoFinanceiro.IdCliFor = CliFor.IdCliFor
  WHERE LancamentoFinanceiro.DataVencimento >= @DT_INICIO
  AND LancamentoFinanceiro.DataVencimento <= @DT_FIM
  and LancamentoFinanceiro.IdCliFor like @P_IDCLIENTE
  and LancamentoFinanceiro.StatusLancamento like @P_STATUSLANCAMENTO
GO