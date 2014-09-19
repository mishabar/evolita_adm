using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolita.Admin.Tokens
{
    public class ActionToken
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

    public static class ActionExtensions
    {
        public static ActionToken AsToken(this Evolita.Admin.Data.Action action)
        {
            return new ActionToken 
            {
                id = action.id,
                type = action.type,
                name = action.name
            };
        }

        public static Data.Action AsAction(this ActionToken action)
        {
            return new Data.Action
            {
                id = action.id,
                type = action.type,
                name = action.name
            };
        }
    }
}
