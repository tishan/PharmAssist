EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoice_GetFilteredInvoiceList'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoice_GetFilteredInvoiceList
	@companyId int,
	@customerId int
AS
-- ==========================================================================
-- $Author: nilantha $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  invoice_id as id, invoice_date, invoice_number, amount, credit_period , customer_id, company_id, 
			created, modified, enabled
	FROM invoice
	WHERE customer_id = @customerId 
	AND company_id = @companyId

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoice_GetFilteredInvoiceList TO PharmAssist 
GO