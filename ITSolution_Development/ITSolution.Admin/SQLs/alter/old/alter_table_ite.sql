--09-04-2017
ALTER TABLE Usuario
ALTER COLUMN Skin VARCHAR(200);

--07/04/2017 - Gercy Campos
--Renomear ItemMovimento.IdCapa para IdMovimento
EXEC sp_rename 'ItemMovimento.IdCapa',
               'IdMovimento',
               'COLUMN';

--06/04/2017 - Gercy - criacao de parametro para como sera gerado o relatorio
INSERT INTO dbo.Parametro(CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro) 
VALUES(N'report_eng', 
		N'1', 
		CONVERT(bit, 'False'), 
		N'Forma de geração do relatório. 
			1 = Gera e visualiza sem gravar no spool, 
			2 = Gera e visualiza gravando no spool, 
			3 = Gera somente em spool.')
GO


--28/02/2017
--ALTER TABLE Movimento
--ADD TotalMovimento INT NULL; --Cancelado por Gercy em 30/03/2017. Coluna é decimal mesmo


UPDATE Movimento
SET TotalMovimento = 0

EXEC sp_rename 'Movimento.IdCapa',
               'IdMovimento',
               'COLUMN';

ALTER TABLE Movimento
ALTER COLUMN TotalMovimento INT NOT NULL;

--27/03/2017 - Gercy - Task 113

alter TABLE Evento
  ADD CodigoCalculo INT NULL;

UPDATE Evento
  SET CodigoCalculo = 0
  WHERE CodigoEvento IN ('004','005');

UPDATE Evento
  SET CodigoCalculo = 1
  WHERE CodigoEvento IN ('001','002','011');

UPDATE Evento
  SET CodigoCalculo = 2
  WHERE CodigoEvento IN ('003');

UPDATE Evento
  SET CodigoCalculo = 3
  WHERE CodigoEvento IN ('010');

UPDATE Evento
  SET CodigoCalculo = 4
  WHERE CodigoEvento IN ('006');

UPDATE Evento
  SET CodigoCalculo = 7
  WHERE CodigoEvento IN ('007','008');

UPDATE Evento
  SET CodigoCalculo = 8
  WHERE CodigoEvento IN ('009');



--22/03/2017 - Gercy - Task 91

CREATE TABLE ContaBancariaCliFor (
  IdContaCliFor INT IDENTITY,
  IdCliFor INT NOT NULL,
  NomeBanco VARCHAR(50) NULL,
  Agencia VARCHAR(5) NULL,
  ContaBancaria VARCHAR(10) NULL,
  CONSTRAINT PK_ContaBancariaCliFor_IdContaCliFor PRIMARY KEY CLUSTERED (IdContaCliFor),
  CONSTRAINT FK_ContaBancariaCliFor_IdCliFor FOREIGN KEY (IdCliFor) REFERENCES dbo.CliFor (IdCliFor)
) ON [PRIMARY]
GO
--dados identicos não podem se repetir.
CREATE UNIQUE INDEX UK_ContaBancariaCliFor
ON ContaBancariaCliFor (IdCliFor, NomeBanco, Agencia, ContaBancaria)
ON [PRIMARY]
GO

--01/03/2017
UPDATE Produto Set MargemLucro =   (PrecoVenda-p.PrecoCompra)/PrecoVenda*100  
FROM  Produto p WHERE p.PrecoCompra > 0

/*SELECT
p.PrecoCompra, P.PrecoVenda,
(p.PrecoVenda-p.PrecoCompra)/p.PrecoVenda*100  
FROM  Produto p WHERE p.PrecoCompra > 0*/
--MargemLucro =(PrecoCompra/PrecoCompra)*0.1 
EXEC sp_rename 'TransacoesProduto.IdNotaFiscal', 'IdMovimento', 'COLUMN';

ALTER TABLE TransacoesProduto
ALTER COLUMN IdMovimento INT NULL;

--27/02/2017 - Gercy - Renomeia as tabelas do movimento (item e imposto)
EXEC sp_rename 'NotaFiscalItem', 'ItemMovimento'
GO 
EXEC sp_rename 'NotaFiscalItemImposto', 'ImpostoItemMovimento'
--27/02/2017
ALTER TABLE Venda
ALTER COLUMN Observacao TEXT NULL;

ALTER TABLE LancamentoFinanceiro
ALTER COLUMN Observacao TEXT NULL;

ALTER TABLE LancamentoFinanceiro
ALTER COLUMN IdCliFor INT NOT NULL;

ALTER TABLE LancamentoFinanceiro
ALTER COLUMN RecCreatedBy INT NOT NULL;

ALTER TABLE AnexoLancamento
ALTER COLUMN PathFile VARCHAR(1000) NULL

ALTER TABLE AnexoLancamento
ALTER COLUMN FileName VARCHAR(200) NULL

UPDATE Produto SET StatusProduto = 0 where QuantidadeProduto > 0
UPDATE Produto SET StatusProduto = 2 where QuantidadeProduto = 0

UPDATE Produto
SET CodigoBarras = CONCAT('0000', IdProduto)
WHERE CodigoBarras IS NULL
OR LEN(CodigoBarras) = 1
GO
UPDATE Produto
SET CodigoBarras = CONCAT('000', IdProduto)
WHERE CodigoBarras IS NULL
OR LEN(CodigoBarras) = 2
GO

UPDATE Produto
SET CodigoBarras = CONCAT('00', IdProduto)
WHERE CodigoBarras IS NULL
OR LEN(CodigoBarras) = 3

GO
UPDATE Produto
SET CodigoBarras = CONCAT('0', IdProduto)
WHERE CodigoBarras IS NULL
OR LEN(CodigoBarras) = 4
GO
UPDATE Produto
SET CodigoBarras = CONCAT('', IdProduto)
WHERE CodigoBarras IS NULL
OR LEN(CodigoBarras) > 5
GO
ALTER TABLE Produto
ALTER COLUMN CodigoBarras VARCHAR(200) NOT NULL;

ALTER TABLE ITS_DASHBOARD_IMAGE
ALTER COLUMN DashboardName VARCHAR(200);

ALTER TABLE ITS_DASHBOARD_IMAGE
ALTER COLUMN DashboardName VARCHAR(200);

ALTER TABLE ITS_COTACAO_MONETARIA
ALTER COLUMN ValorVenda DECIMAL(18, 4);

ALTER TABLE ITS_COTACAO_MONETARIA
ALTER COLUMN ValorCompra DECIMAL(18, 4);


--24/02/2017
--Altera o nome da tabela pro nome da classe
EXEC sp_rename 'NotaFiscalCapa', 'Movimento';

--19/02/2017 - Gercy - Alteracoes na tabela de notafiscal/movimento

EXEC sp_rename 'NotaFiscalCapa.NumeroNf', 'NumeroMovimento', 'COLUMN';
EXEC sp_rename 'NotaFiscalCapa.TipoNf', 'DirecaoMovimento', 'COLUMN';

ALTER TABLE SituacaoDocumentoFiscal
  ADD TipoSituacao VARCHAR(3);

ALTER TABLE NotaFiscalCapa
  ALTER COLUMN IdFormaPagamento INT NULL;

ALTER TABLE NotaFiscalCapa
  ALTER COLUMN IdModelo INT NULL;

ALTER TABLE NotaFiscalCapa
  ALTER COLUMN IdCliFor INT NULL;

ALTER TABLE dbo.NotaFiscalCapa
	ADD IdLocalEstoque INT NULL,
  CONSTRAINT FK_NotaFiscalCapa_LocalEstoque_IdLocalEstoque FOREIGN KEY (IdLocalEstoque) REFERENCES dbo.LocalEstoque (IdLocalEstoque)
GO
UPDATE NotaFiscalCapa
  SET IdLocalEstoque = 1
  WHERE IdLocalEstoque IS NULL

--16/02/2017 - Gercy - Criacao de coluna indicadora se vai gerar mov fiscal nos movimentos
alter table TipoMovimento
add GeraMovimentoFiscal bit null;

update TipoMovimento
set GeraMovimentoFiscal = 1


--15/02/2017 - Gercy - Criacao da tabela TipoMovimento. abaixo do ddl contem os comentarios
--colunm CategoriaTipoMovimento candidata a virar uma tabela ao inves de enumerador
CREATE TABLE dbo.TipoMovimento (
  IdTipoMovimento INT IDENTITY,
  CodigoTipoMovimento VARCHAR(6) COLLATE Latin1_General_CI_AS NOT NULL,
  DescricaoTipoMovimento VARCHAR(200) COLLATE Latin1_General_CI_AS NOT NULL,
  CategoriaTipoMovimento INT NOT NULL,
  Direcao INT NOT NULL,
  Numeracao INT NOT NULL,
  MovimentarEstoque BIT NOT NULL,
  IdLocalEstoque INT NULL,
  GerarFaturamento BIT NOT NULL,
  IdFormaPagamentoDefault INT NULL,
  InformarCentro BIT NOT NULL,
  IdCentroCustoDefault INT NULL,
  CONSTRAINT PK_TipoMovimento PRIMARY KEY CLUSTERED (IdTipoMovimento),
  CONSTRAINT FK_TipoMovimento_CentroCusto_IdCentroCusto FOREIGN KEY (IdCentroCustoDefault) REFERENCES dbo.CentroCusto (IdCentroCusto),
  CONSTRAINT FK_TipoMovimento_FormaPagamento_IdFormaPagamento FOREIGN KEY (IdFormaPagamentoDefault) REFERENCES dbo.FormaPagamento (IdFormaPagamento),
  CONSTRAINT FK_TipoMovimento_LocalEstoque_IdLocalEstoque FOREIGN KEY (IdLocalEstoque) REFERENCES dbo.LocalEstoque (IdLocalEstoque)
) ON [PRIMARY]
GO

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
--popular alguns tipos de movimento 15/02/2017

INSERT TipoMovimento(CodigoTipoMovimento, DescricaoTipoMovimento, CategoriaTipoMovimento, Direcao, Numeracao, MovimentarEstoque, IdLocalEstoque, GerarFaturamento, IdFormaPagamentoDefault, InformarCentro, IdCentroCustoDefault) VALUES (N'1.1.01', N'NOTA FISCAL DE ENTRADA', 4, 0, 1, CONVERT(bit, 'True'), 1, CONVERT(bit, 'True'), 1, CONVERT(bit, 'True'), 1)
INSERT TipoMovimento(CodigoTipoMovimento, DescricaoTipoMovimento, CategoriaTipoMovimento, Direcao, Numeracao, MovimentarEstoque, IdLocalEstoque, GerarFaturamento, IdFormaPagamentoDefault, InformarCentro, IdCentroCustoDefault) VALUES (N'2.1.01', N'VENDA DE MERCADORIAS - NOTA FISCAL', 4, 1, 1, CONVERT(bit, 'True'), 1, CONVERT(bit, 'True'), 2, CONVERT(bit, 'True'), 2)
INSERT TipoMovimento(CodigoTipoMovimento, DescricaoTipoMovimento, CategoriaTipoMovimento, Direcao, Numeracao, MovimentarEstoque, IdLocalEstoque, GerarFaturamento, IdFormaPagamentoDefault, InformarCentro, IdCentroCustoDefault) VALUES (N'2.1.02', N'NOTA FISCAL DE EXPORTACAO', 4, 1, 1, CONVERT(bit, 'True'), 1, CONVERT(bit, 'True'), 2, CONVERT(bit, 'True'), 2)

GO
--fim alteracoes 15/02/17


/**
* Coloque as alterações em ordem predatas e comentadas
*/
--23/01/2016
CREATE TABLE ContaContabil (
  IdContaContabil INT IDENTITY,
  IdMatriz INT NOT NULL,
  CodigoContaContabil VARCHAR(200) NOT NULL,
  CodigoReduzido VARCHAR(100) NULL,
  DescricaoContaContabil VARCHAR(200) NOT NULL,
  IndAnaliticaSintetica INT NOT NULL,
  TipoContaSped INT NULL,
  Natureza INT NOT NULL,
  Nivel INT NOT NULL,
  DataInclusao DATETIME NOT NULL,
  DataAlteracao DATETIME NULL,
  CONSTRAINT [PK_dbo.ContaContabil] PRIMARY KEY CLUSTERED (IdContaContabil),
  CONSTRAINT FK_ContaContabil_EmpresaMatriz_IdEmpresaMatriz FOREIGN KEY (IdMatriz) REFERENCES dbo.EmpresaMatriz (IdEmpresaMatriz)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX IDX_CODCT_RED
ON ContaContabil (CodigoReduzido)
ON [PRIMARY]
GO

CREATE UNIQUE INDEX IDX_UNIQUE_CCT
ON ContaContabil (IdMatriz, CodigoContaContabil)
ON [PRIMARY]
GO
--Popular
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1', N'100000', N'ATIVO', 0, 1, 1, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1', N'110000', N'CIRCULANTE', 0, 1, 1, 2, '2008-01-01 00:00:00.000', '2013-06-17 09:19:57.810')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.1', N'111000', N'DISPONIBILIDADES', 0, 1, 1, 3, '2008-01-01 00:00:00.000', '2013-06-17 09:18:52.460')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.1.01', N'111100', N'CAIXA', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.1.02', N'112000', N'BANCOS C/ MOVIMENTO', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.1.03', N'113000', N'APLICAÇÕES FINANCEIRAS', 0, 1, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.2.03', N'114000', N'ADIANTAMENTOS S/  CONTR. DE CÂMBIO', 0, 1, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3', N'120000', N'OUTROS CRÉDITOS', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.01', N'121000', N'OUTRAS CONTAS A RECEBER', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.02', N'122000', N'ADIANTAMENTOS A FORNECEDORES', 0, 1, 1, 4, '2008-01-01 00:00:00.000', '2013-06-17 15:15:49.577')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.03', N'123000', N'ADIANTAMENTOS A FUNCIONÁRIOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.05', N'125000', N'SALÁRIO FAMÍLIA/MATERNIDADE A RECUPERAR', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.06', N'126000', N'IMPOSTOS A RECUPERAR', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.3.07', N'127000', N'DEPÓSITO JUDICIAL', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.4', N'130000', N'ESTOQUES', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.4.01', N'131000', N'ESTOQUES DE PRODUTOS E MERCADORIAS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.4.02', N'132000', N'ESTOQUES DE BOVINOS E MERCADORIAS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', '2012-03-15 07:26:20.560')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.5', N'140000', N'DESPESAS A APROPRIAR', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.5.01', N'141000', N'DESPESAS DO EXERC. SEGUINTE (DIFERIDAS)', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2', N'160000', N'NÃO CIRCULANTE', 0, 1, 1, 2, '2008-01-01 00:00:00.000', '2013-06-17 09:21:02.160')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2.1', N'161000', N'REALIZÁVEL A LONGO PRAZO', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2.1.01', N'161100', N'APLICAÇÕES FINANCEIRAS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2.1.02', N'161200', N'CRÉDITOS E VALORES', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2.1.03', N'161300', N'IMPOSTOS A RECUPERAR', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.2.1.04', N'161400', N'DEPÓSITO JUDICIAL', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.2', N'200000', N'CLIENTES', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.2.01', N'201000', N'CLIENTES MERCADO INTERNO', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.1.2.02', N'250000', N'CLIENTES MERCADO EXTERNO', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3', N'300000', N'NÃO CIRCULANTE', 0, 1, 1, 2, '2008-01-01 00:00:00.000', '2013-06-27 09:28:48.970')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3', N'330000', N'IMOBILIZADO', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.01', N'331000', N'IMÓVEIS RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.02', N'332000', N'TERRENOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.03', N'333000', N'EDIFICAÇÕES', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.04', N'334000', N'INSTALAÇÕES INDUSTRIAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.05', N'335000', N'MÁQUINAS E EQUIPAMENTOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.06', N'336000', N'VEÍCULOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.07', N'337000', N'EQUIP. DE INFORM., COMUN. E ESCRITÓRIO', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.08', N'338000', N'SISTEMAS E APLICATIVOS (SOFTWARE)', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.09', N'339000', N'MÓVEIS E UTENSÍLIOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.10', N'340000', N'FERRAMENTAS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.12', N'342000', N'BOVINOS - MATRIZES', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.13', N'343000', N'EQUÍDEOS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.14', N'344000', N'IMÓVEIS RURAIS (AGROPECUÁRIA)', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.15', N'345000', N'EDIFICAÇÕES RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.16', N'346000', N'INSTALAÇÕES RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.17', N'347000', N'VEÍCULOS, MÁQUINAS E EQUIPAMENTOS RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.18', N'348000', N'EQUIP. DE INFORMÁT. E COMUNICAÇÃO RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.19', N'349000', N'MÓVEIS, UTENSÍLIOS E FERRAMENTAS RURAIS', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.3.30', N'370000', N'( - ) DEPRECIAÇÃO ACUMULADA', 0, 1, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.5', N'380000', N'INTANGÍVEL', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.5.01', N'381000', N'INTANGÍVEL', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.5.10', N'385000', N'( - ) AMORTIZAÇÃO E EXAUSTÃO ACUMULADAS', 0, 1, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.6', N'390000', N'DIFERIDO', 0, 1, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.6.01', N'391000', N'DIFERIDO', 0, 1, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'1.3.6.10', N'395000', N'( - ) AMORTIZAÇÃO ACUMULADA', 0, 1, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2', N'400000', N'PASSIVO', 0, 2, 0, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1', N'410000', N'CIRCULANTE', 0, 2, 0, 2, '2008-01-01 00:00:00.000', '2013-06-17 09:23:12.933')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.2', N'411000', N'OBRIGAÇÕES FISCAIS', 0, 2, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.2.01', N'411100', N'IMPOSTOS E CONTRIBUIÇÕES A RECOLHER', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.2.02', N'411700', N'ENCARGOS SOCIAIS A RECOLHER', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.2.03', N'412000', N'PROVISÕES', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3', N'415000', N'OUTRAS OBRIGAÇÕES', 0, 2, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.01', N'415100', N'ORDENADOS A PAGAR', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.02', N'416000', N'OUTRAS CONTAS A PAGAR', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.03', N'417000', N'ADIANTAMENTOS DE CLIENTES', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.04', N'417500', N'OUTROS DÉBITOS', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.05', N'417600', N'NUMERÁRIOS EM TRÂNSITO', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.10', N'418000', N'EMPR. E FINANCIAMENTOS - MOEDA NACIONAL', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.11', N'419000', N'EMPR. E FINANCIAMENTOS-MOEDA ESTRANGEIRA', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.12', N'420000', N'CRÉDITOS E VALORES', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.3.13', N'421000', N'JUROS S/ O CAPITAL PRÓPRIO A PAGAR', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2', N'450000', N'NÃO CIRCULANTE', 0, 2, 0, 2, '2008-01-01 00:00:00.000', '2013-06-17 09:25:09.403')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2.1', N'451000', N'OBRIGAÇÕES A LONGO PRAZO', 0, 2, 0, 3, '2008-01-01 00:00:00.000', '2013-06-17 09:25:56.347')
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2.1.01', N'451100', N'EMPR. E FINANCIAMENTOS - MOEDA NACIONAL', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2.1.02', N'451500', N'EMPR. E FINANCIAMENTOS-MOEDA ESTRANGEIRA', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2.1.03', N'451700', N'DÉBITOS E VALORES', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.2.1.04', N'451800', N'OBRIGAÇÕES FISCAIS', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.1', N'500000', N'FORNECEDORES', 0, 2, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.1.01', N'501000', N'FORNECEDORES NACIONAIS', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.1.1.02', N'570000', N'FORNECEDORES INTERNACIONAIS', 0, 2, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4', N'600000', N'PATRIMÔNIO LÍQUIDO', 0, 3, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1', N'610000', N'PATRIMÔNIO LÍQUIDO', 0, 3, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1.01', N'611000', N'CAPITAL SOCIAL', 0, 3, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1.02', N'612000', N'RESERVAS DE CAPITAL', 0, 3, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1.03', N'613000', N'RESERVAS DE REAVALIAÇÃO', 0, 3, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1.04', N'614000', N'RESERVAS DE LUCROS', 0, 3, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'2.4.1.10', N'620000', N'LUCROS OU PREJUÍZOS ACUMULADOS', 0, 3, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3', N'700000', N'CUSTOS E DESPESAS', 0, 4, 1, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.1', N'710000', N'CUSTO DOS PRODUTOS VENDIDOS', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.1.1', N'711000', N'CUSTO DOS PRODUTOS VENDIDOS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.1.1.01', N'711100', N'CUSTO DOS PRODUTOS VENDIDOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.2', N'720000', N'CUSTO DAS MERCADORIAS REVENDIDAS', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.2.1', N'721000', N'CUSTO DAS MERCADORIAS REVENDIDAS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.2.1.01', N'721100', N'MERCADORIAS ADQUIRIDAS DE TERCEIROS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.3', N'722000', N'CUSTO DOS PRODUTOS PECUÁRIOS VENDIDOS', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.3.1', N'722100', N'CUSTO DOS PRODUTOS PECUÁRIOS VENDIDOS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.3.1.01', N'722110', N'CUSTO DOS PRODUTOS PECUÁRIOS VENDIDOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4', N'730000', N'CUSTOS', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4.1', N'731000', N'MINERAÇÃO', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4.1.01', N'731100', N'MATERIAIS DIRETOS - EXTRAÇÃO', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4.1.02', N'732000', N'MÃO-DE-OBRA DIRETA', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4.1.03', N'733000', N'OUTROS CUSTOS DIRETOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.4.1.04', N'734000', N'CUSTOS INDIRETOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5', N'740000', N'CUSTOS DE PRODUÇAO', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1', N'741000', N'INDÚSTRIAS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1.01', N'741100', N'MATÉRIA PRIMA DIRETA', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1.02', N'742000', N'OUTROS MATERIAIS DIRETOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1.03', N'743000', N'MÃO-DE-OBRA DIRETA', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1.04', N'744000', N'OUTROS CUSTOS DIRETOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.5.1.05', N'745000', N'CUSTOS INDIRETOS DA PRODUÇÃO', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.6', N'760000', N'CUSTOS DE PRODUÇÃO DA PECUÁRIA', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.6.1', N'761000', N'CUSTOS DO REBANHO', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.6.1.01', N'761100', N'CUSTOS DO REBANHO BOVINO', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.6.1.02', N'762000', N'MÃO-DE-OBRA DIRETA', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.6.1.03', N'763000', N'CUSTOS INDIRETOS DA PRODUÇÃO PECUÁRIA', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9', N'800000', N'DESPESAS', 0, 4, 1, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1', N'810000', N'DESPESAS OPERACIONAIS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1.01', N'811000', N'DESPESAS C/ VENDAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1.02', N'812000', N'DESPESAS ADMINISTRATIVAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1.03', N'813000', N'DESPESAS TRIBUTÁRIAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1.04', N'814000', N'DESPESAS FINANCEIRAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.1.06', N'816000', N'DESPESAS DAS FAZENDAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.2', N'820000', N'DESPESAS NÃO OPERACIONAIS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.2.01', N'821000', N'DESPESAS NÃO OPERACIONAIS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.3', N'830000', N'DESPESAS NÃO DEDUTÍVEIS', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.3.01', N'831000', N'DESPESAS NÃO DEDUTÍVEIS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.4', N'840000', N'PROVISÕES', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'3.9.4.01', N'841000', N'PROVISÕES', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4', N'900000', N'RECEITAS', 0, 4, 0, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1', N'910000', N'RECEITAS OPERACIONAIS', 0, 4, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.1', N'911000', N'RECEITA BRUTA DAS VENDAS', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.1.01', N'911100', N'RECEITA BRUTA DAS VENDAS DE PRODUTOS', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.1.02', N'912000', N'RECEITA BRUTA DE REVENDA DE MERCADORIAS', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.1.21', N'921000', N'VENDA DE RESÍDUOS DE FABRICAÇÃO E SUCATA', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.1.22', N'922000', N'RECEITA BRUTA DA VENDA DE PROD. PECUÁRIO', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.2', N'930000', N'DEDUÇÕES DA RECEITA BRUTA', 0, 4, 1, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.2.01', N'931000', N'IMPOSTOS INCIDENTES S/ VENDAS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.2.02', N'932000', N'VENDAS CANCELADAS E DEVOLUÇÕES', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.2.03', N'933000', N'DESCONTOS CONCEDIDOS', 0, 4, 1, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.3', N'940000', N'RECEITAS FINANCEIRAS', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.3.01', N'941000', N'RECEITAS FINANCEIRAS', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.4', N'946000', N'OUTRAS RECEITAS', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.1.4.01', N'946100', N'OUTRAS RECEITAS OPERACIONAIS', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.2', N'950000', N'RECEITAS NÃO OPERACIONAIS', 0, 4, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.2.1', N'951000', N'RECEITAS NÃO OPERACIONAIS', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.2.1.01', N'951100', N'RECEITAS NÃO OPERACIONAIS', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.3', N'960000', N'REVERSÕES', 0, 4, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.3.1', N'961000', N'REVERSÕES DE PROVISÕES', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'4.3.1.01', N'961100', N'REVERSÕES DE PROVISÕES', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'5', N'980000', N'CONTAS DE APURAÇÃO', 0, 4, 0, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'5.1', N'981000', N'CONTAS DE APURAÇÃO', 0, 4, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'5.1.1', N'981100', N'APURAÇÃO DO RESULTADO', 0, 4, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'5.1.1.01', N'981110', N'APURAÇÃO DO RESULTADO', 0, 4, 0, 4, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'6', N'990000', N'SISTEMA AUXILIAR', 0, 9, 0, 1, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'6.1', N'991000', N'CONTAS DE COMPENSAÇÃO', 0, 9, 0, 2, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'6.1.1', N'991100', N'CONTAS DE COMPENSAÇÃO', 0, 9, 0, 3, '2008-01-01 00:00:00.000', NULL)
INSERT ContaContabil(IdMatriz, CodigoContaContabil, CodigoReduzido, DescricaoContaContabil, IndAnaliticaSintetica, TipoContaSped, Natureza, Nivel, DataInclusao, DataAlteracao) VALUES (1, N'6.1.1.01', N'991110', N'BENS DE TERCEIROS', 0, 9, 0, 4, '2008-01-01 00:00:00.000', NULL)



