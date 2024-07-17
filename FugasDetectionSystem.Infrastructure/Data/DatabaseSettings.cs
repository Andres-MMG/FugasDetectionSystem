using FugasDetectionSystem.Domain.Interfaces;

namespace FugasDetectionSystem.Infrastructure.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
