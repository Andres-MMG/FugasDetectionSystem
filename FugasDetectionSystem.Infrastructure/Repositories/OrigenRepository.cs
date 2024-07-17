using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public class OrigenRepository : BaseRepository<Origen>, IOrigenRepository
    {
        public OrigenRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        protected override Origen MapToEntity(SqlDataReader reader)
        {
            return new Origen
            {
                OrigenId = reader.GetString(reader.GetOrdinal("OrigenId")),
                OrigenContacto = reader.IsDBNull(reader.GetOrdinal("Origen")) ? string.Empty : reader.GetString(reader.GetOrdinal("Origen"))
            };
        }

        public async Task<IEnumerable<Origen>> GetAllAsync()
        {
            return await base.GetAllAsync("ConsultarTodosOrigenes");
        }

        public async Task<Origen> GetByIdAsync(string origenId)
        {
            return await base.GetByIdAsync("ConsultarOrigenPorID", origenId, "@OrigenId");
        }
    }
}
