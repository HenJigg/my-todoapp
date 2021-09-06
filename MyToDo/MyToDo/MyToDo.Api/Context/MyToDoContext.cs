using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Context
{
    public class MyToDoContext : DbContext
    {
        public MyToDoContext(DbContextOptions<MyToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Memo> Memo { get; set; }
    }
}
