IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ITSMOD9_ENTRADAS%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_ITSMOD9_ENTRADAS; 

END

GO

CREATE PROCEDURE dbo.P_ITSMOD9_ENTRADAS
  (
  @P_MATRIZ VARCHAR(5),
  @P_FILIAL VARCHAR(5),
  @DT_INICIO DATETIME, 
  @DT_FIM DATETIME
  )
as
--06/04/2017 - Gercy Campos
    -- Correcao no nome das tabelas
--12/04/2017 - Gercy Campos
	--Correção da coluna IdCapa para IdMovimento
  select 
    DISTINCT
  Movimento.DirecaoMovimento,
  Cfops.CodigoCfop,
  sum(ItemMovimento.TotalItem) "Valor Contabil",

  sum(IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.BaseCalculo, 0))"Base Tributadas" ,
  sum(IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.ValorImposto, 0))"Imposto Tributadas" ,

  sum(IIF(ImpostoItemMovimento.TpSitImposto = 2, ImpostoItemMovimento.BaseCalculo, 0))"Base Isentas",
  sum(IIF(ImpostoItemMovimento.TpSitImposto = 3, ImpostoItemMovimento.BaseCalculo, 0))"Base Outras",

  /*Rateio dos valores dentro e fora do estado para a col "Valor Contabil"*/
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 1, ItemMovimento.TotalItem, 0)) "Dentro do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 2, ItemMovimento.TotalItem, 0)) "Fora do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 3, ItemMovimento.TotalItem, 0)) "Exterior",

    /*Rateio dos valores dentro e fora do estado para a col "Base de Calculo tributada""*/
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 1, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Trib Dentro do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 2, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Trib Fora do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 3, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Trib Exterior",

        /*Rateio dos valores dentro e fora do estado para a col "Base de Calculo Isenta"*/
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 1, IIF(ImpostoItemMovimento.TpSitImposto = 2, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Isenta Dentro do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 2, IIF(ImpostoItemMovimento.TpSitImposto = 2, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Isenta Fora do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 3, IIF(ImpostoItemMovimento.TpSitImposto = 2, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Isenta Exterior",

      /*Rateio dos valores dentro e fora do estado para a col "Base de Calculo Outras"*/
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 1, IIF(ImpostoItemMovimento.TpSitImposto = 3, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Outr Dentro do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 2, IIF(ImpostoItemMovimento.TpSitImposto = 3, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Outr Fora do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 3, IIF(ImpostoItemMovimento.TpSitImposto = 3, ImpostoItemMovimento.BaseCalculo, 0), 0)) "BC Outr Exterior",
         /*Rateio dos valores dentro e fora do estado para a col "Imposto Cred/Debt"*/
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 1, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.ValorImposto, 0), 0)) "Imp Trib Dentro do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 2, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.ValorImposto, 0), 0)) "Imp Trib Fora do estado",
  sum(iif(SUBSTRING(Cfops.CodigoCfop, 1, 1) = 3, IIF(ImpostoItemMovimento.TpSitImposto = 1, ImpostoItemMovimento.ValorImposto, 0), 0)) "Imp Trib Exterior"
  from Movimento Movimento
join ItemMovimento ItemMovimento on ItemMovimento.IdMovimento = Movimento.IdMovimento
join ImpostoItemMovimento ImpostoItemMovimento on ImpostoItemMovimento.IdItem = ItemMovimento.IdItem
join EmpresaFilial EmpresaFilial on Movimento.IdFilial = EmpresaFilial.IdFilial
join EmpresaMatriz EmpresaMatriz on EmpresaFilial.IdMatriz = EmpresaMatriz.IdMatriz
join Cfops Cfops on ItemMovimento.IdCfop = Cfops.IdCfop
join TipoImposto TipoImposto on ImpostoItemMovimento.IdImposto = TipoImposto.IdImposto
join SituacaoDocumentoFiscal SituacaoDocumentoFiscal on Movimento.IdSituacao = SituacaoDocumentoFiscal.IdSituacao
  where EmpresaMatriz.CodigoMatriz like @p_matriz
     and EmpresaFilial.CodigoFilial like @p_filial 
     and Movimento.DataEntrada >= @DT_INICIO 
     and Movimento.DataEntrada <= @DT_FIM
     AND TipoImposto.CodigoImposto = 'ICMS'
     and SituacaoDocumentoFiscal.CodigoSituacao in ('00', '01') 
     and Movimento.DirecaoMovimento = 'E'
  group by 
Movimento.DirecaoMovimento,
Cfops.CodigoCfop
GO