﻿CREATE PROCEDURE [dbo].[sp_DeleteOrders]
	@Month int = NULL,
	@Year int = NULL,
	@Status int = NULL,
	@ProductId int = NULL
AS
	DELETE FROM [dbo].[Order]
	WHERE (Status = @Status OR @Status IS NULL) AND
	(YEAR(CreatedDate) = @Year OR @Year IS NULL) AND
	(MONTH(CreatedDate) = @Month OR @Month IS NULL) AND
	(ProductId = @ProductId OR @ProductId IS NULL)
RETURN 0
