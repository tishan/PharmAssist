
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCustomer_UpdateCustomer'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCustomer_UpdateCustomer
	@customerName varchar(400),
	@customerBussinessName varchar(400),
	@town varchar(200),
	@address varchar(max),
	@telephone varchar(20),
	@mobile varchar(20),
	@email varchar(250),	
	@comments varchar(max),
	@id int,
	@modified smalldatetime output
AS
-- ==========================================================================
-- $Author: nilantha $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SET @modified = GETDATE()

	UPDATE Customer 
	SET customer_name = @customerName,
		customer_business_name = @customerBussinessName,
		town = @town,
		[address] = @address,
		telephone = @telephone,
		mobile = @mobile,
		email = @email,
		comments = @comments,
		modified = @modified
	WHERE customer_id = @id

END
GO

GRANT EXECUTE ON dbo.pharmAssistCustomer_UpdateCustomer TO PharmAssist
Go
