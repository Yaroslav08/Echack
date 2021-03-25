using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
namespace Ereceipt.Infrastructure.Data.Context
{
    public class EreceiptContext : DbContext
    {
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EreceiptDb;Trusted_Connection=True;");
            //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }

        public bool HasAnyData()
        {
            var users = Users.AsNoTracking().ToArrayAsync().Result;
            if (users == null || users.Length == 0)
                return false;
            return true;
        }
    }
}