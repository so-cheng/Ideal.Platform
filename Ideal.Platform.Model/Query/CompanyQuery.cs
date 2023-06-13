using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class CompanyQuery : QueryMust
    {
        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }
    }
}
    