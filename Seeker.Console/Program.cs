using MongoDB.Bson;
using Seeker.Model;
using Seeker.Repository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Seeker.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region User

            UserRepository repo = new UserRepository();
            User aUserData = new User();
            IList<User> allUser = new List<User>();
            allUser = repo.GetAll();
            foreach (User aUser in allUser)
            {
                ShowData(aUser.UserName);
                foreach(UserBasic aUserBasic in aUser.Followers)
                {
                    ObjectId id = aUserBasic._id;
                    ShowData(id.ToString());
                }
            }

            //aUserData = repo.UserLogin("user1", "123456");
            //ShowData(aUserData.UserName);
            aUserData._id = new ObjectId();
            aUserData.Email = "e@else.com";
            aUserData.BlockList = new List<UserBasic>();
            aUserData.Followers = new List<UserBasic>();
            aUserData.JoinDate = DateTime.Now;
            aUserData.Password = "123456";
            aUserData.Reputation = 15;
            aUserData.UserCity = "Dhaka";
            aUserData.UserCountry = "Bangladesh";
            aUserData.UserName = "noname";

            //bool s = repo.Add(aUserData);

            //ShowData(s.ToString());

            UserBasic follower = new UserBasic();
            follower._id = new ObjectId("000000000000000000000000");
            follower.Username = "user2";

            //ShowData(repo.UpdateRating(new ObjectId("5386572adff4651408c45868"), -5).ToString());
            Question aQuestion = new Question();
            aQuestion.Answers = new List<Answer>();
            aQuestion.Comments = new List<Comment>();
            aQuestion.Downvote = 0;
            aQuestion.Followers = new List<UserBasic>();
            aQuestion._id = new ObjectId();
            aQuestion.PostDate = DateTime.Now;
            aQuestion.QuestionBody = "What is MongoDb? and how can I use it with c#";
            aQuestion.QuestionBy._id = new ObjectId();
            aQuestion.QuestionBy.Username = "anonymous";
            aQuestion.QuestionTitle = "What is MongoDB?";
            aQuestion.Tags = new List<string> {"Database", "NoSql", "MongoDB", "C#" };
            aQuestion.Upvote = 0;

            QuestionRepository qRepo = new QuestionRepository();
            Answer anAnswer = new Answer();
            anAnswer.AnswerId = "1";
            anAnswer.AnswerBy = follower;
            anAnswer.AnswerText = "See 'mongodb.org' for details";
            anAnswer.Comments = new List<Comment>();
            anAnswer.Downvote = 0;
            anAnswer.PostDate = DateTime.Now;
            anAnswer.Upvote = 0;

            Comment aComment = new Comment();
            aComment.CommentBody = "Search google for it, you will find answer";
            aComment.CommentBy = follower;
            aComment.CommentDate = DateTime.Now;
            aComment.CommentId = "2";
            aComment.upvote = 0;
            ShowData(qRepo.AddCommentToAnswer(new ObjectId("538675cadff4651e0c7a256f"), "1", aComment).ToString());
            //ShowData(qRepo.Add(aQuestion).ToString());
            
            
            

            #endregion

            Console.ReadKey();
        }
        public static void ShowData(string Data)
        {
            Console.WriteLine(Data);
        }
    }
}
