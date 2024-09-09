using System.Security.Cryptography;
using System.Text;
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
        CreateDate = DateTime.Now,
        UpdateDate = DateTime.Now,
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

  private string EncodePasswordMd5(string password)
  {
    byte[] originalBytes = Encoding.Default.GetBytes(password);
    byte[] encodedBytes = MD5.HashData(originalBytes);

    return BitConverter.ToString(encodedBytes);
  }

}
