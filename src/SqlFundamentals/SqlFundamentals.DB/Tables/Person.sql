﻿CREATE TABLE [dbo].[Person]
(
	[PersonId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL
)
