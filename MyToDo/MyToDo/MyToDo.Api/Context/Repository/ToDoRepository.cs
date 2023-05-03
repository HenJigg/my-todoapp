using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detection_System.Api.Context.Repository
{ 
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public ToDoRepository(MyToDoContext dbContext) : base(dbContext)
        {
        }
    }
}
