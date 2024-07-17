using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IInteraccionRepository
    {
        Task<IEnumerable<Interaccion>> GetAllAsync();
        Task<Interaccion> GetByIdAsync(int interaccionId);
        Task AddAsync(Interaccion interaccion);
        Task UpdateAsync(Interaccion interaccion);
        Task DeleteAsync(int interaccionId);
    }
}
