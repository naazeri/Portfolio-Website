using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Implementations;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Context;
using Resume.DAL.Repositories.Implementations;
using Resume.DAL.Repositories.Interfaces;

namespace Resume.Web.Configurations;

public static class DIContainer
{
  public static void RegisterService(this IServiceCollection services)
  {
    #region Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IContactUsRepository, ContactUsRepository>();
    services.AddScoped<IAboutRepository, AboutRepository>();
    #endregion

    #region Services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IContactUsService, ContactUsService>();
    services.AddScoped<IAboutService, AboutService>();
    services.AddScoped<IViewRenderService, ViewRenderService>();
    services.AddScoped<IEmailService, EmailService>();
    services.AddScoped<IImageService, ImageService>();
    #endregion
  }

  public static void ConfigDB(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseSqlServer(config.GetConnectionString("DefaultConnection"), configure =>
      {
        configure.MigrationsAssembly("Resume.Web");
      });
    });
  }

  public static void ConfigAuth(this IServiceCollection services, IConfiguration config)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCookie(options =>
    {
      options.LoginPath = "/login";
      options.LogoutPath = "/logout";
      options.ExpireTimeSpan = TimeSpan.FromDays(config.GetValue<int>("Cookie:ExpireDays"));
    });
  }

}