-- 20/01/2016
-- Add de 2 tabelas
CREATE TABLE dbo.ITS_MOEDA (
  IdMoeda INT IDENTITY,
  NomeMoeda VARCHAR(500) COLLATE Latin1_General_CI_AS NOT NULL,
  CodigoWSCompra BIGINT NOT NULL,
  CodigoWSVenda BIGINT NOT NULL,
  CONSTRAINT [PK_dbo.ITS_COD_MOEDA_BACEN] PRIMARY KEY CLUSTERED (IdMoeda)
) ON [PRIMARY]
GO
 
CREATE TABLE dbo.ITS_COTACAO_MONETARIA (
  IdCotacaoMonetaria INT IDENTITY,
  DataCotacao DATETIME NOT NULL,
  ValorCompra DECIMAL(18, 4) NOT NULL,
  ValorVenda DECIMAL(18, 4) NOT NULL,
  IdMoeda INT NOT NULL,
  CONSTRAINT [PK_dbo.ITS_COTACAO_MONETARIA] PRIMARY KEY CLUSTERED (IdCotacaoMonetaria),
  CONSTRAINT [FK_dbo.ITS_COTACAO_MONETARIA_dbo_IdMoeda] FOREIGN KEY (IdMoeda) REFERENCES dbo.ITS_MOEDA_FACHADAWSSGS (IdMoeda) ON DELETE CASCADE
) ON [PRIMARY]
GO

