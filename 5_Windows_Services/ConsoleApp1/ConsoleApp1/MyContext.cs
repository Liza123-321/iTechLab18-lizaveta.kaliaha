using System.Data.Entity;

namespace ConsoleApp1
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=DefaultConnection") { }
        public DbSet<Ws> Wss { get; set; }
    }
}
