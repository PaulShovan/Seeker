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
    public class QuestionRepository : MongoRepository<Question>, IQuestionRepository
    {

        public bool AddAnswer(ObjectId quesId, Answer answer)
        {
            bool addSuccess = false;
            try
            {
                var query = Collection.Update(Query<Question>.EQ(q => q._id, quesId), Update<Question>.AddToSet(q => q.Answers, answer));
                addSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding answer" + ex);
            }
            return addSuccess;
        }

        public bool AddCommentToQuestion(ObjectId quesId, Comment aComment)
        {
            

            bool addDone = false;
            try
            {
                try
                {
                    var query = Collection.Update(Query<Question>.EQ(u => u._id, quesId), Update<Question>.AddToSet(u => u.Comments, aComment));

                    addDone = true;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error adding data" + ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding comment" + ex);
            }
            return addDone;
        }
        public bool AddCommentToAnswer(ObjectId quesId, string answerId, Comment aComment)
        {
            bool addSuccess = false;
            try
            {
                var query = Query.And(
                      Query.EQ("_id", quesId),
                      Query.EQ("Answers.AnswerId", answerId)
                  );
                //var query = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.AddToSet(u => u.BlockList, block));
                //var query = Query.EQ("posts.title", "Bar Post");
                var update = Update.AddToSet("Answers.$.Comments", aComment.ToBsonDocument());
                Collection.Update(query, update);
                //var query = Collection.Update(Query<Question>.EQ(q => q._id, quesId), Update<Question>.AddToSet(q => q.Comments, aComment));
                addSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding answer" + ex);
            }
            return addSuccess;
        }

        public Question GetById(MongoDB.Bson.ObjectId quesId)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetByAsker(MongoDB.Bson.ObjectId askerId)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetBySimilarTitleChunk(string titleChunk)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetByTag(List<string> tags)
        {
            throw new NotImplementedException();
        }
    }
}
