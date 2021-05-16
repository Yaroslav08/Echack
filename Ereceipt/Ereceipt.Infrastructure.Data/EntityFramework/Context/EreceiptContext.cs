using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
namespace Ereceipt.Infrastructure.Data.EntityFramework.Context
{
    public class EreceiptContext : DbContext
    {
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }


        public EreceiptContext(DbContextOptions<EreceiptContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new BugdetConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EreceiptDb;Trusted_Connection=True;");
        //}


        public bool HasAnyData()
        {
            var users = Users.AsNoTracking().ToArrayAsync().Result;
            if (users == null || users.Length == 0)
                return false;
            return true;
        }
    }
}