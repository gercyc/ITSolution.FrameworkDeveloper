IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_DESPESAS_OPERACIONAIS_ANUAL%' 
 
) BEGIN

	DROP PROCEDURE P_DESPESAS_OPERACIONAIS_ANUAL; 

END 
GO 
-- =============================================
-- Author:		Filipe
-- Create date: 23/05/2015
-- Description:	Relatorio do total dos recebimentos operacionais do ano
-- =============================================
CREATE PROCEDURE [dbo].[P_DESPESAS_OPERACIONAIS_ANUAL]
(
	-- No parameter Add the parameters for the stored procedure here (
	@Ano INT
)
 
AS
BEGIN
	DECLARE @Janeiro INT SET @Janeiro = 1
	DECLARE @Fevereiro INT SET @Fevereiro = 2
	DECLARE @Marco INT SET @Marco = 3
	DECLARE @Abril INT SET @Abril = 4
	DECLARE @Maio INT SET @Maio = 5
	DECLARE @Junho INT SET @Junho = 6
	DECLARE @Julho INT SET @Julho = 7
	DECLARE @Agosto INT SET @Agosto = 8
	DECLARE @Setembro INT SET @Setembro = 9
	DECLARE @Outubro INT SET @Outubro = 10
	DECLARE @Novembro INT SET @Novembro = 11
	DECLARE @Dezembro INT SET @Dezembro = 12  

	DECLARE @v_totalDespOpJaneiro DECIMAL
	DECLARE @v_totalDespOpFevereiro DECIMAL
	DECLARE @v_totalDespOpMarco DECIMAL
	DECLARE @v_totalDespOpAbril DECIMAL
	DECLARE @v_totalDespOpMaio DECIMAL
	DECLARE @v_totalDespOpJunho DECIMAL
	DECLARE @v_totalDespOpJulho DECIMAL
	DECLARE @v_totalDespOpAgosto DECIMAL
	DECLARE @v_totalDespOpSetembro DECIMAL
	DECLARE @v_totalDespOpOutubro DECIMAL
	DECLARE @v_totalDespOpNovembro DECIMAL
	DECLARE @v_totalDespOpDezembro DECIMAL
	DECLARE @v_IdRecebOp INT SET @v_IdRecebOp = 1

SET @v_totalDespOpJaneiro = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Janeiro, @Ano, @v_IdRecebOp))
SET @v_totalDespOpFevereiro	= ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Fevereiro, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpMarco = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Marco, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpAbril = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Abril, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpMaio = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Maio, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpJunho = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Junho, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpJulho = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Julho, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpAgosto = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Agosto, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpSetembro = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Setembro, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpOutubro = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Outubro, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpNovembro = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Novembro, @Ano, @v_IdRecebOp)) 
SET @v_totalDespOpDezembro = ( SELECT [dbo].[F_TOTAL_CENTRO_CUSTO_POR_MES] (@Dezembro, @Ano, @v_IdRecebOp)) 

	

	SELECT 'RECEBIMENTOS OPERACIONAIS', 'RECEBIMENTOS OPERACIONAIS',
		@v_totalDespOpJaneiro ,	 
		@v_totalDespOpFevereiro ,	 
		@v_totalDespOpMarco ,
		@v_totalDespOpAbril ,	 
		@v_totalDespOpMaio ,	 
		@v_totalDespOpJunho ,	 
		@v_totalDespOpJulho ,
		@v_totalDespOpAgosto ,	
		@v_totalDespOpSetembro ,	
		@v_totalDespOpOutubro ,
		@v_totalDespOpNovembro ,	 
		@v_totalDespOpDezembro, 
		SUM( @v_totalDespOpJaneiro + @v_totalDespOpFevereiro + @v_totalDespOpMarco + @v_totalDespOpAbril + @v_totalDespOpMaio +
			@v_totalDespOpJunho + @v_totalDespOpJulho + @v_totalDespOpAgosto + @v_totalDespOpSetembro + @v_totalDespOpOutubro +
			@v_totalDespOpNovembro + @v_totalDespOpDezembro )

 END