using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;

namespace Resume.Web.Components;

public class AboutViewComponent(IAboutService aboutService) : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    var model = await aboutService.GetDetailsForSiteAsync();
    return View("About", model);
  }
}
