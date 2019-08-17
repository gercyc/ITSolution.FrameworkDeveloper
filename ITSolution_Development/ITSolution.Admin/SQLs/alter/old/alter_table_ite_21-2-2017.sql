ALTER TABLE AnexoLancamento
ALTER COLUMN IdentificacaoAnexo VARCHAR(150) NULL

ALTER TABLE AnexoLancamento
ALTER COLUMN FileName VARCHAR(200) NULL

ALTER TABLE ContaContabil
ALTER COLUMN CodigoContaContabil VARCHAR(200) NOT NULL

ALTER TABLE ContaContabil
ALTER COLUMN CodigoReduzido VARCHAR(100) NULL


CREATE INDEX IX_IdMoeda
ON dbo.ITS_COTACAO_MONETARIA (IdMoeda)
ON [PRIMARY]

ALTER TABLE NotaFiscalCapa
ALTER COLUMN
NumeroMovimento VARCHAR(10) NULL

ALTER TABLE NotaFiscalCapa
ALTER COLUMN
NumeroMovimento VARCHAR(10) NULL

ALTER TABLE NotaFiscalCapa
ALTER COLUMN
IdLocalEstoque INT NOT NULL


ALTER TABLE NotaFiscalCapa
ADD IdTipoMovimento INT NOT NULL,
CONSTRAINT [FK_dbo.NotaFiscalCapa_dbo.TipoMovimento_IdTipoMovimento] FOREIGN KEY (IdTipoMovimento) REFERENCES dbo.TipoMovimento (IdTipoMovimento)
GO

--DROP TABLE TipoMovimento;
CREATE TABLE TipoMovimento (
  IdTipoMovimento INT IDENTITY,
  CodigoTipoMovimento VARCHAR(6) NULL,
  DescricaoTipoMovimento VARCHAR(200) NULL,
  CategoriaTipoMovimento INT NOT NULL,
  Direcao INT NOT NULL,
  Numeracao INT NOT NULL,
  MovimentarEstoque BIT NOT NULL,
  IdLocalEstoque INT NULL,
  GeraMovimentoFiscal BIT NOT NULL,
  GerarFaturamento BIT NOT NULL,
  IdFormaPagamentoDefault INT NULL,
  InformarCentro BIT NOT NULL,
  IdCentroCustoDefault INT NULL,
  CONSTRAINT [PK_dbo.TipoMovimento] PRIMARY KEY CLUSTERED (IdTipoMovimento),
  CONSTRAINT [FK_dbo.TipoMovimento_dbo.CentroCusto_IdCentroCustoDefault] FOREIGN KEY (IdCentroCustoDefault) REFERENCES dbo.CentroCusto (IdCentroCusto),
  CONSTRAINT [FK_dbo.TipoMovimento_dbo.FormaPagamento_IdFormaPagamentoDefault] FOREIGN KEY (IdFormaPagamentoDefault) REFERENCES dbo.FormaPagamento (IdFormaPagamento),
  CONSTRAINT [FK_dbo.TipoMovimento_dbo.LocalEstoque_IdLocalEstoque] FOREIGN KEY (IdLocalEstoque) REFERENCES dbo.LocalEstoque (IdLocalEstoque)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdCentroCustoDefault
ON dbo.TipoMovimento (IdCentroCustoDefault)
ON [PRIMARY]
GO

CREATE INDEX IX_IdFormaPagamentoDefault
ON dbo.TipoMovimento (IdFormaPagamentoDefault)
ON [PRIMARY]
GO

CREATE INDEX IX_IdLocalEstoque
ON dbo.TipoMovimento (IdLocalEstoque)
ON [PRIMARY]

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Cotacao = 1, PedidoCompra = 2, PedidoVenda = 3, NotaFiscalMercadorias = 4, NotaFiscalServico = 5, NotaFiscalConjugada = 6, NotaFiscalExportacao = 7, NotaFiscalImportacao = 8, MovimentoEstoque = 9',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'CategoriaTipoMovimento'
GO

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Entrada = 0, Saida = 1',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'Direcao'
GO

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Manual = 1, Automatica = 2',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'Numeracao'
GO

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Sim = true, Nao = false',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'MovimentarEstoque'
GO

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Sim = true, Nao = false',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'GerarFaturamento'
GO

EXEC sys.sp_addextendedproperty N'MS_Description',
                                N'Sim = true, Nao = false',
                                'SCHEMA',
                                N'dbo',
                                'TABLE',
                                N'TipoMovimento',
                                'COLUMN',
                                N'InformarCentro'
GO


CREATE INDEX IX_IdTipoMovimento
ON dbo.NotaFiscalCapa (IdTipoMovimento)
ON [PRIMARY]
GO
UPDATE TipoMovimento
SET GeraMovimentoFiscal = 1