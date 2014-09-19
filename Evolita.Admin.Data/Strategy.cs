using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Evolita.Admin.Data
{
    public class Strategy
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public DateTime last_modified { get; set; }
        public IEnumerable<string> questions { get; set; }
        public IEnumerable<Research> research { get; set; }
    }
}
