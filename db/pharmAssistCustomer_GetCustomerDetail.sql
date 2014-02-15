EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCustomer_GetCustomerDetail'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCustomer_GetCustomerDetail
	@id int
AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  customer_id as id, customer_name, customer_business_name, town, address, telephone, mobile, 
			email, comments, enabled, created, modified
	FROM customer
	WHERE customer_id = @id

END
GO

GRANT EXECUTE ON dbo.pharmAssistCustomer_GetCustomerDetail TO PharmAssist 
GO