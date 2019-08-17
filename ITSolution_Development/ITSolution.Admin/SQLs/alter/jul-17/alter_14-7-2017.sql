ALTER TABLE Produto
ADD IdentificacaoProduto VARCHAR(2) NULL,
Comprimento DECIMAL(18, 2) NULL,
Largura DECIMAL(18, 2) NULL,
Espessura1 DECIMAL(18, 2) NULL,
Espessura2 DECIMAL(18, 2) NULL,
Cor VARCHAR(40) NULL,
Acabamento VARCHAR(100) NULL,
Peso DECIMAL(18,2) NULL
GO

UPDATE Produto
SET Largura = 0
   ,Comprimento = 0
   ,Espessura1 = 0
   ,Espessura2 = 0
   ,Peso = 0


WHERE Largura IS NULL
OR Comprimento IS NULL
OR Espessura1 IS NULL
OR Espessura2 IS NULL 
OR Peso IS NULL 

ALTER TABLE Usuario
ALTER COLUMN Skin VARCHAR(200) NOT NULL


--MODULO PARA EXPORTAÇÃO DE ARDOSIA
CREATE TABLE PaymentInstruction (
  IdPaymentInstruction INT IDENTITY
 ,AccountWith VARCHAR(50) NOT NULL
 ,SwiftCodeaBank VARCHAR(50) NOT NULL
 ,AccountNameBank VARCHAR(100) NOT NULL
 ,InFavorBank VARCHAR(100) NOT NULL
 ,SwitchCodeImporter VARCHAR(50) NOT NULL
 ,CreditTo VARCHAR(100) NOT NULL
 ,BranchNumberImporter VARCHAR(20) NOT NULL
 ,AccountNumber VARCHAR(20) NOT NULL
 ,CONSTRAINT PK_PaymentInstructions PRIMARY KEY CLUSTERED (IdPaymentInstruction)
) ON [PRIMARY]
GO

CREATE TABLE CommercialInvoice (
  IdInvoice INT IDENTITY
 ,IdCliFor INT NOT NULL
 ,IdUsuario INT NOT NULL
 ,NumberProcess VARCHAR(100) NOT NULL
 ,Date DATE NOT NULL
 ,Terms VARCHAR(50) NOT NULL
 ,YourOrder VARCHAR(50) NOT NULL
 ,Payment VARCHAR(50) NOT NULL
 ,Bl DATE NOT NULL
 ,PortShipment VARCHAR(100) NOT NULL
 ,PortDestiny VARCHAR(100) NOT NULL
 ,Material VARCHAR(100) NOT NULL
 ,Vessel VARCHAR(100) NOT NULL
 ,GrossWeight DECIMAL(18, 2) NOT NULL
 ,NetWeight DECIMAL(18, 2) NOT NULL
 ,Marks INT NOT NULL
 ,Ncm VARCHAR(50) NOT NULL
 ,IdPaymentInstruction INT NOT NULL
 ,CONSTRAINT PK_CommercialInvoice PRIMARY KEY CLUSTERED (IdInvoice)
) ON [PRIMARY]
GO

ALTER TABLE CommercialInvoice
ADD CONSTRAINT FK_CommercialInvoice_CliFor FOREIGN KEY (IdCliFor) REFERENCES CliFor (IdCliFor)
GO

ALTER TABLE CommercialInvoice
ADD CONSTRAINT FK_CommercialInvoice_PaymentInstruction FOREIGN KEY (IdPaymentInstruction) REFERENCES PaymentInstruction (IdPaymentInstruction)
GO

CREATE TABLE ItemCommercialInvoice (
  IdInvoice INT NOT NULL
 ,IdProduto INT NOT NULL
 ,CratesNumber INT NOT NULL
 ,TotalSqm DECIMAL NOT NULL
 ,UnitPrice DECIMAL(18, 2) NOT NULL
 ,TotalPrice DECIMAL(18, 2) NOT NULL
 ,Ncm VARCHAR(50) NULL
 ,CONSTRAINT PK_ItemCommercialInvoice PRIMARY KEY CLUSTERED (IdInvoice, IdProduto)
) ON [PRIMARY]
GO

ALTER TABLE ItemCommercialInvoice
ADD CONSTRAINT FK_ItemCommercialInvoice_CommercialInvoice FOREIGN KEY (IdInvoice) REFERENCES CommercialInvoice (IdInvoice)
GO

