using HCAChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace HCAChallenge.Data
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options) : base(options)
        {
        }
        public DbSet<SportFan> SportsFans { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportFan>().ToTable("SportFan");
        }
    }
}
