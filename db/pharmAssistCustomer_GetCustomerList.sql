EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCustomer_GetCustomerList'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCustomer_GetCustomerList

AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  customer_id as id, customer_name, customer_business_name, town, address, telephone, mobile, 
			email, comments, enabled, created, modified
	FROM customer

END
GO

GRANT EXECUTE ON dbo.pharmAssistCustomer_GetCustomerList TO PharmAssist 
GO