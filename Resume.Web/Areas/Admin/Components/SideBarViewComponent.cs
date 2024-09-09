using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Components;

public class SideBarViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("SideBar");
  }
}
