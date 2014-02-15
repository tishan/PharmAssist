EXEC dbo.global_DropStoredProcedure 'dbo.pharmAssistCompany_GetCompanyList'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE dbo.pharmAssistCompany_GetCompanyList

AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;

	SELECT  company_id as id, company_code, company_name, 
			enabled, created, modified
	FROM company

END
GO

GRANT EXECUTE ON dbo.pharmAssistCompany_GetCompanyList TO PharmAssist 
GO