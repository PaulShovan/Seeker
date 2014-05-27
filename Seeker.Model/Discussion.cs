using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class Discussion
    {
        [BsonId]
        public ObjectId DiscussionId { get; set; }
        public UserBasic PostedBy { get; set; }
        public string DiscussionBody { get; set; }
        public DateTime PostDate { get; set; }

        public Discussion()
        {
            this.PostedBy = new UserBasic();
        }
    }
}
