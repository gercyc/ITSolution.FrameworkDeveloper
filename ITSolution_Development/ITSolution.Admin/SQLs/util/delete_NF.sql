DECLARE @v_id_capa INT;

SET @v_id_capa = 1035; --informar o id da nf a ser excluida

DELETE FROM TransacoesProduto
WHERE IdNotaFiscal = @v_id_capa;

DELETE FROM NotaFiscalItemImposto
WHERE IdItem IN (SELECT
    IdItem
  FROM NotaFiscalItem nfi
  WHERE nfi.IdCapa = @v_id_capa);

DELETE FROM NotaFiscalItem
WHERE IdCapa = @v_id_capa;

DELETE FROM NotaFiscalCapa
WHERE IdCapa = @v_id_capa;