EXEC sp_rename 'ItemVenda.IdVendaItem', 'IdVenda', 'COLUMN';
EXEC sp_rename 'ItemVenda.IdProdutoItem', 'IdProduto', 'COLUMN';
EXEC sp_rename 'MovimentoCaixa.IdVendaCaixa', 'IdVenda', 'COLUMN';
EXEC sp_rename 'EmpresaMatriz.IdEmpresaMatriz', 'IdMatriz', 'COLUMN';
EXEC sp_rename 'EmpresaFilial.IdEmpresaMatriz', 'IdMatriz', 'COLUMN';

--Alterei no DDL antes de criar 
--EXEC sp_rename 'ContaBancariaCliFor.Banco', 'NomeBanco', 'COLUMN';

CREATE TABLE [dbo].[Cheque] (
  [IdCheque] [int] IDENTITY,
  [NumeroCheque] [varchar](45) NULL,
  [DataLancamento] [datetime] NOT NULL,
  [DataVencimento] [date] NOT NULL,
  [DataCompensacao] [date] NULL,
  [IdCliente] [int] NOT NULL,
  [Prazo] [int] NOT NULL,
  [Compensacao] [int] NOT NULL,
  [TaxaJuros] [decimal](18, 2) NOT NULL,
  [ValorLiquido] [decimal](18, 2) NOT NULL,
  [ValorJuros] [decimal](18, 2) NOT NULL,
  [ValorCheque] [decimal](18, 2) NOT NULL,
  [TipoLancamento] [int] NOT NULL,
  [Observacao] [text] NULL,
  [Situacao] [int] NOT NULL,
  CONSTRAINT [PK_dbo.Cheque] PRIMARY KEY CLUSTERED ([IdCheque]),
  CONSTRAINT [FK_dbo.Cheque_dbo.CliFor_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[CliFor] ([IdCliFor])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO

CREATE INDEX [IX_IdCliente]
  ON [dbo].[Cheque] ([IdCliente])
  ON [PRIMARY]