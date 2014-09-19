using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolita.Admin.Data
{
    public class Research
    {
        public string id { get; set; }
        public string name { get; set; }

        public IEnumerable<Action> actions { get; set; }
    }
}
