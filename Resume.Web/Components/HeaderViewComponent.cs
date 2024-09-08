using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Components;

public class HeaderViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("Header");
  }
}