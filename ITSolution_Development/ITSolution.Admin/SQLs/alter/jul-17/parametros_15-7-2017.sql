DELETE FROM Parametro
SET DATEFORMAT ymd
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'centro_custo_venda', N'1', CONVERT(BIT, 'True'), N'Centro de custo a ser utilizado ao realizar uma venda.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'conta_bancaria', N'1', CONVERT(BIT, 'True'), N'Conta utilizada para recebimentos.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'conta_caixa_geral', N'1', CONVERT(BIT, 'True'), N'Conta padrão utilizada pelo sistema para recebimento de pagamentos.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'dir_backup', N'D:\Bancos de dados\MAB', CONVERT(BIT, 'False'), N'Diretório onde são armazenados os backups do sistema.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'dir_digitalizacoes', N'D:\Pictures\Minhas digitalizações', CONVERT(BIT, 'True'), N'Local onde são armazendas as imagens digitalizadas.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'exigir_login_venda', NULL, CONVERT(BIT, 'False'), N'Exigir login sempre que iniciar uma venda ')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'report_engine', N'2', CONVERT(BIT, 'False'), N'Forma de geração do relatório. 
			1 = Gera e visualiza sem gravar no spool, 
			2 = Gera e visualiza gravando no spool, 
			3 = Gera somente em spool.')
GO
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'venda_quitada_avista', NULL, CONVERT(BIT, 'True'), N'Define se uma venda será quitada quando a forma de pagamento for á vista.')
GO
--INSERIR A PK DA CONTA AQUI
INSERT INTO Parametro (CodigoParametro, ValorParametro, StatusParametro, DescricaoParametro)
  VALUES (N'conta_fechamento_cambio', NULL, CONVERT(BIT, 'True'), N'Conta bancária para fechamento de câmbio.')
GO