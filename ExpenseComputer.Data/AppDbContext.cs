using ExpenseComputer.Data.EntityConfigurations;
using ExpenseComputer.Entity;
using ExpenseComputerAPI.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ExpenseComputer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Products> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypesEntityConfiguration());
        }
    }
}
