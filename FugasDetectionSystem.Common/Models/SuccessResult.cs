using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Common.Models
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message = null) : base(true, message) { }
    }
}
