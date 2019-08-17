--Erro no aplicador
DROP TABLE Computador
GO
CREATE TABLE Computador (
  IdComputador INT IDENTITY
 ,IdManutencao INT NOT NULL
 ,NomePlacaMae VARCHAR(100) NOT NULL
 ,Processador VARCHAR(100) NOT NULL
 ,MemoriaRam VARCHAR(100) NOT NULL
 ,Hd VARCHAR(100) NOT NULL
 ,NomeComputador VARCHAR(100) NULL
 ,GrupoTrabalho VARCHAR(100) NULL
 ,NomeSistema VARCHAR(50) NULL
 ,Arquitetura VARCHAR(50) NULL
 ,CONSTRAINT [PK_Computador] PRIMARY KEY CLUSTERED (IdComputador)
)
GO

CREATE INDEX IX_IdManutencao
ON Computador (IdManutencao)
GO

ALTER TABLE Computador
ADD CONSTRAINT [FK_Computador_Manutencao_IdManutencao] FOREIGN KEY (IdManutencao) REFERENCES Manutencao (IdManutencao)
GO

DROP TABLE SistemaOperacional
GO

-- Add do campo Total da Invoice
ALTER TABLE CommercialInvoice
ADD TotalInvoice DECIMAL NOT NULL
GO

ALTER TABLE CommercialInvoice
ALTER COLUMN Moeda INT NOT NULL
GO

EXEC sp_rename 'CommercialInvoice.Moeda'
              ,'IdMoeda'
              ,'COLUMN'
GO

ALTER TABLE CommercialInvoice
ADD CONSTRAINT [FK_CommercialInvoice.Moeda_IdMoeda] FOREIGN KEY (IdMoeda) REFERENCES ITS_MOEDA (IdMoeda)
GO

EXEC sp_rename 'CommercialInvoice.ValorMoeda'
              ,'CurrencyValue'
              ,'COLUMN'
GO

 