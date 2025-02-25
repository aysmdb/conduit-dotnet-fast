using Microsoft.EntityFrameworkCore;
using RealDotnetFast.Models.Entities;

namespace RealDotnetFast;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
        .HasMany(a => a.FavoritedBy)
        .WithMany(u => u.Favorites);

        modelBuilder.Entity<Article>()
        .HasOne(a => a.Author)
        .WithMany(u => u.Articles);

        modelBuilder.Entity<User>()
        .HasMany(u => u.Following)
        .WithMany()
        .UsingEntity<UserFollowing>();

        modelBuilder.Entity<User>()
        .HasMany(u => u.Follower)
        .WithMany()
        .UsingEntity<UserFollower>();

        base.OnModelCreating(modelBuilder);
    }
}