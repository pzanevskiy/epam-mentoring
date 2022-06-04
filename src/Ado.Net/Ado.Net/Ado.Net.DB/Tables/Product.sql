CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [Weight] INT NOT NULL, 
    [Height] INT NOT NULL, 
    [Width] INT NOT NULL, 
    [Length] INT NOT NULL
)
