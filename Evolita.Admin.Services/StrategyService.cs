using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evolita.Admin.Data.Repositories;
using Evolita.Admin.Tokens;

namespace Evolita.Admin.Services
{
    public class StrategyService : IStrategyService
    {
        private IStrategyRepository _strategyRepository;

        public StrategyService(IStrategyRepository strategyRepository)
        {
            _strategyRepository = strategyRepository;
        }

        public StrategyToken Create(StrategyToken token)
        {
            return _strategyRepository.Save(token.AsStrategy()).AsToken();
        }


        public IEnumerable<StrategyToken> GetStrategies()
        {
            return _strategyRepository.GetAll().Select(s => s.AsToken());
        }


        public StrategyToken GetStrategy(string id)
        {
            return _strategyRepository.Get(id).AsToken();
        }


        public void AddQuestion(string strategyid, string text)
        {
            _strategyRepository.AddQuestion(strategyid, text);
        }


        public string AddResearch(string strategyid, string text)
        {
            return _strategyRepository.AddResearch(strategyid, text);
        }


        public string AddAction(string strategyid, string researchid, string type, string text)
        {
            return _strategyRepository.AddAction(strategyid, researchid, type, text);
        }
    }
}
