ALTER TABLE LancamentoFinanceiro
ALTER COLUMN DataLancamento DATE
GO

ALTER TABLE Extratobancario
ADD DataEstorno DATETIME NULL
GO