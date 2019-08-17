USE dbBalcao_Homol
GO 
/****** Object:  Trigger [dbo].[Tgr_Balcao_AtualizarEstoque]    Script Date: 29/07/2015 21:22:47 ******/
 
CREATE TRIGGER [dbo].[Tgr_Balcao_AtualizarStatusProduto]
--Na tabela de IdProduto
ON [dbo].[Produto]
--Ao Atualizar
FOR  UPDATE
AS

--Faça
BEGIN

	DECLARE @IdProduto INT

	SELECT 
		--Selecione a ultima Pk onde houve ocorrencia na tabela 
		@IdProduto = IdProduto
	FROM INSERTED
	
	--Verifique o situaçao do produto apos atualizado o estoque
	BEGIN		
		--Atualizando o status do produto 
		UPDATE 
			Produto 
			SET 
				--Tratando para o produto defasado
				StatusProduto =  
				--Se quantidade estive baixa
				CASE WHEN QuantidadeProduto <= 1 
				--marque o produto como defasado
				THEN 'Defasado'	
				--caso contrario estará Ativo
				ELSE 'Ativo'			
				--Fim do case
				END
			
		--Atualize o produto especifico 
 		WHERE IdProduto = @IdProduto 
	END
 
END