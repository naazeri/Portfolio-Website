using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Components;

public class SideBarViewComponent(IUserService userService) : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("SideBar");
  }
}
