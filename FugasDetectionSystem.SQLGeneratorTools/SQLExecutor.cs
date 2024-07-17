using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class SQLExecutor
    {
        private readonly string _connectionString;
        private readonly Dictionary<string, CRUDOperationResult> _operationResults;

        public SQLExecutor()
        {
            // Recuperar variables de entorno
            string dbServer = "dbokfugasdesa.database.windows.net,1433";
            string dbName = "db-okfugas-desa";
            string dbUser = "adminfugas";
            string dbPassword = "Marlen.4014##";

            // Construir la cadena de conexión
            _connectionString = $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPassword};";
            _operationResults = new Dictionary<string, CRUDOperationResult>();
        }

        public async Task<bool> ExecuteScriptAsync(string script)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var command = new SqlCommand(script, conn))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
                Console.WriteLine("Script ejecutado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el script: {ex.Message}");
                return false;
            }
        }

        public async Task<DataTable> GetTablesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await Task.Run(() => connection.GetSchema("Tables"));
            }
        }

        public async Task<DataTable> GetStoredProceduresAsync(string tableName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM sys.procedures WHERE name LIKE @TableName", connection);
                command.Parameters.AddWithValue("@TableName", "%" + tableName + "%");

                using (var adapter = new SqlDataAdapter(command))
                {
                    var procedures = new DataTable();
                    await Task.Run(() => adapter.Fill(procedures));
                    return procedures;
                }
            }
        }

        public async Task<List<ColumnDetails>> GetTableColumnsAsync(string tableName)
        {
            var columnDetailsList = new List<ColumnDetails>();
            var primaryKeys = await GetPrimaryKeyColumnsAsync(tableName);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT 
                        COLUMN_NAME, 
                        DATA_TYPE, 
                        IS_NULLABLE 
                    FROM INFORMATION_SCHEMA.COLUMNS 
                    WHERE TABLE_NAME = @TableName
                    ORDER BY ORDINAL_POSITION";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var details = new ColumnDetails
                            {
                                ColumnName = reader.GetString(reader.GetOrdinal("COLUMN_NAME")),
                                DataType = reader.GetString(reader.GetOrdinal("DATA_TYPE")),
                                IsNullable = reader.GetString(reader.GetOrdinal("IS_NULLABLE")) == "YES",
                                IsPrimaryKey = primaryKeys.Contains(reader.GetString(reader.GetOrdinal("COLUMN_NAME")))
                            };
                            columnDetailsList.Add(details);
                        }
                    }
                }
            }
            return columnDetailsList;
        }

        public async Task<List<string>> GetPrimaryKeyColumnsAsync(string tableName)
        {
            var primaryKeyColumns = new List<string>();
            var query = @"
                SELECT 
                    KU.column_name as PRIMARYKEYCOLUMN
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU
                  ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND
                     TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
                WHERE KU.table_name = @TableName
                ORDER BY KU.ORDINAL_POSITION;";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            primaryKeyColumns.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return primaryKeyColumns;
        }

        public async Task<string> GenerateInsertProcedureAsync(string tableName)
        {
            var columns = await GetTableColumnsAsync(tableName);
            var primaryKeys = await GetPrimaryKeyColumnsAsync(tableName);

            var insertParameters = new StringBuilder();
            var columnNames = new StringBuilder();
            var columnValues = new StringBuilder();

            foreach (var column in columns.Where(c => !primaryKeys.Contains(c.ColumnName)))
            {
                insertParameters.AppendLine($"    @{column.ColumnName} {column.DataType},");
                columnNames.AppendLine($"    {column.ColumnName},");
                columnValues.AppendLine($"    @{column.ColumnName},");
            }

            insertParameters.Length -= 3; // Remove trailing comma and newline
            columnNames.Length -= 3;
            columnValues.Length -= 3;

            var template = await File.ReadAllTextAsync("Plantillas\\PathToInsertTemplate.sql");
            return template
                .Replace("{TableName}", tableName)
                .Replace("{InsertParameters}", insertParameters.ToString())
                .Replace("{ColumnNames}", columnNames.ToString())
                .Replace("{ColumnValues}", columnValues.ToString());
        }

        public async Task<string> GenerateUpdateProcedureAsync(string tableName)
        {
            var columns = await GetTableColumnsAsync(tableName);
            var primaryKeys = await GetPrimaryKeyColumnsAsync(tableName);

            var updateParameters = new StringBuilder();
            var updateSet = new StringBuilder();

            foreach (var column in columns)
            {
                updateParameters.AppendLine($"    @{column.ColumnName} {column.DataType},");
                if (!primaryKeys.Contains(column.ColumnName))
                {
                    updateSet.AppendLine($"    {column.ColumnName} = @{column.ColumnName},");
                }
            }

            updateParameters.Length -= 3; // Remove trailing comma and newline
            updateSet.Length -= 3;

            var primaryKeyWhereClause = $"WHERE {primaryKeys.First()} = @{primaryKeys.First()}";

            var template = await File.ReadAllTextAsync("Plantillas\\PathToUpdateTemplate.sql");
            return template
                .Replace("{TableName}", tableName)
                .Replace("{UpdateParameters}", updateParameters.ToString())
                .Replace("{UpdateSet}", updateSet.ToString())
                .Replace("{PrimaryKeyWhereClause}", primaryKeyWhereClause);
        }

        public async Task<string> GenerateDeleteProcedureAsync(string tableName)
        {
            var primaryKeys = await GetPrimaryKeyColumnsAsync(tableName);

            var deleteParameters = new StringBuilder();
            var primaryKeyWhereClause = new StringBuilder("WHERE ");

            foreach (var pkColumn in primaryKeys)
            {
                deleteParameters.AppendLine($"    @{pkColumn} INT,");
                primaryKeyWhereClause.Append($"{pkColumn} = @{pkColumn} AND ");
            }

            deleteParameters.Length -= 1; // Remove trailing comma and newline
            primaryKeyWhereClause.Length -= 5; // Remove trailing "AND "

            var template = await File.ReadAllTextAsync("Plantillas\\PathToDeleteTemplate.sql");
            return template
                .Replace("{TableName}", tableName)
                .Replace("{DeleteParameters}", deleteParameters.ToString())
                .Replace("{PrimaryKeyWhereClause}", primaryKeyWhereClause.ToString());
        }

        public async Task<string> GenerateSelectAllProcedureAsync(string tableName)
        {
            var columns = await GetTableColumnsAsync(tableName);
            var columnNames = new StringBuilder();

            foreach (var column in columns)
            {
                columnNames.Append($"[{column.ColumnName}], ");
            }

            columnNames.Length -= 2; // Remove trailing comma and space

            var template = await File.ReadAllTextAsync("Plantillas\\PathToSelectAllTemplate.sql");
            return template
                .Replace("{TableName}", tableName)
                .Replace("{ColumnNames}", columnNames.ToString());
        }

        public async Task<string> GenerateSelectByIdProcedureAsync(string tableName)
        {
            var columns = await GetTableColumnsAsync(tableName);
            var primaryKeys = await GetPrimaryKeyColumnsAsync(tableName);

            if (primaryKeys.Count != 1)
            {
                throw new Exception("La tabla debe tener exactamente una clave primaria para generar un Select By ID.");
            }

            var columnNames = new StringBuilder();
            foreach (var column in columns)
            {
                columnNames.Append($"[{column.ColumnName}], ");
            }

            columnNames.Length -= 2; // Remove trailing comma and space

            string primaryKey = primaryKeys[0];
            var primaryKeyParameter = columns.FirstOrDefault(c => c.ColumnName == primaryKey);

            if (primaryKeyParameter == null)
            {
                throw new Exception("No se encontró la clave primaria en la lista de columnas.");
            }

            var template = await File.ReadAllTextAsync("Plantillas\\PathToSelectByIdTemplate.sql");
            return template
                .Replace("{TableName}", tableName)
                .Replace("{ColumnNames}", columnNames.ToString())
                .Replace("{PrimaryKey}", primaryKey)
                .Replace("{PrimaryKeyParameter}", $"@{primaryKey} {primaryKeyParameter.DataType}");
        }

        public async Task<CRUDOperationResult> CreateProceduresForTableAsync(string tableName)
        {
            if (_operationResults.ContainsKey(tableName))
            {
                return _operationResults[tableName];
            }

            var operationResult = new CRUDOperationResult
            {
                OperationId = Guid.NewGuid(),
                TableName = tableName,
                QuerysString = new Dictionary<string, string>(),
                Messages = new Dictionary<string, string>()
            };

            try
            {
                operationResult.QuerysString["Insert"] = await GenerateInsertProcedureAsync(tableName);
                operationResult.Messages["Insert"] = "Procedimiento INSERT generado con éxito.";

                operationResult.QuerysString["Update"] = await GenerateUpdateProcedureAsync(tableName);
                operationResult.Messages["Update"] = "Procedimiento UPDATE generado con éxito.";

                operationResult.QuerysString["Delete"] = await GenerateDeleteProcedureAsync(tableName);
                operationResult.Messages["Delete"] = "Procedimiento DELETE generado con éxito.";

                operationResult.QuerysString["SelectAll"] = await GenerateSelectAllProcedureAsync(tableName);
                operationResult.Messages["SelectAll"] = "Procedimiento SELECT ALL generado con éxito.";

                operationResult.QuerysString["SelectById"] = await GenerateSelectByIdProcedureAsync(tableName);
                operationResult.Messages["SelectById"] = "Procedimiento SELECT BY ID generado con éxito.";

                _operationResults[tableName] = operationResult;
            }
            catch (Exception ex)
            {
                operationResult.Messages["Error"] = $"Error al generar procedimientos: {ex.Message}";
            }

            return operationResult;
        }

        public CRUDOperationResult GetOperationResult(string tableName)
        {
            return _operationResults.TryGetValue(tableName, out var result) ? result : null;
        }

        public async Task<CustomQueryResult> ExecuteCustomQueryAsync(CustomQuery customQuery)
        {
            var result = new CustomQueryResult { QueryName = customQuery.QueryName };

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand(customQuery.SqlText, connection))
                    {
                        foreach (var param in customQuery.Parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                        await command.ExecuteNonQueryAsync();
                    }
                }

                result.IsSuccessful = true;
                result.Message = "La consulta personalizada se ejecutó con éxito.";
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Message = $"Error al ejecutar la consulta personalizada: {ex.Message}";
            }

            return result;
        }

        public void ExecuteScriptWithGO(string script)
        {
            var serverConnection = new ServerConnection { ConnectionString = _connectionString };
            var server = new Server(serverConnection);

            try
            {
                server.ConnectionContext.ExecuteNonQuery(script);
                Console.WriteLine("Script ejecutado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar el script: {ex.Message}");
            }
            finally
            {
                serverConnection.Disconnect();
            }
        }
    }
}

