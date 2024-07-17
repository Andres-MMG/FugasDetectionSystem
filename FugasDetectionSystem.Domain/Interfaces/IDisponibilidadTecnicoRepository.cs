using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IDisponibilidadTecnicoRepository
    {
        Task<IEnumerable<DisponibilidadTecnico>> GetAllAsync();
        Task<DisponibilidadTecnico> GetByIdAsync(int disponibilidadTecnicoId);
        Task AddAsync(DisponibilidadTecnico disponibilidadTecnico);
        Task UpdateAsync(DisponibilidadTecnico disponibilidadTecnico);
        Task DeleteAsync(int disponibilidadTecnicoId);
    }
}
