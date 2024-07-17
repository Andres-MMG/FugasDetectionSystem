using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface ICanalDeComunicacionRepository
    {
        Task<IEnumerable<CanalDeComunicacion>> GetAllAsync();
        Task<CanalDeComunicacion> GetByIdAsync(int canalId);
        Task AddAsync(CanalDeComunicacion canal);
        Task UpdateAsync(CanalDeComunicacion canal);
        Task DeleteAsync(int canalId);
    }
}