ALTER TABLE ItemCommercialInvoice
ADD CONSTRAINT FK_ItemCommercialInvoice_Produto FOREIGN KEY (IdProduto) REFERENCES Produto (IdProduto)
GO

CREATE TABLE PackingList (
  IdInvoice INT NOT NULL
 ,PackageNumber INT NOT NULL
 ,Sizes VARCHAR(100) NOT NULL
 ,Pieces INT NOT NULL
 ,SquareMeter DECIMAL(18, 2) NOT NULL
 ,GrossWeight DECIMAL(18, 2) NOT NULL
 ,CONSTRAINT PK_PackingList PRIMARY KEY CLUSTERED (IdInvoice, PackageNumber)
) ON [PRIMARY]
GO

ALTER TABLE PackingList
ADD CONSTRAINT FK_PackingList_CommercialInvoice FOREIGN KEY (IdInvoice) REFERENCES CommercialInvoice (IdInvoice)
GO


--MODULO PARA CONTROLE DE ARDOSIA
CREATE TABLE MaterialSerra (
  IdMaterial INT IDENTITY
 ,CodigoMaterial INT NOT NULL
 ,NomeMaterial VARCHAR(200) NOT NULL
 ,Comprimento DECIMAL(18, 4) NULL
 ,Largura DECIMAL(18, 4) NULL
 ,Espessura1 DECIMAL(18, 6) NULL
 ,Espessura2 DECIMAL(18, 6) NULL
 ,ValorMetroQuadrado DECIMAL(18, 2) NOT NULL
 ,CONSTRAINT [PK_MaterialSerra] PRIMARY KEY CLUSTERED (IdMaterial)
) ON [PRIMARY]
GO

CREATE TABLE Serra (
  IdSerra INT IDENTITY
 ,NomeSerra VARCHAR(50) NOT NULL
 ,StatusSerra INT NOT NULL
 ,CONSTRAINT [PK_Serra] PRIMARY KEY CLUSTERED (IdSerra)
) ON [PRIMARY]
GO
CREATE UNIQUE INDEX IX_NomeSerra
  ON Serra (NomeSerra)
  ON [PRIMARY]
GO


CREATE TABLE Motorista (
  IdMotorista INT IDENTITY
 ,NomeMotorista VARCHAR(8000) NULL
 ,CONSTRAINT [PK_Motorista] PRIMARY KEY CLUSTERED (IdMotorista)
) ON [PRIMARY]
GO

