-- Plantilla para INSERT
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Marlen Leyva
-- Fecha de Creación: 2024-03-11
-- Descripción: Este procedimiento almacenado inserta un nuevo técnico en la tabla Tecnicos.
--              Devuelve 1 si la inserción fue exitosa y 0 si no lo fue.
-- =============================================
CREATE PROCEDURE [dbo].[Insertar{TableName}]
    {InsertParameters}
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[{TableName}] ({ColumnNames})
    VALUES ({ColumnValues});
    
    SELECT SCOPE_IDENTITY() AS NewRecordID; -- Devuelve el ID del nuevo registro insertado
END;
GO

-- Similarmente, crea plantillas para UPDATE, DELETE y SELECT.
