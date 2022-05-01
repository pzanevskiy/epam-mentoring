CREATE TRIGGER [onInsertEmloyeeInfo]
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
	INSERT INTO Company (Name, AddressId)
	SELECT CompanyName, AddressId FROM INSERTED
END