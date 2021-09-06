using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(MyToDoContext dbContext) : base(dbContext)
        {

        }
    }
}
