using Resume.DAL.ViewModels.User;

namespace Resume.Bussines.Services.Interfaces;

public interface IUserService
{
  #region Methods

  Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter);
  Task<CreateUserResult> AddAsync(CreateUserViewModel model);
  Task<EditUserViewModel?> GetForEditByIdAsync(int id);
  Task<EditUserResult> UpdateAsync(EditUserViewModel model);

  #endregion
}
