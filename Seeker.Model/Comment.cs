using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class Comment
    {
        public string CommentId { get; set; }
        public UserBasic CommentBy { get; set; }
        public string CommentBody { get; set; }
        public int upvote { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
