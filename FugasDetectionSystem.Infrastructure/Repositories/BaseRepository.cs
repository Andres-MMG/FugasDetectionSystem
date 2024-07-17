using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Interfaces;
using FugasDetectionSystem.Infrastructure.Exceptions;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected string ConnectionString { get; private set; }

        protected BaseRepository(IDatabaseSettings databaseSettings)
        {
            ConnectionString = databaseSettings.ConnectionString;
        }

        protected SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        protected static SqlCommand CreateCommand(SqlConnection connection, string storedProcedure, CommandType commandType = CommandType.StoredProcedure)
        {
            var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = commandType
            };
            return command;
        }

        protected static void HandleException(Exception exception)
        {
            if (exception is SqlException sqlEx)
            {
                LogError(sqlEx);
                throw new RepositoryException("Ocurrió un error específico de SQL.", sqlEx.Number, sqlEx);
            }
            else
            {
                LogError(exception);
                throw new RepositoryException("Ocurrió un error inesperado en el repositorio.", exception);
            }
        }

        private static void LogError(Exception exception)
        {
            Console.WriteLine(exception.ToString());
        }

        protected abstract T MapToEntity(SqlDataReader reader);

        public virtual async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            var entities = new List<T>();

            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    entities.Add(MapToEntity(reader));
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return entities;
        }

        public virtual async Task<T> GetByIdAsync(string storedProcedure, int id, string idParameterName)
        {
            T entity = null;

            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);
                command.Parameters.AddWithValue(idParameterName, id);

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    entity = MapToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return entity;
        }
        public virtual async Task<T> GetByIdAsync(string storedProcedure, string id, string idParameterName)
        {
            T entity = null;

            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);
                command.Parameters.AddWithValue(idParameterName, id);

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    entity = MapToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return entity;
        }


        public virtual async Task AddAsync(string storedProcedure, Dictionary<string, object> parameters)
        {
            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);

                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public virtual async Task UpdateAsync(string storedProcedure, Dictionary<string, object> parameters)
        {
            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);

                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public virtual async Task DeleteAsync(string storedProcedure, int id, string idParameterName)
        {
            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);
                command.Parameters.AddWithValue(idParameterName, id);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public virtual async Task DeleteAsync(string storedProcedure, string id, string idParameterName)
        {
            try
            {
                using var connection = GetOpenConnection();
                using var command = CreateCommand(connection, storedProcedure);
                command.Parameters.AddWithValue(idParameterName, id);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
