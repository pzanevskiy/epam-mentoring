﻿CREATE PROCEDURE [dbo].[sp_FetchOrders]
	@Month int = NULL,
	@Year int = NULL,
	@Status int = NULL,
	@ProductId int = NULL
AS
	SELECT Id, Status, CreatedDate, UpdateDate, ProductId FROM [dbo].[Order]
	WHERE (Status = @Status OR @Status IS NULL) AND
	(YEAR(CreatedDate) = @Year OR @Year IS NULL) AND
	(MONTH(CreatedDate) = @Month OR @Month IS NULL) AND
	(ProductId = @ProductId OR @ProductId IS NULL)
RETURN 0
