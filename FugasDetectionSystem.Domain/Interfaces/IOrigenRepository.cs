using FugasDetectionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Domain.Interfaces
{

    public interface IOrigenRepository
    {
        Task<IEnumerable<Origen>> GetAllAsync();
        Task<Origen> GetByIdAsync(string origenId);
    }
}
