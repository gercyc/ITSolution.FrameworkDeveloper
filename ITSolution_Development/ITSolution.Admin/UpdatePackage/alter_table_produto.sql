ALTER TABLE Produto
DROP COLUMN IdentificacaoProduto

ALTER TABLE Produto
ADD IdentificacaoProduto INT NULL

UPDATE Produto Set IdentificacaoProduto = -1;

ALTER TABLE Produto
ALTER COLUMN IdentificacaoProduto INT NOT NULL