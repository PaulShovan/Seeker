using MongoDB.Bson;
using Seeker.Model;
using Seeker.Repository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Manager.UserManager
{
    public class UserAccount
    {
        private readonly UserRepository repo;
        public UserAccount()
        {
            repo = new UserRepository();
        }
        public string UserRegistration(User aUser)
        {
            string message = "";
            bool regSuccess = false;
            try
            {
                if (string.IsNullOrWhiteSpace(aUser.Email) || string.IsNullOrWhiteSpace(aUser.Password) || string.IsNullOrWhiteSpace(aUser.UserName))
                {
                    return message = "Please Enter Your Information Correctly";
                }
                else
                {
                    aUser._id = new ObjectId();
                    aUser.JoinDate = DateTime.Now;
                    aUser.BlockList = new List<UserBasic>();
                    aUser.Followers = new List<UserBasic>();
                    aUser.Reputation = 1;

                    regSuccess = repo.Add(aUser);
                    if(regSuccess)
                    {
                        message = "Thanks, You have been registered successfully.";
                    }
                    else
                    {
                        message = "Sorry, Registration Failed. Please try again later.";
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error In Registration Process" + ex);
            }
            
            
        }

    }
}
