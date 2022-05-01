CREATE PROCEDURE [dbo].[INSERT_Employee]
	@companyName nvarchar(30),
	@street nvarchar(50),
	@employeeName nvarchar(100) = null,
	@firstName nvarchar(50) = null,
	@lastName nvarchar(50) = null,
	@position nvarchar(30) = null,
	@city nvarchar(20) = null,
	@state nvarchar(50) = null,
	@zipCode nvarchar(50) = null
AS
	IF NULLIF(TRIM(@employeeName), '') IS NOT NULL 
	OR NULLIF(TRIM(@firstName), '') IS NOT NULL	
	OR NULLIF(TRIM(@lastName), '') IS NOT NULL
		BEGIN
			SET NOCOUNT ON;
			declare @addressId int
			declare @personId int
	
			INSERT INTO Person (FirstName, LastName) VALUES (ISNULL(@firstName, ''), ISNULL(@lastName, ''))
			SET @personId = @@IDENTITY
	
			INSERT INTO Address (Street, City, State, ZipCode) VALUES(@street, @city, @state, @zipCode)
			SET @addressId = @@IDENTITY
	
			INSERT INTO Employee (AddressId, PersonId, CompanyName, Position, EmployeeName)
			values (@addressId, @personId, SUBSTRING(@companyName, 1, 20), @position, @employeeName)
		END;
RETURN 0
