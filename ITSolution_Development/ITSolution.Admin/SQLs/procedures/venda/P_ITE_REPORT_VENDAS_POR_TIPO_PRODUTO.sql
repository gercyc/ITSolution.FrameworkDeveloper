IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_ITE_REPORT_VENDAS_POR_TIPO_PRODUTO%' 
 
) BEGIN

	DROP PROCEDURE P_ITE_REPORT_VENDAS_POR_TIPO_PRODUTO;

END

GO

CREATE PROCEDURE dbo.P_ITE_REPORT_VENDAS_POR_TIPO_PRODUTO (
  --Periodo
@P_DTINICIO DATETIME, @P_DTFIM DATETIME,
-- Tipo Produto
--Serviço 1
--Produto 2
@P_TIPOPRODUTO VARCHAR(2))
AS


  SELECT
    iv.IdVenda,
    c.RazaoSocial,
    (CASE
      WHEN v.StatusVenda = 1 THEN 'Aberto'

      WHEN v.StatusVenda = 2 THEN 'Parcial'

      WHEN v.StatusVenda = 3 THEN 'Cancelado'
      WHEN v.StatusVenda = 4 THEN 'Paga'
      WHEN v.DataVencimento < GETDATE() OR
        v.StatusVenda = 5 THEN 'Vencida'
      WHEN v.DataVencimento = GETDATE() THEN 'Vencendo hoje'
    -- ELSE
    END) AS 'Status',
    v.DataVenda,
    v.TotalVenda

  FROM ItemVenda iv
  JOIN Produto p
    ON p.IdProduto = iv.IdProduto
  JOIN Venda v
    ON iv.IdVenda = v.IdVenda
  JOIN CliFor c
    ON v.IdCliForVenda = c.IdCliFor
  WHERE v.DataVenda >= CONVERT(DATETIME, @P_DTINICIO, 103)
  AND v.DataVencimento <= CONVERT(DATETIME, @P_DTFIM, 103)
  AND p.TipoItemProduto LIKE IIF(@P_TIPOPRODUTO = '2', '%', @P_TIPOPRODUTO)

  GROUP BY iv.IdVenda,
           c.RazaoSocial,
           (CASE
             WHEN v.StatusVenda = 1 THEN 'Aberto'

             WHEN v.StatusVenda = 2 THEN 'Parcial'

             WHEN v.StatusVenda = 3 THEN 'Cancelado'
             WHEN v.StatusVenda = 4 THEN 'Paga'
             WHEN v.DataVencimento < GETDATE() OR
               v.StatusVenda = 5 THEN 'Vencida'
             WHEN v.DataVencimento = GETDATE() THEN 'Vencendo hoje'
           -- ELSE
           END),
           v.DataVenda,
           v.TotalVenda
  ORDER BY v.DataVenda ASC
GO