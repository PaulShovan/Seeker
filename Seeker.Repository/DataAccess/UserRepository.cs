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

    }
}
