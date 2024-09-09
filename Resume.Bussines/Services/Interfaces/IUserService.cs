using Resume.DAL.Models;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;

namespace Resume.Bussines.Services.Interfaces;

public interface IUserService
{
  #region Methods

  Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter);
  Task<User?> GetByEmailAsync(string email);
  Task<CreateUserResult> AddAsync(CreateUserViewModel model);
  Task<EditUserViewModel?> GetForEditByIdAsync(int id);
  Task<UserDetailsViewModel?> GetForDetailsByIdAsync(int id);
  Task<EditUserResult> UpdateAsync(EditUserViewModel model);
  Task<LoginResult> LoginAsync(LoginViewModel model);

  #endregion
}
