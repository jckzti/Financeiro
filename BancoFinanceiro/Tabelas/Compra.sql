CREATE TABLE [dbo].[Compra]
(
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
    [DataCadastro] [datetime2](7) NOT NULL,
	[DataAlteracao] [datetime2](7) NOT NULL,	
	[IdCategoria] [int]  NOT NULL,
    --CONSTRAINT [FK_Compra_ToTable] FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[Categoria]([Id])
)