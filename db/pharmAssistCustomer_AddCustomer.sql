
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCustomer_AddCustomer'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCustomer_AddCustomer
	@customerName varchar(400),
	@customerBussinessName varchar(400),
	@town varchar(200),
	@address varchar(max),
	@telephone varchar(20),
	@mobile varchar(20),
	@email varchar(250),	
	@comments varchar(max),
	@enabled bit,
	@id int output,
	@created smalldatetime output
AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SET @created = GETDATE()

	INSERT INTO customer (customer_name, customer_business_name, town, [address], telephone, mobile, email, comments, [enabled], modified, created)
	VALUES (@customerName, @customerBussinessName, @town, @address, @telephone , @mobile, @email, @comments, @enabled, @created, @created)
		

	SET @id = SCOPE_IDENTITY()

END
GO

GRANT EXECUTE ON dbo.pharmAssistCustomer_AddCustomer TO PharmAssist
Go
