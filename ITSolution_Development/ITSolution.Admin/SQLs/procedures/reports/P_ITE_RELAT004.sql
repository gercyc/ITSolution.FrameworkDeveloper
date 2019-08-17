IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ITE_RELAT004%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_ITE_RELAT004; 

END

GO
CREATE PROCEDURE dbo.P_ITE_RELAT004 --build 0001
  (@dt_inicio DATETIME,
  @dt_fim DATETIME,
  @p_localestoque VARCHAR(5))
  AS

/*
  Criacao em 20/02/2017 
    procedure que gera o datasource para o relatorio de estoque
    quebra por local de estoque
  
  */

  DECLARE @v_IdProduto INT, @v_DescricaoProduto VARCHAR(100), @v_CodigoProduto VARCHAR(100), @v_codLocalEstoque VARCHAR(5), @v_nomeLocalEstoque VARCHAR(100)

  DECLARE
  @v_QuantidadeEntrPerAnterior DECIMAL(18,3),
  @v_QuantidadeSaidaPerAnterior DECIMAL(18,3),
  @v_CustoMedioPerAnterior DECIMAL(18,2),
  
  @v_QuantidadePerAnterior DECIMAL(18,3),
  
  @v_QuantidadeEntrPerAtual DECIMAL(18,3),
  @v_QuantidadeSaidaPerAtual DECIMAL(18,3),
  @v_CustoMedioEntrPerAtual DECIMAL(18,2),
  @v_CustoMedioPerAtual DECIMAL(18,2),
  
  @v_QuantidadePerAtual DECIMAL(18,3)
  
  DECLARE @z_ficha TABLE
  (
  	idProduto INT,
    CodLocalEstoque VARCHAR(5),
    NomeLocalEstoque VARCHAR(100),
  	CodigoProduto VARCHAR(50),
    DescricaoProduto VARCHAR(100),
    QuantidadePerAnterior DECIMAL(18,3),
    ValorPerAnterior DECIMAL(18,2),
    QuantidadeEntradasPerAtual DECIMAL(18,3),
    ValorEntradasPerAtual DECIMAL(18,2),
    QuantidadeSaidasPerAtual DECIMAL(18,3),
    ValorSaidasPerAtual DECIMAL(18,2),
    QuantidadePerAtual DECIMAL(18,3),
    ValorPerAtual DECIMAL(18,2)
  )
  

  DECLARE cProdutos CURSOR FOR
  	
    SELECT p.IdProduto, p.DescricaoProduto, p.CodigoBarras, le.CodigoLocalEstoque, le.NomeLocalEstoque
  	FROM dbo.Produto p
  LEFT JOIN TransacoesProduto tp ON tp.IdProduto = p.IdProduto
  LEFT JOIN LocalEstoque le ON tp.IdLocalEstoque = le.IdLocalEstoque
  WHERE p.TipoItemProduto = 0 --somente itens do tipo 'Produto'
      and tp.DataTransacao < @dt_fim 
      AND le.CodigoLocalEstoque LIKE IIF(@p_localestoque = '0', '%', @p_localestoque)
