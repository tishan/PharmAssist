
/****** Object:  StoredProcedure [dbo].[global_DropStoredProcedure]    Script Date: 10/26/2013 21:34:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[global_DropStoredProcedure]
	@stordProcedureName varchar(max)
AS
-- ==========================================================================
-- $Author: tishan $
-- ==========================================================================
BEGIN
	
	SET NOCOUNT ON;
	
	IF  EXISTS (select * from dbo.sysobjects where id = object_id(N'' + @stordProcedureName + '') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DECLARE @SQL VARCHAR(8000)
		SELECT @SQL = 'USE ' + DB_NAME() + CHAR(10)
		SET @SQL = @SQL + 'DROP PROCEDURE ' + @stordProcedureName
		EXEC(@SQL)

	END
	


END

GO


