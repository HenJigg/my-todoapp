using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Context
{
    public class Memo : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
