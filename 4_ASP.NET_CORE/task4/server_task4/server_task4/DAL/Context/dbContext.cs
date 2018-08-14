using Microsoft.EntityFrameworkCore;
using server_task4.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.DAL.Context
{
    public class dbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public dbContext(DbContextOptions<dbContext> options)
           : base(options)
        {
        }
    }
}
