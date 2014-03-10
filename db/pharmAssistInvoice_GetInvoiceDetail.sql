EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoice_GetInvoiceDetail'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoice_GetInvoiceDetail
	@id int
AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  invoice_id as id, invoice_date, invoice_number, amount, credit_period , customer_id, company_id, 
			created, modified, enabled
	FROM Invoice
	WHERE invoice_id = @id

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoice_GetInvoiceDetail TO PharmAssist 
GO