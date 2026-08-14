using ChartOfAccounts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChartOfAccounts.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>()
      .HasKey(x => x.Id);

        modelBuilder.Entity<Account>()
    .Property(x => x.Code)
    .IsRequired();
        modelBuilder.Entity<Account>()
    .Property(x => x.Code)
    .HasMaxLength(50);
        modelBuilder.Entity<Account>()
    .Property(x => x.Name)
    .IsRequired();
        modelBuilder.Entity<Account>()
    .Property(x => x.Name)
    .IsRequired();

        modelBuilder.Entity<Account>()
            .Property(x => x.Name)
            .HasMaxLength(200);


        modelBuilder.Entity<Account>()
    .HasOne(x => x.AccountType)
    .WithMany()
    .HasForeignKey(x => x.AccountTypeId);


        modelBuilder.Entity<Account>()
    .HasOne(x => x.Parent)
    .WithMany(x => x.Children)
    .HasForeignKey(x => x.ParentId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Account>()
    .Property(x => x.IsActive)
    .HasDefaultValue(true);
        modelBuilder.Entity<Account>()
    .Property(x => x.Nature)
    .IsRequired();

        modelBuilder.Entity<Account>()
    .Property(x => x.IsPosting)
    .HasDefaultValue(false);
    }
}