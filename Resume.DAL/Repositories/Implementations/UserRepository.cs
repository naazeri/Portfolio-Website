using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.User;

namespace Resume.DAL.Repositories.Implementations;

public class UserRepository(AppDbContext context) : IUserRepository
{
  public async Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter)
  {
    var query = context.Users.OrderByDescending(x => x.CreateDate)
      .AsQueryable();

    #region Filter
    if (!string.IsNullOrEmpty(filter.Mobile))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Mobile, $"%{filter.Mobile}%"));
    }

    if (!string.IsNullOrEmpty(filter.Email))
    {
      query = query
        .Where(x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));
    }
    #endregion

    #region Paging
    await filter.Paging(query.Select(x => new UserDetailsViewModel()
    {
      Id = x.Id,
      FirstName = x.FirstName,
      LastName = x.LastName,
      Mobile = x.Mobile,
      Email = x.Email,
      IsActive = x.IsActive,
      CreateDate = x.CreateDate,
      UpdateDate = x.UpdateDate,
    }));
    #endregion

    return filter;
  }

  public async Task<AppUser?> GetByIdAsync(int id)
  {
    return await context.Users
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<AppUser?> GetByEmailAsync(string email)
  {
    return await context.Users
      .FirstOrDefaultAsync(x => x.Email == email);
  }

  public async Task AddAsync(AppUser model)
  {
    await context.Users.AddAsync(model);
  }

  public void Update(AppUser model)
  {
    context.Users.Update(model);
  }

  public async Task<bool> IsEmailExistsAsync(int id, string email)
  {
    return await context.Users
      .AnyAsync(x => x.Email == email && x.Id != id);
  }

  public async Task<bool> IsMobileExistsAsync(int id, string mobile)
  {
    return await context.Users
      .AnyAsync(x => x.Mobile == mobile && x.Id != id);
  }

  public async Task SaveChangesAsync()
  {
    await context.SaveChangesAsync();
  }
}
