using Api.Data.Mapping;
using Api.Interfaces;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<AccountModel> Accounts { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}