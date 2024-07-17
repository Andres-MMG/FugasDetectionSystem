using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class CRUDOperationResult
    {
        public Guid OperationId { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, string> Messages { get; set; }
        public Dictionary<string, string> QuerysString { get; set; }

        public CRUDOperationResult()
        {
            Messages = new Dictionary<string, string>();
        }
    }
}
