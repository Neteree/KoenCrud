using KoenCrud.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoenCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<WordPair> WordPairs { get; set; }
    }
}
