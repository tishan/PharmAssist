
EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCompany_AddCompany'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCompany_AddCompany
	@companyCode varchar(50),
	@companyName varchar(MAX),
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

	INSERT INTO company (company_code, company_name, [enabled], modified, created)
	VALUES (@companyCode,@companyName, @enabled, @created, @created)
		
	SET @id = SCOPE_IDENTITY()

END
GO

GRANT EXECUTE ON dbo.pharmAssistCompany_AddCompany TO PharmAssist
Go
