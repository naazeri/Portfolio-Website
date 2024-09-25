using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;
using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Web.Components;

public class SocialLinksViewComponent(IAboutService aboutService) : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync(List<SocialLink>? socialLinks)
  {
    List<SocialLinkDetailsViewModel> model;

    if (socialLinks == null || socialLinks.Count == 0)
    {
      model = await aboutService.GetSocialLinksAsync();
    }
    else
    {
      model = aboutService.MapSocialLinksToViewModel(socialLinks);
    }

    return View("SocialLinks", model);
  }
}
