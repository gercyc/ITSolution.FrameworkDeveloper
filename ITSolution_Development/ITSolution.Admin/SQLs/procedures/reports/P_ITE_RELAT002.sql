IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ITE_RELAT002%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_ITE_RELAT002; 

END
GO
CREATE PROCEDURE dbo.P_ITE_RELAT002
  (
  @P_MATRIZ VARCHAR(5),
  @P_FILIAL VARCHAR(5),
  @DT_INICIO VARCHAR(10), 
  @DT_FIM VARCHAR(10)
  )
as
DECLARE
  @DT_INICIO_DT DATETIME,
  @DT_FIM_DT DATETIME


  SET @DT_INICIO_DT = CONVERT(DATETIME, @DT_INICIO, 103)
  SET @DT_FIM_DT = CONVERT(DATETIME, @DT_FIM, 103)

  select 
  Movimento.TipoNf,
  Cfops.CodigoCfop,
  Movimento.TotalNotaFiscal,
  sum(IIF(ImpostoItemImposto.TpSitImposto = 1, ImpostoItemImposto.BaseCalculo, 0))"Base Tributadas" ,
  sum(IIF(ImpostoItemImposto.TpSitImposto = 2, ImpostoItemImposto.BaseCalculo, 0))"Base Isentas",
  sum(IIF(ImpostoItemImposto.TpSitImposto = 3, ImpostoItemImposto.BaseCalculo, 0))"Base Outras",

  sum(IIF(ImpostoItemImposto.TpSitImposto = 1, ImpostoItemImposto.ValorImposto, 0))"Imposto Tributadas" ,
  sum(IIF(ImpostoItemImposto.TpSitImposto = 2, ImpostoItemImposto.ValorImposto, 0))"Imposto Isentas",
  sum(IIF(ImpostoItemImposto.TpSitImposto = 3, ImpostoItemImposto.ValorImposto, 0))"Imposto Outras"
  from Movimento Movimento
join ItemMovimento ItemMovimento on ItemMovimento.IdMovimento = Movimento.IdMovimento
join ImpostoItemImposto ImpostoItemImposto on ImpostoItemImposto.IdItem = ItemMovimento.IdItem
join EmpresaFilial EmpresaFilial on Movimento.IdFilial = EmpresaFilial.IdFilial
join EmpresaMatriz EmpresaMatriz on EmpresaFilial.IdEmpresaMatriz = EmpresaMatriz.IdEmpresaMatriz
join Cfops Cfops on ItemMovimento.IdCfop = Cfops.IdCfop
join TipoImposto TipoImposto on ImpostoItemImposto.IdImposto = TipoImposto.IdImposto
join SituacaoDocumentoFiscal SituacaoDocumentoFiscal on Movimento.IdSituacao = SituacaoDocumentoFiscal.IdSituacao
  where EmpresaMatriz.CodigoMatriz like @p_matriz
     and EmpresaFilial.CodigoFilial like @p_filial 
     and Movimento.DataEntrada >= @DT_INICIO_DT 
     and Movimento.DataEntrada <= @DT_FIM_DT
     AND TipoImposto.CodigoImposto = 'ICMS'
     and SituacaoDocumentoFiscal.CodigoSituacao in ('00', '01')
  group by 
Movimento.TipoNf,
Cfops.CodigoCfop,
Movimento.TotalNotaFiscal
GO