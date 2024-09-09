using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Components;

public class PageTitleViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("PageTitle");
  }
}
