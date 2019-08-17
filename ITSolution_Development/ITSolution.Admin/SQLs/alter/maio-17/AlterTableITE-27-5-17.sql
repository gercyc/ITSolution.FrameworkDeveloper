ALTER TABLE LancamentoFinanceiro
ADD QuantidadeAnexos INT NULL
GO

UPDATE LancamentoFinanceiro
SET QuantidadeAnexos = 0

ALTER TABLE LancamentoFinanceiro
ALTER COLUMN QuantidadeAnexos INT NOT NULL
GO

--Cursor para ajustar o numero de anexos por lançamento
DECLARE @v_idLancamento INT,
        @v_qtde INT


DECLARE cAnexos CURSOR FOR

SELECT
  a.IdLancamento,
  COUNT(a.IdLancamento) AS 'Qtde. Anexos'
FROM AnexoLancamento a
GROUP BY a.IdLancamento
ORDER BY a.IdLancamento

OPEN cAnexos

FETCH NEXT FROM cAnexos INTO @v_idLancamento, @v_qtde

WHILE @@fetch_status = 0
BEGIN
  UPDATE LancamentoFinanceiro
  SET QuantidadeAnexos = @v_qtde
  WHERE IdLancamento = @v_idLancamento


  FETCH NEXT FROM cAnexos INTO @v_idLancamento, @v_qtde
END
CLOSE cAnexos
DEALLOCATE cAnexos;

GO

CREATE TABLE Lembrete (
  IdLembrete INT IDENTITY,
  NomeLembrete VARCHAR(200) NULL,
  Texto TEXT NULL,
  CONSTRAINT [PK_dbo.Lembrete] PRIMARY KEY CLUSTERED (IdLembrete)
) ON [PRIMARY]
GO

CREATE TABLE Contato (
  IdContato INT IDENTITY,
  NomeContato VARCHAR(50) NULL,
  SegundoNomeContato VARCHAR(50) NULL,
  SobreNomeContato VARCHAR(50) NULL,
  Website VARCHAR(500) NULL,
  Email VARCHAR(300) NULL,
  Celular VARCHAR(20) NULL,
  Telefone VARCHAR(20) NULL,
  TelefoneFixo VARCHAR(20) NULL,
  NomeEndereco VARCHAR(200) NULL,
  NumeroEndereco VARCHAR(20) NULL,
  Bairro VARCHAR(200) NULL,
  Complemento VARCHAR(100) NULL,
  Cep VARCHAR(10) NULL,
  Uf VARCHAR(10) NULL,
  Cidade VARCHAR(100) NULL,
  TipoEndereco VARCHAR(50) NULL,
  CONSTRAINT [PK_dbo.Contato] PRIMARY KEY CLUSTERED (IdContato)
) ON [PRIMARY]
GO

ALTER TABLE ITS_COTACAO_MONETARIA
ADD Fonte VARCHAR(45) NULL,  --PTAX
FullName VARCHAR(100) NULL,   --Exchange rate - Free - Swiss Franc (bid)
GestorProprietario VARCHAR(45) NULL, --DEPEC/DIBAP/SUCAP
NomeAbreviado VARCHAR(45) NULL,  --Franco Suíço (compra)
NomeCompleto VARCHAR(100) NULL,   --Taxa de câmbio - Livre - Franco Suíço (compra)
Periodicidade VARCHAR(45) NULL, --Diária
ShortName VARCHAR(45) NULL,  --Swiss Franc (bid)
UnidadePadrao VARCHAR(45) NULL	--R$/u.m.c.
GO

ALTER TABLE ITS_MOEDA
ALTER COLUMN NomeMoeda VARCHAR(50) NOT NULL