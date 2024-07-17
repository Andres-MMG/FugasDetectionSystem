using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.SQLGeneratorTools
{
    public class ColumnDetails
    {
        public bool IsPrimaryKey { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        
    }

}
