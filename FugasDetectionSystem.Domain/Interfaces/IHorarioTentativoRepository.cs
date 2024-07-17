using FugasDetectionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IHorarioTentativoRepository
    {
        Task<IEnumerable<HorarioTentativo>> GetAllAsync();
        Task<HorarioTentativo> GetByIdAsync(string horarioTentativoId);
    }
}
