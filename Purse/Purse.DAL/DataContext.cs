using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Purse.DAL.Models;
using System.Runtime.CompilerServices;

namespace Purse.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<CostItem>().HasKey(c => c.Id);
            modelBuilder.Entity<Expense>().HasKey(e => e.Id);
            modelBuilder.Entity<Income>().HasKey(i => i.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Incomes)
                .WithOne(i => i.Account)
                .HasForeignKey(i => i.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Expenses)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.CostItem)
                .WithMany()
                .HasForeignKey(i => i.CostItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.CostItem)
                .WithMany()
                .HasForeignKey(e => e.CostItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Account)
                .WithMany(a => a.Expenses)
                .HasForeignKey(e => e.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Income>()
                .HasOne(i => i.Account)
                .WithMany(a => a.Incomes)
                .HasForeignKey(i => i.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            builder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies();
        }
    }
}
