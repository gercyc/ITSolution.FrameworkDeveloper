IF EXISTS(
SELECT
      ROUTINE_SCHEMA
    , ROUTINE_NAME
FROM
    INFORMATION_SCHEMA.ROUTINES
WHERE
    ROUTINE_DEFINITION LIKE '%P_GET_INFO_MATRIZ_FILIAL%' 
 
) BEGIN

	DROP PROCEDURE dbo.P_GET_INFO_MATRIZ_FILIAL; 

END

GO
CREATE PROCEDURE dbo.P_GET_INFO_MATRIZ_FILIAL (@P_MATRIZ VARCHAR(5),
@P_FILIAL VARCHAR(5))
AS

  DECLARE @v_count_matriz INT
  -- Conta as matrizes
  SET @v_count_matriz = (SELECT COUNT(*) FROM EmpresaMatriz)

  --Se so tem uma Matriz entao usa ela use ela
  IF (@v_count_matriz = 1 OR @P_MATRIZ IS NULL OR @P_FILIAL IS NULL)
  BEGIN
    SELECT TOP 1
      em.Logo,
      em.CodigoMatriz,
      ef.CodigoFilial,
      ef.RazaoSocial,
      ef.Cnpj,
      ef.InscricaoEstadual,
      ef.Uf,
      ef.Cidade
    FROM EmpresaMatriz em
    JOIN EmpresaFilial ef
      ON ef.IdMatriz = em.IdMatriz
    WHERE em.IdMatriz > 0
    AND ef.IdFilial > 0
  END
  --Procure a empresa
  ELSE 
 BEGIN
    SELECT
      em.Logo,
      em.CodigoMatriz,
      ef.CodigoFilial,
      ef.RazaoSocial,
      ef.Cnpj,
      ef.InscricaoEstadual,
      ef.Uf,
      ef.Cidade
    FROM EmpresaMatriz em
    JOIN EmpresaFilial ef
      ON ef.IdMatriz = em.IdMatriz
    WHERE em.CodigoMatriz = @P_MATRIZ
    AND ef.CodigoFilial = @P_FILIAL

  END

GO