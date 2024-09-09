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
    #endregion

    #region Services
    services.AddScoped<IUserService, UserService>();
    #endregion
  }

  public static void ConfigDB(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    });
  }

}