--13/01/2016
-- Inclusa do campo logo na filial e matriz
ALTER TABLE EmpresaMatriz
	ADD Logo VARBINARY(MAX) NULL

ALTER TABLE EmpresaFilial
	ADD Logo VARBINARY(MAX) NULL

-- 29/12/2016
ALTER TABLE Ncms
ADD UnidadeMedida VARCHAR(10) NOT NULL

CREATE TABLE dbo.SkinDevExpress (
  IdSkin int IDENTITY,
  SkinName varchar(100) NULL,
  SkinNamePr varchar(100) NULL,
  SkinGroup int NOT NULL,
  CONSTRAINT [PK_dbo.SkinDevExpress] PRIMARY KEY CLUSTERED (IdSkin)
)
ON [PRIMARY]
--LANCAMENTO Cliente Nao nulo
--		     Usuario Nao nulo
--Anexo
--[StringLength(1000)]
--'public string PathFile { get; set; }'
       
--[StringLength(100)]
--public string FileName { get; set; }

--23/12/2016
EXEC sp_rename 'NotaFiscalCapa.IdCliForEntrada', 'IdCliFor', 'COLUMN'

ALTER TABLE LancamentoFinanceiro
ADD IdNotaFiscal INT NULL,
CONSTRAINT [FK_dbo.LancamentoFinanceiro_dbo.NotaFiscalCapa] 
FOREIGN KEY (IdNotaFiscal)REFERENCES dbo.NotaFiscalCapa  (IdCapa )

