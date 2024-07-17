using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class TableData
    {
        public string TableName { get; set; }
        public List<string> StoredProcedures { get; set; }
    }


}
