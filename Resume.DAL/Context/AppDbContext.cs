using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models;
using Resume.DAL.Models.Common;
using Resume.DAL.Models.Config;
using Resume.DAL.Models.File;
using Resume.DAL.Models.User;

namespace Resume.DAL.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  #region DbSets
  public DbSet<AppUser> Users { get; set; }
  public DbSet<ContactUs> ContactUs { get; set; }
  public DbSet<About> About { get; set; }
  public DbSet<SocialLink> SocialLinks { get; set; }
  public DbSet<ImageFile> ImageFiles { get; set; }
  public DbSet<SiteConfig> SiteConfigs { get; set; }
  #endregion

  #region on model creating
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    #region Seed data
    // Seed User
    modelBuilder.Entity<AppUser>().HasData(
      new AppUser()
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

    // Seed SiteConfig
    modelBuilder.Entity<SiteConfig>().HasData(
      new SiteConfig()
      {
        Id = 1,
        SiteTitle = "John Doe Resume",
        Tagline = "My Portfolio",
        SiteIcon = "/Site/assets/img/favicon.png",
      }
    );

    // Seed About
    modelBuilder.Entity<About>().HasData(
      new About()
      {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        MyTitles = "Developer, Teacher, Designer",
        Summary = "It takes great pains to benefit. His needs result from something that actually drives him away. Let them be what they want. Anyone whom anyone desires. And no one who hinders receives the others. Because he should flee in this office of convenience, which is here.",
        CurrentJobTitle = "UI/UX Designer & Web Developer",
        CurrentJobTitleDescriptionTop = "It is important to take care of the patient, to be followed by the doctor, but it is a time of great pain and suffering.",
        CurrentJobTitleDescriptionBottom = "Therefore, choosing the services of labor and pains is the choice of the services. Anyone can get everything and that. There are no complaints from the prosecutors about their services at the time. And all his Because of desire, as said, most offices indeed. But those who are not to be repulsed will therefore be pursued.",
        Mobile = "09123456789",
        Email = "admin@gmail.com",
        BirthDate = new DateOnly(1995, 1, 25),
        Location = "Orlando, FL, USA",
      }
    );

    // Seed SocialLink separately with the foreign key for AboutId
    modelBuilder.Entity<SocialLink>().HasData(
      new SocialLink()
      {
        Id = 1,
        Title = "Linkedin",
        LinkAddress = "https://linkedin.com",
        IconName = "fa-linkedin",
        AboutId = 1 // Link to the About entity
      },
      new SocialLink()
      {
        Id = 2,
        Title = "Instagram",
        LinkAddress = "https://instagram.com",
        IconName = "fa-instagram",
        AboutId = 1 // Link to the About entity
      }
    );
    // Seed ImageFile separately with the foreign key for AboutId
    modelBuilder.Entity<ImageFile>().HasData(
        new ImageFile()
        {
          Id = 1,
          MaxImage = "/Site/assets/img/profile-img.jpg",
          LargeImage = "/Site/assets/img/profile-img.jpg",
          ThumbnailImage = "/Site/assets/img/profile-img.jpg",
          Alt = "profile image",
          AboutId = 1 // Assign the foreign key to link it to About entity
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
