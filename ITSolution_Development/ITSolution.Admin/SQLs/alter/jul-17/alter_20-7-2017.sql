 ALTER TABLE CommercialInvoice
ADD Moeda INT NULL
GO

ALTER TABLE CommercialInvoice
ADD ValorMoeda INT NULL
GO

UPDATE CommercialInvoice SET Moeda = 0, ValorMoeda = 0
GO
 
ALTER TABLE CommercialInvoice
ALTER COLUMN Moeda INT NOT NULL
GO

ALTER TABLE CommercialInvoice
ALTER COLUMN ValorMoeda INT NOT NULL
GO

--Cria uma coluna
ALTER TABLE CommercialInvoice
ADD IdTransporte INT NOT NULL
GO
--Agora faça dela uma FK
ALTER TABLE CommercialInvoice
ADD CONSTRAINT [FK_CommercialInvoice.Transporte_IdTransporte] FOREIGN KEY ([IdTransporte]) REFERENCES [Transporte] ([IdTransporte])
GO