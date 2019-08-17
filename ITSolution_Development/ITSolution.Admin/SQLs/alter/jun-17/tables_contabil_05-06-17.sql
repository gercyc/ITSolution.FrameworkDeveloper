--SEQUENCIA DO LOTE CONTABIL
CREATE SEQUENCE dbo.SEQ_NUM_LOTECONTABIL
AS BIGINT
START WITH 1
NO CYCLE
NO CACHE
GO
--Tabela LoteContabil
CREATE TABLE dbo.LoteContabil (
  IdLote VARCHAR(38) NOT NULL
 ,IdMatriz INT NOT NULL
 ,NumeroLote VARCHAR(10) NULL
 ,DescricaoLote VARCHAR(50) NULL
 ,DataInicial DATETIME NULL
 ,DataFinal DATETIME NULL
 ,ValorDebito DECIMAL(18, 2) NULL
 ,ValorCredito DECIMAL(18, 2) NULL
 ,Valor DECIMAL(18, 2) NULL
 ,OrigemLote INT NOT NULL
 ,IdUsuario INT NOT NULL
 ,DataCriacao DATETIME NOT NULL
 ,StatusLote INT NOT NULL
 ,CONSTRAINT PK_LoteContabil_IdLote PRIMARY KEY CLUSTERED (IdLote)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX UK_LoteContabil
ON dbo.LoteContabil (IdMatriz, NumeroLote)
ON [PRIMARY]
GO

ALTER TABLE dbo.LoteContabil
ADD CONSTRAINT FK_LoteContabil_IdMatriz FOREIGN KEY (IdMatriz) REFERENCES dbo.EmpresaMatriz (IdMatriz)
GO

ALTER TABLE dbo.LoteContabil
ADD CONSTRAINT FK_LoteContabil_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (IdUsuario)
GO

--Tabela LancamentoContabil
CREATE TABLE dbo.LancamentoContabil (
  IdLancamentoContabil VARCHAR(38) NOT NULL
 ,IdMatriz INT NOT NULL
 ,DataLancamento DATETIME NOT NULL
 ,ValorDebito DECIMAL(18, 2) NULL
 ,ValorCredito DECIMAL(18, 2) NULL
 ,Valor DECIMAL(18, 2) NULL
 ,IdLoteOrigem VARCHAR(38) NULL
 ,IdUsuario INT NOT NULL
 ,IdUsuarioAlter INT NOT NULL
 ,DataCriacao DATETIME NOT NULL
 ,DataAlteracao DATETIME NULL
 ,CONSTRAINT PK_LancamentoContabil_ID PRIMARY KEY CLUSTERED (IdLancamentoContabil)
) ON [PRIMARY]
GO

ALTER TABLE dbo.LancamentoContabil
ADD CONSTRAINT FK_LancamentoContabil_IdLoteOrigem FOREIGN KEY (IdLoteOrigem) REFERENCES dbo.LoteContabil (IdLote)
GO

ALTER TABLE dbo.LancamentoContabil
ADD CONSTRAINT FK_LancamentoContabil_IdMatriz FOREIGN KEY (IdMatriz) REFERENCES dbo.EmpresaMatriz (IdMatriz)
GO

ALTER TABLE dbo.LancamentoContabil
ADD CONSTRAINT FK_LancamentoContabil_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (IdUsuario)
GO

ALTER TABLE dbo.LancamentoContabil
ADD CONSTRAINT FK_LancamentoContabil_IdUsuarioAlter FOREIGN KEY (IdUsuarioAlter) REFERENCES dbo.Usuario (IdUsuario)
GO
--Tabela PartidaContabil
CREATE TABLE dbo.PartidaContabil (
  IdPartida VARCHAR(38) NOT NULL
 ,IdLancamentoContabil VARCHAR(38) NOT NULL
 ,SequencialPartida INT NOT NULL
 ,IdCentroCusto INT NULL
 ,IdContaContabilDeb INT NULL
 ,IdContaContabilCred INT NULL
 ,IdMoeda INT NOT NULL
 ,ValorPartida DECIMAL(18, 2) NULL
 ,IdMoeda2 INT NULL
 ,ValorPartida2 DECIMAL(18, 2) NULL
 ,IdHistoricoPadrao INT NULL
 ,Historico VARCHAR(80) NULL
 ,IdCliFor INT NULL
 ,LocalizacaoFisDoc VARCHAR(10) NULL
 ,CONSTRAINT PK_PartidaContabil_IdPartida PRIMARY KEY CLUSTERED (IdPartida)
) ON [PRIMARY]
GO

CREATE INDEX IDX_PartidaContabil
ON dbo.PartidaContabil (IdLancamentoContabil, SequencialPartida, IdCentroCusto, IdContaContabilDeb, IdContaContabilCred)
ON [PRIMARY]
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdCentroCusto FOREIGN KEY (IdCentroCusto) REFERENCES dbo.CentroCusto (IdCentroCusto)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdCliFor FOREIGN KEY (IdCliFor) REFERENCES dbo.CliFor (IdCliFor)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdContaContabilCred FOREIGN KEY (IdContaContabilCred) REFERENCES dbo.ContaContabil (IdContaContabil)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdContaContabilDeb FOREIGN KEY (IdContaContabilDeb) REFERENCES dbo.ContaContabil (IdContaContabil)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdLancamentoContabil FOREIGN KEY (IdLancamentoContabil) REFERENCES dbo.LancamentoContabil (IdLancamentoContabil)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdMoeda FOREIGN KEY (IdMoeda) REFERENCES dbo.ITS_MOEDA (IdMoeda)
GO

ALTER TABLE dbo.PartidaContabil
ADD CONSTRAINT FK_PartidaContabil_IdMoeda2 FOREIGN KEY (IdMoeda2) REFERENCES dbo.ITS_MOEDA (IdMoeda)
GO