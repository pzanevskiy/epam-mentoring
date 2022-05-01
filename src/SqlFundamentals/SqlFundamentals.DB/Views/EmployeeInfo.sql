CREATE VIEW [dbo].[EmployeeInfo]
	AS SELECT TOP(100)
	e.EmployeeId,
	ISNULL(e.EmployeeName, CONCAT(p.FirstName, ' ', p.LastName)) EmployeeFullName,
	CONCAT(a.ZipCode, '_', a.State, ' ', a.City, '-', a.Street) EmployeeFullAddress,
	CONCAT(e.CompanyName, '(', e.Position ,')') EmployeeCompanyInfo
	FROM Employee e
	JOIN Person p on p.PersonId = e.PersonId
	JOIN Address a on a.AddressId = e.AddressId
	ORDER BY e.CompanyName, a.City ASC