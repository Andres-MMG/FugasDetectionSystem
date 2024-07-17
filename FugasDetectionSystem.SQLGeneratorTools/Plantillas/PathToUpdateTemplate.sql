SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Actualizar{TableName}]
    {UpdateParameters}
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[{TableName}]
    SET {UpdateSet}
    {PrimaryKeyWhereClause};
    
    SELECT @@ROWCOUNT AS 'AffectedRows';
END;
GO
