using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Extensions;
using Resume.Bussines.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Components;

public class NavBarViewComponent(IUserService userService) : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    var model = await userService.GetForDetailsByIdAsync(User.GetUserId());
    ViewData["User"] = model;
    return View("NavBar");
  }
}
