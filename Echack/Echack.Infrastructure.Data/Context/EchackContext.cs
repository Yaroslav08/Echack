using Echack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Infrastructure.Data.Context
{
    public class EchackContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chack> Chacks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EchackDb;Trusted_Connection=True;");
        }
    }
}