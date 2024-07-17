using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public class HorarioTentativoRepository : BaseRepository<HorarioTentativo>, IHorarioTentativoRepository
    {
        public HorarioTentativoRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        protected override HorarioTentativo MapToEntity(SqlDataReader reader)
        {
            return new HorarioTentativo
            {
                HorarioTentativoId = reader.GetString(reader.GetOrdinal("HorarioTentativoId")),
                Preferencia = reader.IsDBNull(reader.GetOrdinal("Preferencia")) ? string.Empty : reader.GetString(reader.GetOrdinal("Preferencia"))
            };
        }

        public async Task<IEnumerable<HorarioTentativo>> GetAllAsync()
        {
            return await base.GetAllAsync("ConsultarTodosHorariosTentativos");
        }

        public async Task<HorarioTentativo> GetByIdAsync(string horarioTentativoId)
        {
            return await base.GetByIdAsync("ConsultarHorarioTentativoPorID", horarioTentativoId, "@HorarioTentativoId");
        }
    }
}
