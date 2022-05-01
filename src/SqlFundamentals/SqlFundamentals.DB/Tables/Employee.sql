﻿CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [AddressId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    [CompanyName] NVARCHAR(20) NOT NULL, 
    [Position] NVARCHAR(30) NULL, 
    [EmployeeName] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY (PersonId) REFERENCES [Person]([PersonId]), 
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([AddressId]) 
)
