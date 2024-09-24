using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.User;

namespace Resume.DAL.Repositories.Interfaces;

public interface IUserRepository
{
  Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter);
  Task<AppUser?> GetByIdAsync(int id);
  Task<AppUser?> GetByEmailAsync(string email);
  Task AddAsync(AppUser model);
  void Update(AppUser model);
  Task<bool> IsEmailExistsAsync(int id, string email);
  Task<bool> IsMobileExistsAsync(int id, string mobile);
  Task SaveChangesAsync();
}
