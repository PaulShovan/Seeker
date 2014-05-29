using MongoDB.Bson;
using Seeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Repository.Concrete
{
    public interface IQuestionRepository
    {
        bool AddAnswer(ObjectId quesId, Answer answer);
        bool AddCommentToQuestion(ObjectId quesId, Comment aComment);
        bool AddCommentToAnswer(ObjectId quesId, string answerId, Comment aComment);
        Question GetById(ObjectId quesId);
        List<Question> GetByAsker(ObjectId askerId);
        List<Question> GetBySimilarTitleChunk(string titleChunk);
        List<Question> GetByTag(List<string> tags);
    }
}
