using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interfaces;

namespace Resume.Web.Areas.Admin.Components;

public class SideBarViewComponent(IUserService userService) : ViewComponent
{
  #region Side Menu Items
  private static readonly List<MenuItem> MenuItems =
   [
     new()
     {
       Title = "Dashboard",
       Icon = "bi bi-grid",
       Controller = "Home",
       Action = "Index"
     },
     new()
     {
       Title = "Site Settings",
       Icon = "bi bi-globe2",
       SubItems =
       [
        new()
        {
          Title = "About",
          Controller = "About",
          Action = "Index",
        }
       ]
     },
     new()
     {
       Title = "About",
       Icon = "fa fa-info",
       Controller = "About",
       Action = "Index"
     },
   ];

  #endregion
  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View("SideBar");
  }
}

public class MenuItem
{
  public string? Title { get; set; }
  public string? Icon { get; set; }
  public string? Controller { get; set; }
  public string? Action { get; set; }
  public List<MenuItem>? SubItems { get; set; }
}
