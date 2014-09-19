using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Evolita.Admin.Data.Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private MongoCollection<Strategy> _collection;

        public StrategyRepository(MongoDatabase db)
        {
            _collection = db.GetCollection<Strategy>("strategies");
        }

        public void Save(Strategy strategy)
        {
            _collection.Save(strategy);
        }


        public IEnumerable<Strategy> GetAll()
        {
            return _collection.FindAll();
        }


        public Strategy Get(string id)
        {
            return _collection.FindOne(Query<Strategy>.EQ(s => s.id, id));
        }


        public void AddQuestion(string strategyid, string text)
        {
            _collection.Update(Query<Strategy>.EQ(s => s.id, strategyid), Update<Strategy>.Push(s => s.questions, text).Set(s => s.last_modified, DateTime.UtcNow));
        }


        public string AddResearch(string strategyid, string text)
        {
            Research research = new Research { id = Guid.NewGuid().ToString(), name = text };
            _collection.Update(Query<Strategy>.EQ(s => s.id, strategyid), Update<Strategy>.Push(s => s.research, research).Set(s => s.last_modified, DateTime.UtcNow));
            return research.id;
        }


        public string AddAction(string strategyid, string researchid, string type, string text)
        {
            Dictionary<string, object> action = new Dictionary<string, object> { { "_id", Guid.NewGuid().ToString() }, { "name", text }, { "type", type } };
            _collection.Update(Query.And(Query<Strategy>.EQ(s => s.id, strategyid), Query.EQ("research._id", researchid)),
                Update.Push("research.$.actions", new MongoDB.Bson.BsonDocument(action)).Set("last_modified", DateTime.UtcNow));
            return (string)action["_id"];
        }
    }
}
