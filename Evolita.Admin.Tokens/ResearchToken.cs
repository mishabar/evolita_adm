using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolita.Admin.Data;

namespace Evolita.Admin.Tokens
{
    public class ResearchToken
    {
        public string id { get; set; }
        public string name { get; set; }
        public IEnumerable<ActionToken> actions { get; set; }
    }

    public static class ResearchExtensions
    {
        public static ResearchToken AsToken(this Research research)
        {
            return new ResearchToken 
            {
                id = research.id,
                name = research.name,
                actions = research.actions == null? new ActionToken[0] : research.actions.Select(a => a.AsToken())
            };
        }
    }
}
