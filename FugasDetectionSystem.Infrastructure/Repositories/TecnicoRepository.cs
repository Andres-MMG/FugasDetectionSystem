using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        protected override Tecnico MapToEntity(SqlDataReader reader)
        {
            return new Tecnico
            {
                TecnicoID = reader.GetInt32(reader.GetOrdinal("TecnicoID")),
                Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("Nombre")),
                Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido")) ? string.Empty : reader.GetString(reader.GetOrdinal("Apellido")),
                Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? string.Empty : reader.GetString(reader.GetOrdinal("Especialidad")),
                CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? string.Empty : reader.GetString(reader.GetOrdinal("CorreoElectronico")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? string.Empty : reader.GetString(reader.GetOrdinal("Telefono"))
            };
        }

        public async Task<IEnumerable<Tecnico>> GetAllAsync()
        {
            return await base.GetAllAsync("ConsultarTecnicos");
        }

        public async Task<Tecnico> GetByIdAsync(int tecnicoId)
        {
            return await base.GetByIdAsync("ConsultarTecnicoPorID", tecnicoId, "@TecnicoID");
        }

        public async Task AddAsync(Tecnico tecnico)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Nombre", tecnico.Nombre ?? string.Empty },
                { "@Apellido", tecnico.Apellido ?? string.Empty },
                { "@Especialidad", tecnico.Especialidad ?? string.Empty },
                { "@CorreoElectronico", tecnico.CorreoElectronico ?? string.Empty },
                { "@Telefono", tecnico.Telefono ?? string.Empty }
            };

            await base.AddAsync("InsertarTecnico", parameters);
        }

        public async Task UpdateAsync(Tecnico tecnico)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TecnicoID", tecnico.TecnicoID },
                { "@Nombre", tecnico.Nombre },
                { "@Apellido", tecnico.Apellido },
                { "@Especialidad", tecnico.Especialidad },
                { "@CorreoElectronico", tecnico.CorreoElectronico },
                { "@Telefono", tecnico.Telefono }
            };

            await base.UpdateAsync("ActualizarTecnico", parameters);
        }

        public async Task DeleteAsync(int tecnicoId)
        {
            await base.DeleteAsync("EliminarTecnico", tecnicoId, "@TecnicoID");
        }
    }
}
