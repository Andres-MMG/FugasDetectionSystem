using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface ITecnicoRepository
    {
        Task<IEnumerable<Tecnico>> GetAllAsync();
        Task<Tecnico> GetByIdAsync(int tecnicoId);
        Task AddAsync(Tecnico tecnico);
        Task UpdateAsync(Tecnico tecnico);
        Task DeleteAsync(int tecnicoId);
    }
}
