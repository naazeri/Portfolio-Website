using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models;

namespace Resume.DAL.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  #region DbSets
  public DbSet<User> Users { get; set; }
  #endregion

  #region on model creating
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // foreach (var entityType in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
    // {
    //   entityType.DeleteBehavior = DeleteBehavior.Restrict;
    // }

    base.OnModelCreating(modelBuilder);
  }
  #endregion

}