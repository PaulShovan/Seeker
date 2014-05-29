using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class Question
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public UserBasic QuestionBy { get; set; }
        public DateTime PostDate { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionBody { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Answer> Answers { get; set; }
        public List<string> Tags { get; set; }
        public List<UserBasic> Followers { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public Question()
        {
            this.Answers = new List<Answer>();
            this.Tags = new List<string>();
            this.Followers = new List<UserBasic>();
            this.QuestionBy = new UserBasic();
            this.Comments = new List<Comment>();
        }
    }
}
