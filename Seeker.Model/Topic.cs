using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class Topic
    {
        [BsonId]
        public ObjectId TopicId { get; set; }
        public DateTime PostedDate { get; set; }
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<UserBasic> Followers { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public Topic()
        {
            this.Discussions = new List<Discussion>();
            this.Followers = new List<UserBasic>();
        }
    }
}
