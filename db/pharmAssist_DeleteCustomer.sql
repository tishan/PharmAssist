EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCustomer_DeleteCustomer'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCustomer_DeleteCustomer
	@id int
AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Customer
	WHERE customer_id = @id

END
GO

GRANT EXECUTE ON dbo.pharmAssistCustomer_DeleteCustomer TO PharmAssist 
GO