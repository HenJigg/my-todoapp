using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Context.Repository
{ 
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(MyToDoContext dbContext) : base(dbContext)
        {
        }
    }
}
