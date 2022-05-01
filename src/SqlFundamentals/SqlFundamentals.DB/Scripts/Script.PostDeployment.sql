declare @personId int
declare @addressId int

insert into Person (FirstName, LastName) values ('Pavel', 'Zaneuski')
set @personId = @@IDENTITY

insert into Address (Street, City) values ('YK, 87', 'Hrodna')
set @addressId = @@IDENTITY

insert into Employee (AddressId, PersonId, CompanyName, Position, EmployeeName) values 
(@addressId, @personId, 'EPAM Systems inc', 'Software Engineer', '')

insert into Company (Name, AddressId) values ('EPAM Systems inc', 1)