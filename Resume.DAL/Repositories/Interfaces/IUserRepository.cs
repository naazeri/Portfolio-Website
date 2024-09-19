using Resume.DAL.Models;
using Resume.DAL.ViewModels.User;

namespace Resume.DAL.Repositories.Interfaces;

public interface IUserRepository
{
  #region Methods

  Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter);
  Task<User?> GetByIdAsync(int id);
  Task<User?> GetByEmailAsync(string email);
  Task AddAsync(User model);
  void Update(User model);
  Task<bool> IsEmailExistsAsync(int id, string email);
  Task<bool> IsMobileExistsAsync(int id, string mobile);
  Task SaveChangesAsync();

  #endregion
}