ALTER TABLE NotaFiscalCapa
ADD IdUsuario INT NOT NULL,
CONSTRAINT [FK_dbo.NotaFiscalCapa_dbo.Usuario] FOREIGN KEY (IdUsuario)
REFERENCES dbo.Usuario (IdUsuario)

ALTER TABLE NotaFiscalCapa
ADD IdFormaPagamento INT NULL,
CONSTRAINT [FK_dbo.NotaFiscalCapa_dbo.FormaPagamento] FOREIGN KEY (IdFormaPagamento)
REFERENCES dbo.FormaPagamento (IdFormaPagamento)

ALTER TABLE NotaFiscalCapa
ADD IdCentroCusto INT NULL,
CONSTRAINT [FK_dbo.NotaFiscalCapa_dbo.CentroCusto] FOREIGN KEY (IdCentroCusto)
REFERENCES dbo.CentroCusto (IdCentroCusto)

--22-12-2016
ALTER TABLE LancamentoFinanceiro
ADD IdNotaFiscal INT NULL    	    
CONSTRAINT [FK_dbo.LancamentoFinanceiro_dbo.NotaFiscalCapa] FOREIGN KEY (IdNotaFiscal) 
REFERENCES dbo.NotaFiscalCapa (IdCapa)

--Para evitar problema coloquei o valor default como dinheiro
ALTER TABLE LancamentoFinanceiro
ADD IdFormaPagamento INT NULL DEFAULT 1,
CONSTRAINT [FK_dbo.LancamentoFinanceiro_dbo.FormaPagamento] FOREIGN KEY (IdFormaPagamento) 
REFERENCES dbo.FormaPagamento (IdFormaPagamento)	

