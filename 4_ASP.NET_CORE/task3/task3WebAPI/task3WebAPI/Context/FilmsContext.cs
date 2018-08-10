using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.Models;

namespace task3WebAPI.Context
{
    public class FilmsContext : DbContext
    {
        public DbSet<FilmModel> Films { get; set; }
        public FilmsContext(DbContextOptions<FilmsContext> options) : base(options) { }
    }
}
