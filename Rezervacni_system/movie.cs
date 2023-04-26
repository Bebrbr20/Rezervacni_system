using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezervacni_system
{
    
    internal class movie
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public cinema cinema { get; set; }

            public movie()
        {

        }
    }
}