-- ALTER 18/12
-- Use o compare ou altere manualmente
-- Estrutura nova da tabela MovimentoCaixa
  
CREATE TABLE dbBalcao_DEV.dbo.MovimentoCaixa (
  IdMovimento INT IDENTITY,
  IdVendaCaixa INT NULL,
  IdUsuario INT NOT NULL,
  TipoMov INT NOT NULL,
  ValorMovimento DECIMAL(18, 2) NOT NULL,
  DataMovimento DATETIME NOT NULL,
  HistoricoMov VARCHAR(500) NOT NULL,
  CONSTRAINT [PK_dbo.MovimentoCaixa] PRIMARY KEY CLUSTERED (IdMovimento),
  CONSTRAINT [FK_dbo.MovimentoCaixa_dbo.Usuario_IdUsuario] FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (IdUsuario),
  CONSTRAINT [FK_dbo.MovimentoCaixa_dbo.Venda_IdVendaCaixa] FOREIGN KEY (IdVendaCaixa) REFERENCES dbo.Venda (IdVenda)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdFormaPagto
ON dbBalcao_DEV.dbo.MovimentoCaixa (IdUsuario)
ON [PRIMARY]
GO

CREATE INDEX IX_IdVendaCaixa
ON dbBalcao_DEV.dbo.MovimentoCaixa (IdVendaCaixa)
ON [PRIMARY]
GO
-- Fix do Movimento do caixa
UPDATE  MovimentoCaixa  
SET     MovimentoCaixa .IdUsuario  = v.IdUsuarioVenda
FROM Venda v 
JOIN MovimentoCaixa 
ON MovimentoCaixa.IdVendaCaixa = v.IdVenda

--Atualizar movimentos inconsistentes
UPDATE MovimentoCaixa SET TipoMov = 1 where IdVendaCaixa IS NOT NULL
UPDATE  MovimentoCaixa  SET IdUsuario = 1 WHERE IdVendaCaixa IS NULL

UPDATE LancamentoFinanceiro SET SequencialParcela = 1 WHERE SequencialParcela = 0
UPDATE LancamentoFinanceiro SET
  Observacao = CONCAT('Ref. Venda Nº.: ', IdVenda,' | Parcela Nº:', SequencialParcela);



DROP TABLE ControleCaixa

-- Novas colunas
ALTER TABLE dbo.LancamentoFinanceiro ADD MotivoCancelamento VARCHAR(100);
ALTER TABLE dbo.LancamentoFinanceiro ADD DataCancelamento  DATETIME;
      

 


--BACKUP NO ONE DRIVE
--30/11/2016
EXEC sp_rename 'CliFor.NomeCliente', 'RazaoSocial', 'COLUMN';  
EXEC sp_rename 'CliFor.Situacao', 'SituacaoJuridica', 'COLUMN';  
EXEC sp_rename 'CliFor.Status', 'StatusCliente', 'COLUMN';  
EXEC sp_rename 'LancamentoFinanceiro.Status', 'StatusLancamento', 'COLUMN';  

UPDATE UnidadeMedida SET  UnidadeMedida.NomeUnidadeMedida = UPPER(NomeUnidadeMedida);

--Novo errado da tabela de empresas
-- O campo email agora tem tamanho 100
-- Correcao nome da coluna
EXEC sp_rename 'EmpresaFilial.EmailMatriz', 'Email', 'COLUMN';  
EXEC sp_rename 'EmpresaMatriz.EmailMatriz', 'Email', 'COLUMN';  

--30/11/2016
-- Novas tabelas 
CREATE TABLE AtividadePrincipalEmpresaMatriz (
  IdAtividade INT IDENTITY,
  IdMatriz INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadePrincipalEmpresaMatriz PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadePrincipalEmpresaMatriz_dbo.EmpresaMatriz_IdMatriz] FOREIGN KEY (IdMatriz) REFERENCES dbo.EmpresaMatriz (IdEmpresaMatriz)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdMatriz
ON AtividadePrincipalEmpresaMatriz (IdMatriz)
ON [PRIMARY]
GO

CREATE TABLE AtividadeSecundariaEmpresaMatriz (
  IdAtividade INT IDENTITY,
  IdMatriz INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadeSecundariaEmpresaMatriz PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadeSecundariaEmpresaMatriz_dbo.EmpresaMatriz_IdMatriz] FOREIGN KEY (IdMatriz) REFERENCES dbo.EmpresaMatriz (IdEmpresaMatriz)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdMatriz
ON AtividadeSecundariaEmpresaMatriz (IdMatriz)
ON [PRIMARY]
GO

CREATE TABLE AtividadePrincipalEmpresaFilial (
  IdAtividade INT IDENTITY,
  IdFilial INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadePrincipalEmpresaFilial PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadePrincipalEmpresaFilial_dbo.EmpresaFilial_IdFilial] FOREIGN KEY (IdFilial) REFERENCES dbo.EmpresaFilial (IdFilial)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdFilial
ON AtividadePrincipalEmpresaFilial (IdFilial)
ON [PRIMARY]
GO

CREATE TABLE AtividadeSecundariaEmpresaFilial (
  IdAtividade INT IDENTITY,
  IdFilial INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadeSecundariaEmpresaFilial PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadeSecundariaEmpresaFilial_dbo.EmpresaFilial_IdFilial] FOREIGN KEY (IdFilial) REFERENCES dbo.EmpresaFilial (IdFilial)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdFilial
ON AtividadeSecundariaEmpresaFilial (IdFilial)
ON [PRIMARY]
GO

CREATE TABLE AtividadePrincipalCliFor (
  IdAtividade INT IDENTITY,
  IdCliFor INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadePrincipalCliFor PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadePrincipalCliFor_dbo.CliFor_IdCliFor] FOREIGN KEY (IdCliFor) REFERENCES dbo.CliFor (IdCliFor)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdCliFor
ON AtividadePrincipalCliFor (IdCliFor)
ON [PRIMARY]
GO

CREATE TABLE AtividadeSecundariaCliFor (
  IdAtividade INT IDENTITY,
  IdCliFor INT NOT NULL,
  Codigo VARCHAR(20) NULL,
  Descricao VARCHAR(300) NULL,
  CONSTRAINT PK_AtividadeSecundariaCliFor PRIMARY KEY CLUSTERED (IdAtividade),
  CONSTRAINT [FK_dbo.AtividadeSecundariaCliFor_dbo.CliFor_IdCliFor] FOREIGN KEY (IdCliFor) REFERENCES dbo.CliFor (IdCliFor)
) ON [PRIMARY]
GO

CREATE INDEX IX_IdCliFor
ON AtividadeSecundariaCliFor (IdCliFor)
ON [PRIMARY]
GO



-- Add de colunas no CliFor
ALTER TABLE dbo.CliFor ADD DtRegtroJuntaCom DATETIME;
ALTER TABLE dbo.CliFor ADD DtCadastro DATETIME;
ALTER TABLE dbo.CliFor ADD InscricaoEstadual VARCHAR(25);
ALTER TABLE dbo.CliFor ADD InscricaoMunicipal VARCHAR(25);

ALTER TABLE dbo.CliFor ADD DataSituacao DATETIME;
ALTER TABLE dbo.CliFor ADD Situacao VARCHAR(45);
ALTER TABLE dbo.CliFor ADD Abertura DATETIME;
ALTER TABLE dbo.CliFor ADD NaturezaJuridica VARCHAR(100);
ALTER TABLE dbo.CliFor ADD NomeFantasia VARCHAR(100);
ALTER TABLE dbo.CliFor ADD UltimaAtualizacao DATETIME;
ALTER TABLE dbo.CliFor ADD Status VARCHAR(45);
ALTER TABLE dbo.CliFor ADD Tipo VARCHAR(45);
ALTER TABLE dbo.CliFor ADD Efr VARCHAR(45);
ALTER TABLE dbo.CliFor ADD MotivoSituacao VARCHAR(45);
ALTER TABLE dbo.CliFor ADD SituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.CliFor ADD DataSituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.CliFor ADD CapitalSocial DECIMAL(18,2);

-- Add de colunas na EmpresaMatriz 
ALTER TABLE dbo.EmpresaMatriz ADD DataSituacao DATETIME;
ALTER TABLE dbo.EmpresaMatriz ADD Situacao VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD Abertura DATETIME;
ALTER TABLE dbo.EmpresaMatriz ADD NaturezaJuridica VARCHAR(100);
ALTER TABLE dbo.EmpresaMatriz ADD NomeFantasia VARCHAR(100);
ALTER TABLE dbo.EmpresaMatriz ADD UltimaAtualizacao DATETIME;
ALTER TABLE dbo.EmpresaMatriz ADD Status VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD Tipo VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD Efr VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD MotivoSituacao VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD SituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD DataSituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.EmpresaMatriz ADD CapitalSocial DECIMAL(18,2);

-- Add de colunas na EmpresaFilial
ALTER TABLE dbo.EmpresaFilial ADD DataSituacao DATETIME;
ALTER TABLE dbo.EmpresaFilial ADD Situacao VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD Abertura DATETIME;
ALTER TABLE dbo.EmpresaFilial ADD NaturezaJuridica VARCHAR(100);
ALTER TABLE dbo.EmpresaFilial ADD NomeFantasia VARCHAR(100);
ALTER TABLE dbo.EmpresaFilial ADD UltimaAtualizacao DATETIME;
ALTER TABLE dbo.EmpresaFilial ADD Status VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD Tipo VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD Efr VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD MotivoSituacao VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD SituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD DataSituacaoEspecial VARCHAR(45);
ALTER TABLE dbo.EmpresaFilial ADD CapitalSocial DECIMAL(18,2);
--Fim das alterações em 30/11/2016