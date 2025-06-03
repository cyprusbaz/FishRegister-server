using FishRegister.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FishRegister.Infrastructure;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Fish> Fishes { get; set; }
    public DbSet<FishPost> FishPosts { get; set; }
    public DbSet<Admin> Admins { get; set; }
}