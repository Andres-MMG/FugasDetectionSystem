SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Eliminar{TableName}]
    {DeleteParameters}
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[{TableName}]
    {PrimaryKeyWhereClause};
    
    SELECT @@ROWCOUNT AS 'AffectedRows'; -- Devuelve el número de filas afectadas
END;
GO
