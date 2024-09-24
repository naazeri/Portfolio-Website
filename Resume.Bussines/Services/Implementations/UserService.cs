using Resume.Bussines.Security;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interfaces;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;

namespace Resume.Bussines.Services.Implementations;

public class UserService(IUserRepository repository) : IUserService
{

  #region Methods
  public async Task<FilterUserViewModel> GetAllAsync(FilterUserViewModel filter)
  {
    return await repository.GetAllAsync(filter);
  }

  public async Task<AppUser?> GetByEmailAsync(string email)
  {
    email = email.Trim().ToLower();
    return await repository.GetByEmailAsync(email);
  }

  public async Task<CreateUserResult> AddAsync(CreateUserViewModel model)
  {
    var user = new AppUser()
    {
      FirstName = model.FirstName,
      LastName = model.LastName,
      Mobile = model.Mobile,
      Email = model.Email,
      Password = model.Password.Trim().EncodePasswordMd5(),
      IsActive = model.IsActive,
    };

    await repository.AddAsync(user);
    await repository.SaveChangesAsync();

    return CreateUserResult.Success;
  }

  public async Task<EditUserViewModel?> GetForEditByIdAsync(int id)
  {
    var user = await repository.GetByIdAsync(id);
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

  public async Task<UserDetailsViewModel?> GetForDetailsByIdAsync(int id)
  {
    var user = await repository.GetByIdAsync(id);
    if (user == null)
    {
      return null;
    }

    return new UserDetailsViewModel
    {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Mobile = user.Mobile,
      Email = user.Email,
      IsActive = user.IsActive,
      CreateDate = user.CreateDate,
      UpdateDate = user.UpdateDate
    };
  }

  public async Task<EditUserResult> UpdateAsync(EditUserViewModel model)
  {
    var user = await repository.GetByIdAsync(model.Id);

    if (user == null)
    {
      return EditUserResult.UserNotFound;
    }

    model.Email = model.Email.Trim().ToLower();

    if (await repository.IsEmailExistsAsync(model.Id, model.Email))
    {
      return EditUserResult.EmailAlreadyExists;
    }

    if (await repository.IsMobileExistsAsync(model.Id, model.Mobile))
    {
      return EditUserResult.MobileAlreadyExists;
    }

    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    user.Mobile = model.Mobile;
    user.Email = model.Email;
    user.IsActive = model.IsActive;

    repository.Update(user);
    await repository.SaveChangesAsync();

    return EditUserResult.Success;
  }

  public async Task<LoginResult> LoginAsync(LoginViewModel model)
  {
    model.Email = model.Email.Trim().ToLower();
    var user = await repository.GetByEmailAsync(model.Email);

    if (user == null)
    {
      return LoginResult.UserNotFound;
    }

    string hashPassword = model.Password.Trim().EncodePasswordMd5();

    if (user.Password != hashPassword)
    {
      return LoginResult.Error;
    }

    return LoginResult.Success;
  }

  #endregion

}
