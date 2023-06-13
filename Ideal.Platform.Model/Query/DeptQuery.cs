using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class DeptQuery : QueryMust
    {
        public string DeptCode { get; set; }

        public string DeptName { get; set; }

        public string CompanyID { get; set; }
    }
}
