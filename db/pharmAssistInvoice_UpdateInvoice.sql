
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistInvoice_UpdateInvoice'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistInvoice_UpdateInvoice
	@invoiceNumber varchar(50),
	@invoiceDate date,
	@amount money,
	@creditPeriod int,
	@id int,
	@enabled bit,
	@modified smalldatetime output
AS 
-- ==========================================================================
-- $Author: nilantha $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SET @modified = GETDATE()

	UPDATE Invoice 
	SET invoice_number = @invoiceNumber,
		invoice_date = @invoiceDate,
		amount = @amount,
		credit_period = @creditPeriod,
		modified = @modified
	WHERE invoice_id = @id

END
GO

GRANT EXECUTE ON dbo.pharmAssistInvoice_UpdateInvoice TO PharmAssist
Go
