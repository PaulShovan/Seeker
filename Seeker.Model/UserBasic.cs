using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class UserBasic
    {
        [BsonId]
        public ObjectId UserId { get; set; }
        public string Username { get; set; }
    }
}
