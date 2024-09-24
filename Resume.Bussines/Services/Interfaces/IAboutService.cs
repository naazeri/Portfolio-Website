using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Bussines.Services.Interfaces;

public interface IAboutService
{
  #region Admin

  Task<AdminSideEditAboutViewModel?> GetDetailsAsync();
  Task<AdminSideEditAboutResult> UpdateAsync(AdminSideEditAboutViewModel model);

  #endregion
}
