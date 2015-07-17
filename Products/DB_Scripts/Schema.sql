CREATE DATABASE [TestTaskProducts]

GO

USE [TestTaskProducts]

GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[Count] [int] NOT NULL CONSTRAINT [DF_Product_Count]  DEFAULT ((0)),
	[Price] [numeric](9, 2) NOT NULL CONSTRAINT [DF_Product_Price]  DEFAULT ((0.00)),
	[IsPromo] [bit] NOT NULL CONSTRAINT [DF_Product_IsPromo]  DEFAULT ((0)),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
 ([Id] ASC)
)

GO

SET ANSI_PADDING OFF
GO