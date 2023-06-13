using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model.Query
{
    public class UserQuery:QueryMust
    {

        public string UserName { get; set; }

        public string UserCode { get; set; }
        public string DeptID { get; set; }

        public string UserIDCard { get; set; }

        public string Sex { get; set; }
        public string CheckType { get; set; }
        public string UserStatus { get; set; }
    }
}
