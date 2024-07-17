using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface ITecnicoEquipoRepository
    {
        Task<IEnumerable<TecnicoEquipo>> GetAllAsync();
        Task<TecnicoEquipo> GetByIdAsync(int tecnicoId, int equipoId);
        Task AddAsync(TecnicoEquipo tecnicoEquipo);
        Task UpdateAsync(TecnicoEquipo tecnicoEquipo);
        Task DeleteAsync(int tecnicoId, int equipoId);
    }
}
