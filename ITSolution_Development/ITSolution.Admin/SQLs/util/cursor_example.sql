DECLARE @contador INT,
        @b_idBaixa INT
--contador
SET @contador = 1

DECLARE cBaixas CURSOR FOR

SELECT
  b.IdBaixa
FROM tbBaixa b
ORDER BY b.IdBaixa

OPEN cBaixas

FETCH NEXT FROM cBaixas INTO @b_idBaixa

WHILE @@fetch_status = 0
BEGIN
  UPDATE tbBaixa
  SET IdBaixa = @contador
  WHERE IdBaixa = @b_idBaixa

  SET @contador = @contador + 1

  FETCH NEXT FROM cBaixas INTO @b_idBaixa
END
CLOSE cBaixas
DEALLOCATE cBaixas;

GO