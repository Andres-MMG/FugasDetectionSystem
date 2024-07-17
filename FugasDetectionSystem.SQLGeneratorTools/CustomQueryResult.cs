using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class CustomQueryResult
    {
        public string QueryName { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
