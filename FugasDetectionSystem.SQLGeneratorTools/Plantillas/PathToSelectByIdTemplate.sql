SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Consultar{TableName}PorID]
    -- Define el parámetro para la consulta basada en la clave primaria
    {PrimaryKeyParameter}
AS
BEGIN
    SET NOCOUNT ON;

    -- Realiza la selección de todas las columnas basada en la clave primaria
    SELECT {ColumnNames} FROM [dbo].[{TableName}] WHERE [{PrimaryKey}] = @{PrimaryKey};
END;
GO
