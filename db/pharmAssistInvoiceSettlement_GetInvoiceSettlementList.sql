EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoiceSettlement_GetInvoiceSettlementList'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoiceSettlement_GetInvoiceSettlementList

AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  invoice_settlement_id , invoice_no, collection_date
	FROM invoicesettlement

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoiceSettlement_GetInvoiceSettlementList TO PharmAssist 
GO