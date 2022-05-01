insert into Person (PersonId, FirstName, LastName) values (0, 'Pavel', 'Zaneuski')

insert into Address (AddressId, Street, City) values (1, 'YK, 87', 'Hrodna'), (2, 'YK, 1', 'Hrodna')

insert into Employee (EmployeeId, AddressId, PersonId, CompanyName, Position, EmployeeName) values 
(3, 1, 0, 'EPAM Systems inc', 'Software Engineer', '')

insert into Company (CompanyId, Name, AddressId) values (4, 'EPAM Systems inc', 1)