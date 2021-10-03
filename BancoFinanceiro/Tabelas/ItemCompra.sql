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
    CONSTRAINT [FK_ItemCompra_ToTable] FOREIGN KEY ([IdCompra]) REFERENCES [dbo].[Compra]([Id]) DEFAULT 1
)