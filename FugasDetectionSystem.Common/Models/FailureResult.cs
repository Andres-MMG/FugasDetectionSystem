using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Common.Models
{
    public class FailureResult : Result
    {
        public FailureResult(string message) : base(false, message) { }
    }
}
