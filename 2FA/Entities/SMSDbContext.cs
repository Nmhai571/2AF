using Microsoft.EntityFrameworkCore;

namespace _2FA.Entities
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public SMSDbContext()
        {

        }
        public DbSet<SMSCode> sMSCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
