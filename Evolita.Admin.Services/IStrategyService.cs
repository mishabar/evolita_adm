using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolita.Admin.Tokens;

namespace Evolita.Admin.Services
{
    public interface IStrategyService
    {
        StrategyToken Create(StrategyToken token);

        IEnumerable<StrategyToken> GetStrategies();

        StrategyToken GetStrategy(string id);

        void AddQuestion(string strategyid, string text);

        string AddResearch(string strategyid, string text);

        string AddAction(string strategyid, string researchid, string type, string text);
    }
}
