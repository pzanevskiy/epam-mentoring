CREATE TABLE [dbo].[Company]
(
	[CompanyId] INT NOT NULL PRIMARY KEY DEFAULT @@IDENTITY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([AddressId])
)

GO