GROUP BY p.IdProduto, p.DescricaoProduto, p.CodigoBarras,le.CodigoLocalEstoque, le.NomeLocalEstoque
  
  OPEN cProdutos
  
  FETCH NEXT FROM cProdutos INTO @v_IdProduto, @v_DescricaoProduto, @v_CodigoProduto, @v_codLocalEstoque, @v_nomeLocalEstoque
  
  WHILE @@FETCH_STATUS = 0 BEGIN

    --entradas do periodo anterior
  	  SELECT 
      @v_QuantidadeEntrPerAnterior = ISNULL(SUM(tp.Quantidade),0),
      @v_CustoMedioPerAnterior = ISNULL(AVG(tp.ValorUnitario),0)      
      FROM Produto p
      LEFT JOIN TransacoesProduto tp ON tp.IdProduto = p.IdProduto
      LEFT JOIN LocalEstoque le ON tp.IdLocalEstoque = le.IdLocalEstoque
      WHERE p.IdProduto = @v_IdProduto
      AND tp.TipoTransacao in (1,4) --vendas + os cancelamentos que ocorreram
      AND tp.DataTransacao < @dt_inicio
      AND le.CodigoLocalEstoque LIKE IIF(@p_localestoque = '0', '%', @p_localestoque)

      --saidas do periodo anterior
      SELECT 
      @v_QuantidadeSaidaPerAnterior = ISNULL(SUM(tp.Quantidade),0)   
      FROM Produto p
      LEFT JOIN TransacoesProduto tp ON tp.IdProduto = p.IdProduto
      LEFT JOIN LocalEstoque le ON tp.IdLocalEstoque = le.IdLocalEstoque
      WHERE p.IdProduto = @v_IdProduto
      AND tp.TipoTransacao = 2
      AND tp.DataTransacao < @dt_inicio
      AND le.CodigoLocalEstoque LIKE IIF(@p_localestoque = '0', '%', @p_localestoque)

      --entradas do periodo selecionado
      SELECT 
      @v_QuantidadeEntrPerAtual = ISNULL(SUM(tp.Quantidade),0),
      @v_CustoMedioEntrPerAtual = ISNULL(AVG(tp.ValorUnitario),0)      
      FROM Produto p
      LEFT JOIN TransacoesProduto tp ON tp.IdProduto = p.IdProduto
      LEFT JOIN LocalEstoque le ON tp.IdLocalEstoque = le.IdLocalEstoque
      WHERE p.IdProduto = @v_IdProduto
      AND tp.TipoTransacao in (1,4)
      AND tp.DataTransacao BETWEEN @dt_inicio AND @dt_fim
      AND le.CodigoLocalEstoque LIKE IIF(@p_localestoque = '0', '%', @p_localestoque)

      IF(@v_CustoMedioEntrPerAtual = 0)
       SET @v_CustoMedioPerAtual = @v_CustoMedioPerAnterior
        ELSE
        SET @v_CustoMedioPerAtual = @v_CustoMedioEntrPerAtual


      --saidas do periodo selecionado
      SELECT 
      @v_QuantidadeSaidaPerAtual = ISNULL(SUM(tp.Quantidade),0)    
      FROM Produto p
      LEFT JOIN TransacoesProduto tp ON tp.IdProduto = p.IdProduto
      LEFT JOIN LocalEstoque le ON tp.IdLocalEstoque = le.IdLocalEstoque
      WHERE p.IdProduto = @v_IdProduto
      AND tp.TipoTransacao = 2
      AND tp.DataTransacao BETWEEN @dt_inicio AND @dt_fim
      AND le.CodigoLocalEstoque LIKE IIF(@p_localestoque = '0', '%', @p_localestoque)

      --realizacao dos calculos
      SET @v_QuantidadePerAnterior  = @v_QuantidadeEntrPerAnterior - @v_QuantidadeSaidaPerAnterior 

      SET @v_QuantidadePerAtual     = (@v_QuantidadePerAnterior + @v_QuantidadeEntrPerAtual) - @v_QuantidadeSaidaPerAtual      
      
      IF  (@v_QuantidadeEntrPerAtual > 0 OR @v_QuantidadeSaidaPerAtual > 0)

        BEGIN  
      	      --inserindo na tabela temporaria 'Ficha de estoque'
        INSERT INTO @z_ficha (idProduto, 
        CodigoProduto, 
        DescricaoProduto, 
        QuantidadePerAnterior, 
        ValorPerAnterior, 
        QuantidadeEntradasPerAtual, 
        ValorEntradasPerAtual, 
        QuantidadeSaidasPerAtual, 
        ValorSaidasPerAtual, 
        QuantidadePerAtual, 
        ValorPerAtual,
          CodLocalEstoque,
          NomeLocalEstoque)
        VALUES (@v_IdProduto, 
        @v_CodigoProduto, 
        @v_DescricaoProduto, 
        @v_QuantidadePerAnterior, 
        ISNULL((@v_CustoMedioPerAnterior * @v_QuantidadePerAnterior),0), 
        @v_QuantidadeEntrPerAtual, 
        ISNULL((@v_CustoMedioEntrPerAtual * @v_QuantidadeEntrPerAtual),0),
        @v_QuantidadeSaidaPerAtual, 
        ISNULL((@v_CustoMedioPerAtual * @v_QuantidadeSaidaPerAtual),0), 
        @v_QuantidadePerAtual, 
        ISNULL((@v_CustoMedioPerAtual * @v_QuantidadePerAtual),0),
          @v_codLocalEstoque,
          @v_nomeLocalEstoque);
      END
      
  FETCH NEXT FROM cProdutos INTO @v_IdProduto, @v_DescricaoProduto, @v_CodigoProduto, @v_codLocalEstoque, @v_nomeLocalEstoque
  
  END
  
  CLOSE cProdutos
  DEALLOCATE cProdutos

  SELECT  f.idProduto,
          f.CodLocalEstoque,
          f.NomeLocalEstoque,
          f.CodigoProduto,
          f.DescricaoProduto,
          f.QuantidadePerAnterior,
          f.ValorPerAnterior,
          f.QuantidadeEntradasPerAtual,
          f.ValorEntradasPerAtual,
          f.QuantidadeSaidasPerAtual,
          f.ValorSaidasPerAtual,
          f.QuantidadePerAtual,
          f.ValorPerAtual  FROM @z_ficha f
  GROUP BY f.idProduto,
          f.CodLocalEstoque,
          f.NomeLocalEstoque,
          f.CodigoProduto,
          f.DescricaoProduto,
          f.QuantidadePerAnterior,
          f.ValorPerAnterior,
          f.QuantidadeEntradasPerAtual,
          f.ValorEntradasPerAtual,
          f.QuantidadeSaidasPerAtual,
          f.ValorSaidasPerAtual,
          f.QuantidadePerAtual,
          f.ValorPerAtual
GO