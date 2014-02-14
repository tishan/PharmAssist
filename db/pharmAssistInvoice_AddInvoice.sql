
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoice_AddInvoice'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoice_AddInvoice
	@invoiceNumber varchar(40),
	@invoiceDate date,
	@amount money,
	@creditPeriod int,
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

	INSERT INTO invoice (invoice_date, invoice_number, amount, credit_period, enabled ,modified, created)
	VALUES (@invoiceDate, @invoiceNumber, @amount, @creditPeriod, @enabled, @created, @created)
		

	SET @id = SCOPE_IDENTITY()

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoice_AddInvoice TO PharmAssist
Go
