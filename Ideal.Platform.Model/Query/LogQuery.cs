using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class LogQuery : QueryMust
    {

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Type { get; set; }
    }
}
