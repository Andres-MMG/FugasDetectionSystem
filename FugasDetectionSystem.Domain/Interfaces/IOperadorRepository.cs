using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IOperadorRepository
    {
        Task<IEnumerable<Operador>> GetAllAsync();
        Task<Operador> GetByIdAsync(int operadorId);
        Task AddAsync(Operador operador);
        Task UpdateAsync(Operador operador);
        Task DeleteAsync(int operadorId);
    }
}
