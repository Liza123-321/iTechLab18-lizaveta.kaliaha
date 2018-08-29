using FilmsCatalog.DAL.Initializer;
using FilmsCatalog.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RatingMark> RatingMarks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
