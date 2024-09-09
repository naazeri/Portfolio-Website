using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.User;

namespace Resume.Bussines.Services.Implementations;

public class UserService(IUserRepository userRepository) : IUserService
{

  #region Methods
  public async Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter)
  {
    return await userRepository.GetAllAsync(filter);
  }

  public async Task<CreateUserResult> AddAsync(CreateUserViewModel model)
  {
    var user = new User()
    {
      FirstName = model.FirstName,
      LastName = model.LastName,
      Mobile = model.Mobile,
      Email = model.Email,
      Password = model.Password,
      IsActive = model.IsActive,
      CreateDate = DateTime.Now,
      UpdateDate = DateTime.Now,
    };

    await userRepository.AddAsync(user);
    await userRepository.SaveChangesAsync();

    return CreateUserResult.Success;
  }

  public async Task<EditUserViewModel?> GetForEditByIdAsync(int id)
  {
    var user = await userRepository.GetByIdAsync(id);
    if (user == null)
    {
      return null;
    }

    return new EditUserViewModel
    {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Mobile = user.Mobile,
      Email = user.Email,
      IsActive = user.IsActive
    };
  }

  public async Task<EditUserResult> UpdateAsync(EditUserViewModel model)
  {
    var user = await userRepository.GetByIdAsync(model.Id);

    if (user == null)
    {
      return EditUserResult.UserNotFound;
    }

    model.Email = model.Email.Trim().ToLower();

    if (await userRepository.IsEmailExistsAsync(model.Id, model.Email))
    {
      return EditUserResult.EmailAlreadyExists;
    }

    if (await userRepository.IsMobileExistsAsync(model.Id, model.Mobile))
    {
      return EditUserResult.MobileAlreadyExists;
    }

    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    user.Mobile = model.Mobile;
    user.Email = model.Email;
    user.IsActive = model.IsActive;
    user.UpdateDate = DateTime.Now;

    userRepository.Update(user);
    await userRepository.SaveChangesAsync();

    return EditUserResult.Success;
  }

  #endregion

}