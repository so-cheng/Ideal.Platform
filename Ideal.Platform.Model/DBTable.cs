using Ideal.Ideal.Common.Enums;
using Ideal.Ideal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class DBTable
    {
        public DBTable()
        {
            Table = new List<TableFields>();
        }
        public string DBID { get; set; }
        public string TableName { get; set; }
        public string TableDesc { get; set; }

        public List<TableFields> Table { get; set; }
    }
}
