using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Bussines.Services.Interfaces;

public interface IAboutService
{
  #region Admin

  Task<AdminSideEditAboutViewModel?> GetDetailsForAdminAsync();
  Task<SiteSideDetailsAboutViewModel?> GetDetailsForSiteAsync();
  Task<List<SocialLinkDetailsViewModel>> GetSocialLinksAsync();
  List<SocialLinkDetailsViewModel> MapSocialLinksToViewModel(List<SocialLink> socialLinks);
  Task<AdminSideEditAboutResult> UpdateAsync(AdminSideEditAboutViewModel model);

  #endregion
}
