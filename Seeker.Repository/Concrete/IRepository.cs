using MongoDB.Bson;
using Seeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeker.Repository.Concrete
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        //T GetById(int id);
        bool Add(T entity);
        void UpdateEntity(T entity);
        void Delete(T entity);
        void Delete(int id);
        
    }
}
