using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class DeptTree
    {
        public DeptTree()
        {
            Child = new List<DeptTree>();
        }
        public string ID { get; set; }

        public string PID { get; set; }

        public string Name { get; set; }

        public string MyProperty { get; set; }

        public List<DeptTree> Child { get; set; }
    }
}
