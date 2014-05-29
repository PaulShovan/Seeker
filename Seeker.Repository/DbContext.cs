using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Seeker.Repository
{
    public class DbContext
    {
        public DbContext()
        {
            try
            {

                //var con = new MongoConnectionStringBuilder("server=127.0.0.1;database=seekertest");
                var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SeekerDB"].ConnectionString);
                var server = MongoServer.Create(con);
                db = server.GetDatabase(con.DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Db connection error" + ex);
            }
        }

        public MongoDatabase db { get; private set; }
    }
}
