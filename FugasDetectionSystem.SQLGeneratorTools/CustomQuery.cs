using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class CustomQuery
    {
        public string QueryName { get; set; }
        public string SqlText { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        public CustomQuery()
        {
            Parameters = new Dictionary<string, object>();
        }
    }
}
