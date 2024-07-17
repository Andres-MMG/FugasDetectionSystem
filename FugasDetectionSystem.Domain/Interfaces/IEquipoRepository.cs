using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<Equipo>> GetAllAsync();
        Task<Equipo> GetByIdAsync(int equipoId);
        Task AddAsync(Equipo equipo);
        Task UpdateAsync(Equipo equipo);
        Task DeleteAsync(int equipoId);
    }
}
