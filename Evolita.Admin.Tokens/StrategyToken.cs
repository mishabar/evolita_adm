using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolita.Admin.Data;

namespace Evolita.Admin.Tokens
{
    public class StrategyToken
    {
        public string id { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public DateTime? last_modified { get; set; }
        public IEnumerable<string> questions { get; set; }
        public IEnumerable<ResearchToken> research { get; set; }
    }

    public static class StrategyExtensions
    {
        public static StrategyToken AsToken(this Strategy strategy)
        {
            return new StrategyToken 
            {
                id = strategy.id,
                name = strategy.name,
                owner = strategy.owner,
                last_modified = strategy.last_modified,
                questions = strategy.questions,
                research = strategy.research == null ? new ResearchToken[0] : strategy.research.Select(r => r.AsToken())
            };
        }

        public static Strategy AsStrategy(this StrategyToken token)
        {
            return new Strategy
            {
                id = token.id,
                name = token.name,
                owner = token.owner,
                last_modified = token.last_modified.GetValueOrDefault(DateTime.UtcNow),
                questions = token.questions
            };
        }
    }
}
