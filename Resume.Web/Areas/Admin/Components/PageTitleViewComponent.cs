using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Components;

public class PageTitleViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("PageTitle");
  }
}
