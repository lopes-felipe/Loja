USE [Verity]
GO

CREATE TABLE [dbo].[Pedido](
	[ID]		 [bigint]		  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cliente]	 [nvarchar](255)  NOT NULL,
	[PrecoTotal] [decimal](18, 0) NOT NULL,
	[DataPedido] [datetime]		  NOT NULL)
GO

CREATE TABLE [dbo].[Produto](
	[ID]		[bigint]		 NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome]		[nvarchar](255)  NOT NULL,
	[Descricao] [nvarchar](max)  NOT NULL,
	[Preco]		[decimal](18, 0) NOT NULL)
GO

CREATE TABLE [dbo].[PedidoLinha](
	[ID]		 [bigint]		  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[PedidoID]   [bigint]		  NOT NULL REFERENCES [Pedido]([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	[ProdutoID]  [bigint]		  NOT NULL REFERENCES [Produto]([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	[Quantidade] [int]			  NOT NULL,
	[Preco]		 [decimal](18, 0) NOT NULL)
GO