CREATE TABLE OrdemCarga (
  IdOrdemCarga INT IDENTITY
 ,IdCliFor INT NOT NULL
 ,IdUsuario INT NOT NULL
 ,IdMotorista INT NOT NULL
 ,DataCarregamento DATETIME NOT NULL
 ,TotalCarga DECIMAL(18, 2) NOT NULL
 ,ValorDesconto DECIMAL(18, 2) NOT NULL
 ,Observacao TEXT NULL
 ,NumeroItens INT NOT NULL
 ,CodigoInterno VARCHAR(45) NULL
 ,TotalLiquidoCarga DECIMAL(18, 2) NULL
 ,CONSTRAINT [PK_OrdemCarga] PRIMARY KEY CLUSTERED (IdOrdemCarga)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE OrdemCarga
ADD CONSTRAINT [FK_OrdemCarga_CliFor_IdCliFor] FOREIGN KEY (IdCliFor) REFERENCES CliFor (IdCliFor)
GO

ALTER TABLE OrdemCarga
ADD CONSTRAINT [FK_OrdemCarga_Motorista_IdMotorista] FOREIGN KEY (IdMotorista) REFERENCES Motorista (IdMotorista)
GO

ALTER TABLE OrdemCarga WITH NOCHECK
ADD CONSTRAINT [FK_OrdemCarga_Usuario_IdUsuario] FOREIGN KEY (IdUsuario) REFERENCES Usuario (IdUsuario)
GO

CREATE TABLE ItemOrdemCarga (
  IdOrdemCarga INT NOT NULL
 ,IdMaterial INT NOT NULL
 ,IdUsuario INT NOT NULL
 ,QuantidadePeca INT NOT NULL
 ,MetrosQuadrado DECIMAL(18, 2) NOT NULL
 ,MetrosCubico DECIMAL(18, 2) NOT NULL
 ,ValorUnitario DECIMAL(18, 2) NOT NULL
 ,TotalUnitario DECIMAL(18, 2) NOT NULL
 ,CONSTRAINT [PK_ItemOrdemCarga] PRIMARY KEY CLUSTERED (IdOrdemCarga, IdMaterial)
) ON [PRIMARY]
GO

ALTER TABLE ItemOrdemCarga WITH NOCHECK
ADD CONSTRAINT [FK_ItemOrdemCarga_MaterialSerra_IdMaterial] FOREIGN KEY (IdMaterial) REFERENCES MaterialSerra (IdMaterial)
GO

ALTER TABLE ItemOrdemCarga
ADD CONSTRAINT [FK_ItemOrdemCarga_OrdemCarga_IdOrdemCarga] FOREIGN KEY (IdOrdemCarga) REFERENCES OrdemCarga (IdOrdemCarga)
GO

ALTER TABLE ItemOrdemCarga
ADD CONSTRAINT [FK_ItemOrdemCarga_Usuario_IdUsuario] FOREIGN KEY (IdUsuario) REFERENCES Usuario (IdUsuario)
GO

CREATE TABLE ProducaoSerra (
  IdSerra INT NOT NULL
 ,IdMaterial INT NOT NULL
 ,DataProducao DATE NOT NULL
 ,IdUsuario INT NOT NULL
 ,QuantidadePeca INT NOT NULL
 ,MetrosQuadrado DECIMAL(18, 2) NOT NULL
 ,MetrosCubico DECIMAL(18, 2) NOT NULL
 ,ValorUnitario DECIMAL(18, 2) NOT NULL
 ,TotalUnitario DECIMAL(18, 2) NOT NULL
 ,CONSTRAINT [PK_ProducaoSerra] PRIMARY KEY CLUSTERED (IdSerra, IdMaterial, DataProducao)
) ON [PRIMARY]
GO

ALTER TABLE ProducaoSerra WITH NOCHECK
ADD CONSTRAINT [FK_ProducaoSerra_MaterialSerra_IdMaterial] FOREIGN KEY (IdMaterial) REFERENCES MaterialSerra (IdMaterial)
GO

ALTER TABLE ProducaoSerra WITH NOCHECK
ADD CONSTRAINT [FK_ProducaoSerra_Serra_IdSerra] FOREIGN KEY (IdSerra) REFERENCES Serra (IdSerra)
GO

ALTER TABLE ProducaoSerra WITH NOCHECK
ADD CONSTRAINT [FK_ProducaoSerra_Usuario_IdUsuario] FOREIGN KEY (IdUsuario) REFERENCES Usuario (IdUsuario)
GO

ALTER TABLE ItemCommercialInvoice
DROP COLUMN Ncm

ALTER TABLE ItemCommercialInvoice
ADD ArNumber VARCHAR(20) NULL

ALTER TABLE ItemCommercialInvoice
ADD PoNumber VARCHAR(20) NULL


--CRIAR UMA PACOTE 
ALTER TABLE ItemOrdemCarga
ADD QuantidadePecaRefugo INT NULL


ALTER TABLE ProducaoSerra
ADD QuantidadePecaRefugo INT NULL


UPDATE ItemOrdemCarga SET QuantidadePecaRefugo = 0
UPDATE ProducaoSerra SET QuantidadePecaRefugo = 0

ALTER TABLE ItemOrdemCarga
ALTER COLUMN QuantidadePecaRefugo INT NOT NULL


ALTER TABLE ProducaoSerra
ALTER COLUMN QuantidadePecaRefugo INT NOT NULL


ALTER TABLE  dbo.CommercialInvoice
ADD IdUsuario INT NOT NULL


CREATE TABLE Transporte (
  IdTransporte INT IDENTITY
 ,IdTransportadora INT NOT NULL 
 ,NomeMotorista VARCHAR(50) NOT NULL 
 ,PlacaVeiculo VARCHAR(10) NOT NULL
 ,ValorFrete DECIMAL(18, 2) NOT NULL
 ,CONSTRAINT PK_Transporte PRIMARY KEY CLUSTERED (IdTransporte)
) ON [PRIMARY]
GO        