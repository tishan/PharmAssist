EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssist_DeleteCustomer'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssist_DeleteCustomer
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

GRANT EXECUTE ON dbo.pharmAssist_DeleteCustomer TO PharmAssist 
GO