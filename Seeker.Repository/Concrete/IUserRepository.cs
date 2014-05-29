using MongoDB.Bson;
using Seeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Repository.Concrete
{
    public interface IUserRepository
    {
        User GetById(ObjectId id);
        User GetByUserName(string userName);
        User GetByEmail(string email);
        List<UserBasic> GetAllFollwers(ObjectId id);
        List<UserBasic> GetBlockList(ObjectId id);
        User UserLogin(string userName, string userPass);
        bool AddFollower(ObjectId id, UserBasic follower);
        bool AddToBlockList(ObjectId id, UserBasic block);
        bool RemoveFromBlockList(ObjectId id, UserBasic block);
        bool RemoveFollower(ObjectId id, UserBasic follower);
        bool UpdateUserName(ObjectId id, string newUserName);
        bool UpdateEmail(ObjectId id, string newEmail);
        bool UpdateRating(ObjectId id, int value);
    }
}
