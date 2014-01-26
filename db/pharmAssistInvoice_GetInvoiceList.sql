EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoice_GetInvoiceList'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoice_GetInvoiceList

AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  invoice_number , invoice_date, amount
	FROM invoice

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoice_GetInvoiceList TO PharmAssist 
GO