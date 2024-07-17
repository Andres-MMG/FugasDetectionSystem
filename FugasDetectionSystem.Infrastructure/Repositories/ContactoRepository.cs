using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FugasDetectionSystem.Domain.Entities;
using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Repositories
{
    public class ContactoRepository : BaseRepository<Contacto>, IContactoRepository
    {
        public ContactoRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        protected override Contacto MapToEntity(SqlDataReader reader)
        {
            return new Contacto
            {
                ContactoId = reader.GetInt32(reader.GetOrdinal("ContactoId")),
                OrigenId = reader.GetString(reader.GetOrdinal("OrigenId")),
                Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("Nombre")),
                Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido")) ? string.Empty : reader.GetString(reader.GetOrdinal("Apellido")),
                CorreoElectronico = reader.IsDBNull(reader.GetOrdinal("CorreoElectronico")) ? string.Empty : reader.GetString(reader.GetOrdinal("CorreoElectronico")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? string.Empty : reader.GetString(reader.GetOrdinal("Telefono")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? string.Empty : reader.GetString(reader.GetOrdinal("Direccion")),
                CoordenadasMaps = reader.IsDBNull(reader.GetOrdinal("CoordenadasMaps")) ? string.Empty : reader.GetString(reader.GetOrdinal("CoordenadasMaps")),
                FechaTentativaVisita = reader.GetDateTime(reader.GetOrdinal("FechaTentativaVisita")),
                HorarioTentativoId = reader.GetString(reader.GetOrdinal("HorarioTentativoId"))
            };
        }

        public async Task<IEnumerable<Contacto>> GetAllAsync()
        {
            return await base.GetAllAsync("[dbo].[ConsultarTodosContactos]");
        }

        public async Task<Contacto> GetByIdAsync(int contactoId)
        {
            return await base.GetByIdAsync("ConsultarContactosPorID", contactoId, "@ContactoId");
        }

        public async Task AddAsync(Contacto contacto)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@OrigenId", contacto.OrigenId },
                { "@Nombre", contacto.Nombre },
                { "@Apellido", contacto.Apellido },
                { "@CorreoElectronico", contacto.CorreoElectronico },
                { "@Telefono", contacto.Telefono },
                { "@Direccion", contacto.Direccion },
                { "@CoordenadasMaps", contacto.CoordenadasMaps },
                { "@FechaTentativaVisita", contacto.FechaTentativaVisita },
                { "@HorarioTentativoId", contacto.HorarioTentativoId }
            };

            await base.AddAsync("InsertarContactos", parameters);
        }

        public async Task UpdateAsync(Contacto contacto)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ContactoId", contacto.ContactoId },
                { "@OrigenId", contacto.OrigenId },
                { "@Nombre", contacto.Nombre },
                { "@Apellido", contacto.Apellido },
                { "@CorreoElectronico", contacto.CorreoElectronico },
                { "@Telefono", contacto.Telefono },
                { "@Direccion", contacto.Direccion },
                { "@CoordenadasMaps", contacto.CoordenadasMaps },
                { "@FechaTentativaVisita", contacto.FechaTentativaVisita },
                { "@HorarioTentativoId", contacto.HorarioTentativoId }
            };

            await base.UpdateAsync("ActualizarContacto", parameters);
        }

        public async Task DeleteAsync(int contactoId)
        {
            await base.DeleteAsync("EliminarContacto", contactoId, "@ContactoId");
        }
    }
}
