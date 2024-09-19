using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models;
using Resume.DAL.Models.Common;

namespace Resume.DAL.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  #region DbSets
  public DbSet<User> Users { get; set; }
  public DbSet<ContactUs> ContactUs { get; set; }
  #endregion

  #region on model creating
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    #region Seed data
    modelBuilder.Entity<User>().HasData(
      new User()
      {
        Id = 1,
        FirstName = "Admin",
        LastName = "Admin",
        Email = "admin@gmail.com",
        Mobile = "09123456789",
        Password = EncodePasswordMd5("123456"),
        IsActive = true,
      }
    );
    #endregion
    // foreach (var entityType in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
    // {
    //   entityType.DeleteBehavior = DeleteBehavior.Restrict;
    // }

    base.OnModelCreating(modelBuilder);
  }
  #endregion

  #region BeforeSave
  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    BeforeSave();
    return base.SaveChangesAsync(cancellationToken);
  }

  public override int SaveChanges()
  {
    BeforeSave();
    return base.SaveChanges();
  }

  private void BeforeSave()
  {
    var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is IBaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

    var now = DateTime.Now;

    foreach (var entry in entries)
    {
      var entity = (IBaseEntity)entry.Entity;
      entity.UpdateDate = now;

      if (entry.State == EntityState.Added)
      {
        entity.CreateDate = now;
      }
    }
  }
  #endregion
  private string EncodePasswordMd5(string password)
  {
    byte[] originalBytes = Encoding.Default.GetBytes(password);
    byte[] encodedBytes = MD5.HashData(originalBytes);

    return BitConverter.ToString(encodedBytes);
  }

}
