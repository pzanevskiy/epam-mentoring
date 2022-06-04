CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Status] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [UpdateDate] DATETIME2 NOT NULL, 
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
