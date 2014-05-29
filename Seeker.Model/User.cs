using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Model
{
    
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public DateTime JoinDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Phone { get; set; }
        public string Password { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }
        public List<UserBasic> Followers { get; set; }
        public List<UserBasic> BlockList { get; set; }
        public int Reputation { get; set; }
        public User()
        {
            this.Followers = new List<UserBasic>();
            this.BlockList = new List<UserBasic>();
        }

    }
}
