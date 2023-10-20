using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class SystemQuery : QueryMust
    {
        public string SystemName { get; set; }

        public string SystemCode { get; set; }

        public string CompanyID { get; set; }

        public string CompanyName { get; set; }
    }
}
