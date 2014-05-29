using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Seeker.Model;
using Seeker.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Repository.DataAccess
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {

        public User GetById(ObjectId id)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e._id,id);
                aUser = Collection.FindOne(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }

        public User GetByUserName(string userName)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e.UserName, userName);
                aUser = Collection.FindOne(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }

        public User GetByEmail(string email)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e.Email, email);
                aUser = Collection.FindOne(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }


        public List<UserBasic> GetAllFollwers(ObjectId id)
        {
            List<UserBasic> allFollowers = new List<UserBasic>();
            User aUser = new User();
            try
            {
                var query = Query.EQ("_id",id);
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Include(u => u.Followers)).Single();
                allFollowers = aUser.Followers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching followers" + ex);
            }
            return allFollowers;
        }

        public List<UserBasic> GetBlockList(ObjectId id)
        {
            List<UserBasic> allBlocks = new List<UserBasic>();
            User aUser = new User();
            try
            {
                var query = Query.EQ("_id", id);
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Include(u => u.BlockList)).Single();
                allBlocks = aUser.BlockList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching followers" + ex);
            }
            return allBlocks;
        }


        public User UserLogin(string userName, string userPass)
        {
            User aUser = new User();
            try
            {
                var query = Query.And(
                      Query<User>.EQ(e => e.UserName , userName),
                      Query<User>.EQ(e => e.Password, userPass)
                  );
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Include(u => u.UserName, u => u.Reputation)).Single();


            }
            catch (Exception ex)
            {
                
                throw new Exception("Login error" + ex);
            }
            return aUser;
        }


        public bool AddFollower(ObjectId id, UserBasic follower)
        {
            bool addSuccess = false;
            try
            {
                var query = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.AddToSet(u => u.Followers, follower));
                addSuccess = true;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error adding data" + ex);
            }
            
            return addSuccess;
        }

        public bool RemoveFollower(ObjectId id, UserBasic follower)
        {
            bool addSuccess = false;
            try
            {
                var quer = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.Pull(u => u.Followers, follower));
                addSuccess = true;
            }
            catch (Exception ex)
            {

                throw new Exception("Error removing data" + ex);
            }

            return addSuccess;
        }
        public bool AddToBlockList(ObjectId id, UserBasic block)
        {
            bool addSuccess = false;
            try
            {
                var query = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.AddToSet(u => u.BlockList, block));
         
                addSuccess = true;
            }
            catch (Exception ex)
            {

                throw new Exception("Error adding data" + ex);
            }

            return addSuccess;
        }
        public bool RemoveFromBlockList(ObjectId id, UserBasic block)
        {
            bool removeSuccess = false;
            try
            {
               
                var quer = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.Pull(u => u.BlockList, block));
                removeSuccess = true;
            }
            catch (Exception ex)
            {

                throw new Exception("Error removing data"+ex);
            }

            return removeSuccess;
        }

        public bool UpdateUserName(ObjectId id, string newUserName)
        {
            bool modifySuccess = false;
            try 
	        {
                var aUserData = Collection.FindAndModify(Query<User>.EQ(u => u._id, id), SortBy<User>.Ascending(u => u.UserName), Update<User>.Set(u => u.UserName, newUserName), true);
                if (aUserData != null)
                    modifySuccess = true;
	        }
	        catch (Exception ex)
	        {
		
		        throw new Exception("Udate failed"+ex);
	        }
            return modifySuccess;
            
        }


        public bool UpdateEmail(ObjectId id, string newEmail)
        {
            bool modifySuccess = false;
            try
            {
                var aUserData = Collection.FindAndModify(Query<User>.EQ(u => u._id, id), SortBy<User>.Ascending(u => u.UserName), Update<User>.Set(u => u.Email, newEmail), true);
                if (aUserData != null)
                    modifySuccess = true;
            }
            catch (Exception ex)
            {

                throw new Exception("Udate failed" + ex);
            }
            return modifySuccess;
        }

        public bool UpdateRating(ObjectId id, int value)
        {
            bool updateSuccess = false;
            try
            {
                var result = Collection.FindAndModify(Query.And(Query<User>.EQ(u => u._id, id)), SortBy.Null, Update<User>.Inc(u => u.Reputation, value), true);
                if (result != null)
                    updateSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data"+ex);
            }
            return updateSuccess;
        }
    }
}
