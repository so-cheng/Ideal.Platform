using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class PostQuery:QueryMust
    {
        public string DeptID { get; set; }

        public string PostName { get; set; }

        public string PostCode { get; set; }
    }
}
