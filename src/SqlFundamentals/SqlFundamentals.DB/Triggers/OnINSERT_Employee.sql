CREATE TRIGGER [OnINSERT_EmployeeTrigger]
	ON [dbo].[Employee]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON;
		INSERT INTO Company (Name, AddressId)
		SELECT CompanyName, AddressId FROM INSERTED
	END
