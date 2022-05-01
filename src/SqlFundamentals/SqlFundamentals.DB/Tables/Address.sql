﻿CREATE TABLE [dbo].[Address]
(
	[AddressId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [Street] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(20) NULL, 
    [State] NVARCHAR(50) NULL, 
    [ZipCode] NVARCHAR(50) NULL
)