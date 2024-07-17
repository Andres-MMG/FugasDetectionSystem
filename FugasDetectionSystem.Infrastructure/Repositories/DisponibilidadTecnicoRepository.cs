using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public class DisponibilidadTecnicoRepository : BaseRepository<DisponibilidadTecnico>, IDisponibilidadTecnicoRepository
    {
        public DisponibilidadTecnicoRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        protected override DisponibilidadTecnico MapToEntity(SqlDataReader reader)
        {
            return new DisponibilidadTecnico
            {
                DisponibilidadID = reader.GetInt32(reader.GetOrdinal("DisponibilidadID")),
                TecnicoID = reader.GetInt32(reader.GetOrdinal("TecnicoID")),
                DiaSemana = reader.GetByte(reader.GetOrdinal("DiaSemana")),
                HoraInicio = reader.GetTimeSpan(reader.GetOrdinal("HoraInicio")),
                HoraFin = reader.GetTimeSpan(reader.GetOrdinal("HoraFin"))
            };
        }

        public async Task<IEnumerable<DisponibilidadTecnico>> GetAllAsync()
        {
            return await base.GetAllAsync("ConsultarDisponibilidadesTecnico");
        }

        public async Task<DisponibilidadTecnico> GetByIdAsync(int disponibilidadTecnicoId)
        {
            return await base.GetByIdAsync("ConsultarDisponibilidadTecnicoPorID", disponibilidadTecnicoId, "@DisponibilidadID");
        }

        public async Task AddAsync(DisponibilidadTecnico disponibilidadTecnico)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@TecnicoID", disponibilidadTecnico.TecnicoID },
                { "@DiaSemana", disponibilidadTecnico.DiaSemana },
                { "@HoraInicio", disponibilidadTecnico.HoraInicio },
                { "@HoraFin", disponibilidadTecnico.HoraFin }
            };

            await base.AddAsync("InsertarDisponibilidadTecnico", parameters);
        }

        public async Task UpdateAsync(DisponibilidadTecnico disponibilidadTecnico)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@DisponibilidadID", disponibilidadTecnico.DisponibilidadID },
                { "@TecnicoID", disponibilidadTecnico.TecnicoID },
                { "@DiaSemana", disponibilidadTecnico.DiaSemana },
                { "@HoraInicio", disponibilidadTecnico.HoraInicio },
                { "@HoraFin", disponibilidadTecnico.HoraFin }
            };

            await base.UpdateAsync("ActualizarDisponibilidadTecnico", parameters);
        }

        public async Task DeleteAsync(int disponibilidadTecnicoId)
        {
            await base.DeleteAsync("EliminarDisponibilidadTecnico", disponibilidadTecnicoId, "@DisponibilidadID");
        }
    }
}
