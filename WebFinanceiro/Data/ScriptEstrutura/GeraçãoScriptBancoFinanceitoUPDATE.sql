
/****** SOMENTE EXECUTAR NA VERSÃO 1.0.4 atualizada 16/04/2020 ******/

USE [FINANCEIRO]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 01/05/2019 23:56:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Compra'))
BEGIN
CREATE TABLE [dbo].[Compra]
(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nome] [nvarchar](max) NULL,
    [DataCadastro] [datetime2](7) NOT NULL,
	[DataAlteracao] [datetime2](7) NOT NULL,	
	[IdCategoria] [int]  NOT NULL,
    CONSTRAINT [FK_Compra_ToTable] FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria]([Id])
)

END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'ItemCompra'))
BEGIN
CREATE TABLE [dbo].[ItemCompra]
(
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Valor] [decimal](18, 2) NOT NULL DEFAULT 0,
    [DataCadastro] [datetime2](7) NOT NULL,
	[DataAlteracao] [datetime2](7) NOT NULL,	
	[DataCompra] [datetime2](7) NOT NULL,
	[IdCompra] [int]  NOT NULL,
	[Comprado] [bit] NOT NULL
    CONSTRAINT [FK_ItemCompra_Compra] FOREIGN KEY ([IdCompra]) REFERENCES [dbo].[Compra]([Id]) DEFAULT 1
)
END

GO



