using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Platform.Model
{
    public class WebMenu
    {
        public WebMenu()
        {
            children = new List<WebMenu>();
        }
        public string id { get; set; }

        public string parentid { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public List<WebMenu> children { get; set; }
    }
}
