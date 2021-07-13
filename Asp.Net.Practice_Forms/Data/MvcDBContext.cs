using Asp.Net.Practice_Forms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Data
{
    public class MvcDBContext : DbContext
    {
        public MvcDBContext(DbContextOptions<MvcDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
