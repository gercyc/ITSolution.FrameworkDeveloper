DECLARE @v_idclifor INT,
        @v_nome_endereco VARCHAR(MAX),
        @v_num_endereco VARCHAR(MAX),
        @v_bairro VARCHAR(MAX),
        @v_complemento VARCHAR(MAX),
        @v_cep VARCHAR(MAX),
        @v_uf VARCHAR(MAX),
        @v_cidade VARCHAR(MAX),
        @v_tipo_end VARCHAR(MAX)

DECLARE cCliFor CURSOR FOR
SELECT
  cf.IdCliFor,
  ecf.NomeEndereco,
  ecf.NumeroEndereco,
  ecf.Bairro,
  ecf.Complemento,
  ecf.Cep,
  ecf.Uf,
  ecf.Cidade,
  ecf.TipoEndereco
FROM CliFor cf
LEFT JOIN EnderecoCliFor ecf
  ON cf.IdCliFor = ecf.IdCliForEndereco;
BEGIN

  OPEN cCliFor;

  FETCH NEXT FROM cCliFor INTO @v_idclifor, @v_nome_endereco, @v_num_endereco,
  @v_bairro, @v_complemento, @v_cep, @v_uf, @v_cidade, @v_tipo_end

  WHILE @@fetch_status = 0
  BEGIN
    UPDATE CliFor
    SET NomeEndereco = @v_nome_endereco,
        NumeroEndereco = @v_num_endereco,
        Bairro = @v_bairro,
        Complemento = @v_complemento,
        Cep = @v_cep,
        Uf = @v_uf,
        Cidade = @v_cidade,
        TipoEndereco = @v_tipo_end
    WHERE IdCliFor = @v_idclifor

    FETCH NEXT FROM cCliFor INTO @v_idclifor, @v_nome_endereco, @v_num_endereco,
    @v_bairro, @v_complemento, @v_cep, @v_uf, @v_cidade, @v_tipo_end


  END
  CLOSE cCliFor
  DEALLOCATE cCliFor
END