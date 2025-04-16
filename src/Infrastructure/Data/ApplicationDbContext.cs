using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Entities;
using CleanApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanApi.Infrastructure.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ConfigureIdentityTables(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    private static void ConfigureIdentityTables(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable($"users");
        builder.Entity<IdentityRole>().ToTable($"roles");
        builder.Entity<IdentityUserRole<string>>().ToTable($"user_roles");
        builder.Entity<IdentityUserClaim<string>>().ToTable($"user_claims");
        builder.Entity<IdentityRoleClaim<string>>().ToTable($"role_claims");
        builder.Entity<IdentityUserLogin<string>>().ToTable($"user_logins");
        builder.Entity<IdentityUserToken<string>>().ToTable($"user_tokens");
    }
}
