ALTER TABLE ContaBancaria
ADD Agencia VARCHAR(20) NULL 
GO

ALTER TABLE ContaBancaria
ADD NumeroConta VARCHAR(40) NULL 
GO

ALTER TABLE ContaBancaria
ADD TipoConta int NULL 
GO

ALTER TABLE ContaBancaria
ADD NomeBanco VARCHAR(100) NULL 
GO

UPDATE ContaBancaria SET Agencia = '' WHERE Agencia IS NULL
--restricao unique pra ela
UPDATE ContaBancaria SET NumeroConta = CONCAT('000',IdContaBancaria)
UPDATE ContaBancaria SET TipoConta = 0 WHERE TipoConta IS NULL
UPDATE ContaBancaria SET NomeBanco = DescricaoContaBancaria 

ALTER TABLE ContaBancaria
ALTER COLUMN Agencia VARCHAR(20) NOT NULL;

ALTER TABLE ContaBancaria
ALTER COLUMN NumeroConta VARCHAR(40) NOT NULL;

ALTER TABLE ContaBancaria
ALTER COLUMN TipoConta INT NOT NULL;

DROP INDEX IX_DescricaoContaBancaria ON dbBalcao_MAB.dbo.ContaBancaria
GO

CREATE INDEX IX_NumeroConta
ON dbBalcao_MAB.dbo.ContaBancaria (NumeroConta)
ON [PRIMARY]
GO

ALTER TABLE ContaBancaria
ADD CONSTRAINT UC_NumeroConta UNIQUE (NumeroConta);
