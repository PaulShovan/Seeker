using MongoDB.Bson;
using MongoDB.Driver;
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
    public class MongoRepository<T> : DbContext , IRepository<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }
        private DbContext MyProperty { get; set; }
        public MongoRepository()
        {
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public IList<T> GetAll()
        {
            
            List<T> all = new List<T>();
            try
            {
                all = Collection.FindAll().ToList() ;
                return all;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public bool Add(T entity)
        {

            try
            {
                Collection.Insert(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        
   
    }
}
