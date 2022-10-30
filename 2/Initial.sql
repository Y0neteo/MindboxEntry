
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products' AND TABLE_SCHEMA = 'dbo' )
BEGIN
	CREATE TABLE [dbo].[Products](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) UNIQUE NOT NULL,
		CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)) ON [PRIMARY]
END

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories' AND TABLE_SCHEMA = 'dbo' )
BEGIN
	CREATE TABLE [dbo].[Categories](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) UNIQUE NOT NULL,
		CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)) ON [PRIMARY]
END

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductsCategories' AND TABLE_SCHEMA = 'dbo' )
BEGIN
	CREATE TABLE [dbo].[ProductsCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	CONSTRAINT [FK_ProductsCategories_Products_Id] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
	CONSTRAINT [FK_ProductsCategories_Categories_Id] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
	CONSTRAINT [PK_ProductsCategories] PRIMARY KEY CLUSTERED ([ProductId], [CategoryId]) ON [PRIMARY]
	);
END
GO