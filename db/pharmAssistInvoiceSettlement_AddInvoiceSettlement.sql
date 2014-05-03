
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoiceSettlement_AddInvoiceSettlement'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoiceSettlement_AddInvoiceSettlement
	@collectionDate date,
	@settlementType int,
	@settlementAmount money,
	@depositDate date,
	@interest float,
	@grnId int,
	@balanceAmount money,
	@totalOutstanding money,
	@invoiceId int,
	@customerId int,
	@companyId int,
	@enabled bit,
	@id int output,
	@created smalldatetime output
AS
-- ==========================================================================
-- $Author: nilantha $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SET @created = GETDATE()

	INSERT INTO InvoiceSettlement (collection_date, settlement_type, settlement_amount, deposit_date, interest,
									grn_id, balance_amount, total_outstanding, invoice_id,customer_id, company_id,
									 enabled ,modified, created)
	VALUES (@collectionDate, @settlementType, @settlementAmount, @depositDate, @interest, 
			@grnId, @balanceAmount,@totalOutstanding, @invoiceId, @customerId, @companyId, 
			@enabled, @created, @created)
		

	SET @id = SCOPE_IDENTITY()

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoiceSettlement_AddInvoiceSettlement TO PharmAssist
Go
