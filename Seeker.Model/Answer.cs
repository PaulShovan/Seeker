using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    public class Answer
    {
        
        public string AnswerId { get; set; }
        public DateTime PostDate { get; set; }
        public string AnswerText { get; set; }
        public UserBasic AnswerBy { get; set; }
        public List<Comment> Comments { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public Answer()
        {
            this.AnswerBy = new UserBasic();
            this.Comments = new List<Comment>();
        }
    }
}
