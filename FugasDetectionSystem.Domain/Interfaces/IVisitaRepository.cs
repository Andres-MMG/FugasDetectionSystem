using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IVisitaRepository
    {
        Task<IEnumerable<Visita>> GetAllAsync();
        Task<Visita> GetByIdAsync(int visitaId);
        Task AddAsync(Visita visita);
        Task UpdateAsync(Visita visita);
        Task DeleteAsync(int visitaId);
    }
}
