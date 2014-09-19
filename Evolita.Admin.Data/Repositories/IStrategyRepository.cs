using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolita.Admin.Data.Repositories
{
    public interface IStrategyRepository
    {
        void Save(Strategy strategy);

        IEnumerable<Strategy> GetAll();

        Strategy Get(string id);

        void AddQuestion(string strategyid, string text);

        string AddResearch(string strategyid, string text);

        string AddAction(string strategyid, string researchid, string type, string text);
    }
}
